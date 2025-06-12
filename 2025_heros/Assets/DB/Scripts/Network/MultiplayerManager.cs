using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
[RequireComponent(typeof(NetworkView))]
[RequireComponent(typeof(ChatLog))]

public class MultiplayerManager : MonoBehaviour
{
	public string UserName;
	public string ServerName = "DB_coop";
	public int Port = 25000;
	public string IPServer = "127.0.0.1";
	public HostData[] gameList;
	public bool OfflineMode;
	public bool LanOnly = true;
	[HideInInspector]
	public bool IsConnected;
	[HideInInspector]
	public string CurrentLevel;
	[HideInInspector]
	public HostData ServerSelected;
	[HideInInspector]
	public bool refreshing = false;
	[HideInInspector]
	public bool IsPlaying = false;
	
	private string[] hostip;
	private ChatLog logManager;
	[HideInInspector]
	public int lastLevelPrefix = 0;
	private string lastLevelLoaded;
	private GameManager gameManager;
	private Popup pop;
	
	
	
	
	void Start ()
	{
		// setup all components.
		pop = (Popup)GameObject.FindObjectOfType(typeof(Popup));
		gameManager = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));
		logManager = (ChatLog)GameObject.FindObjectOfType (typeof(ChatLog));
		CurrentLevel = Application.loadedLevelName;
		PlayerPrefs.SetString ("PlayerTemp", "");
		GetComponent<NetworkView>().group = 1;
		gameList = null;
		IPServer = GetLocalIPAddress ();
		lastLevelPrefix = 1;
	}

	public string GetLocalIPAddress ()
	{
		IPHostEntry host;
		string localIP = "";
		host = Dns.GetHostEntry (Dns.GetHostName ());
		foreach (IPAddress ip in host.AddressList) {
			if (ip.AddressFamily == AddressFamily.InterNetwork) {
				localIP = ip.ToString ();
			}
		}
		return localIP;
	}

	void Update ()
	{

		if (refreshing) {
			if (MasterServer.PollHostList ().Length > 0) {
				refreshing = false;
				gameList = MasterServer.PollHostList ();
			}
		}
		if (Network.isServer) {
			//sending all level information if you are server.
			SendCurrentGameLevel ();
			IsConnected = true;
		}

		if (!Network.isClient && !Network.isServer) {
			IsConnected = false;
			if(!OfflineMode){
				IsPlaying = false;
			}else{
				IsPlaying = true;
			}
			
		}
	}

	public void CreateGame ()
	{
		// Start server
		IsPlaying = false;
		bool useNat = false;
		
		if (LanOnly) {
			useNat = false;
		} else {
			useNat = !Network.HavePublicAddress ();
		}
		
		Network.InitializeServer (32, Port, useNat);

		if (!LanOnly) {
			MasterServer.RegisterHost (ServerName, "Room " + SystemInfo.deviceName + "  " + SystemInfo.deviceType);
		}
		lastLevelPrefix = 1;
	}

	public void KillGame ()
	{
		Network.Disconnect ();
		MasterServer.UnregisterHost ();
		Time.timeScale = 1;
	}
	
	void OnServerInitialized ()
	{
		Debug.Log ("Server initialized!");
		PlayerPrefs.SetString ("PlayerTemp", "");
	}
	
	void OnConnectedToServer ()
	{
		Debug.Log ("Connected to server!");	
		PlayerPrefs.SetString ("PlayerTemp", "");
	}
	
	void OnPlayerDisconnected (NetworkPlayer player)
	{
		if (Network.isServer) {
			Debug.Log ("Quit! " + player);
			logManager.AddLog ("<color=gray>"+player.ipAddress + " is Quit!</color>");
			Network.RemoveRPCs (player);
			Network.DestroyPlayerObjects (player);
		}
	}
	
	void OnPlayerConnected (NetworkPlayer player)
	{
		// Only on Server.. when some client has joined
		if (Network.isServer) {
			Debug.Log ("Player " + player.ipAddress + ":" + player.port + " Is connected");
			logManager.AddLog ("<color=gray>"+player.ipAddress + " is Joined!</color>");
			// callback tell the server info
			GetComponent<NetworkView>().RPC ("PlayerConnectedCallback", player, CurrentLevel, lastLevelPrefix, IsPlaying);
		}
	}

	public void OnDisconnectedFromServer (NetworkDisconnection info)
	{
		// When you are disconnected. 

		PlayerManager playermanger = (PlayerManager)GameObject.FindObjectOfType (typeof(PlayerManager));
		// save character data..
		if (playermanger) {
			if (playermanger.GetComponent<PlayerSave> ()) {
				playermanger.GetComponent<PlayerSave> ().Save ();
			}
			if (playermanger.GetComponent<CharacterSystem> ())
				playermanger.GetComponent<CharacterSystem> ().DontDestroy = false;
		}
		
		// Clean up all characters
		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
			if (go.GetComponent<CharacterSystem> ()) {
				go.GetComponent<CharacterSystem> ().DontDestroy = false;
			} 
		}
		// reset time scale (for sure)
		Time.timeScale = 1;
		// clear chat log
		if(logManager)
			logManager.Clear();
		// then going to the landingpage
		if (Application.loadedLevelName != PlayerPrefs.GetString ("landingpage"))
			Application.LoadLevel (PlayerPrefs.GetString ("landingpage"));
		
		Debug.Log ("Disconnected from server already!");
		
	}

	void OnMasterServerEvent (MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.RegistrationSucceeded)
			Debug.Log ("Server registered");
		 
	}
	
	[RPC]
	void PlayerConnectedCallback (string currentLevel, int suffix, bool playing)
	{
		// Notify player who connected.. if server is ok for him
		Debug.Log ("Callback from server!!");
		IsPlaying = playing;
		if (playing) {
			// host is now playing
			PlayerPrefs.SetString ("PlayerTemp", "");
			CurrentLevel = currentLevel;
			lastLevelPrefix = suffix;
			IsConnected = true;
			Debug.Log ("Let's start at Level " + currentLevel);
			Application.LoadLevel (currentLevel);
		} else {
			// host maybe on loding screen or not even start
			if(pop)
				pop.ShowPopup("Server is not ready yet!");
			Debug.Log ("Server Is Not Ready!");
			Network.Disconnect ();
		}
	}

	public void Refresh ()
	{
		MasterServer.RequestHostList (ServerName);
		Debug.Log ("Refresh " + MasterServer.PollHostList ());
		gameList = null;
		refreshing = true;
	}
	
	public void GameSelected (HostData game)
	{
		ServerSelected = game;
		hostip = game.ip;
	}

	public void join (string startlevel)
	{
		// Join game
		if (!Network.isServer && !OfflineMode) {
			// in Multiplayer mode. have to connect the server
			if (LanOnly) {
				Network.Connect (IPServer, Port);	
				Debug.Log ("Local Joining.." + IPServer);
			} else {
				if (ServerSelected != null) {
					Network.Connect (ServerSelected);	
					Debug.Log ("Online Joining.." + ServerSelected.gameName);
			
				}
			}
		} else {
			// in single player.. just LoadLevel and go
			IsPlaying = true;
			Application.LoadLevel (startlevel);
		}
	}
	
	[RPC]
	public void GetCurrentGameLevel (string text, int lastPrefix)
	{
		// get current level information from host
		lastLevelPrefix = lastPrefix;
		CurrentLevel = text;
		IsConnected = true;
	}

	public void SendCurrentGameLevel ()
	{
		// Always send level information to all clients
		this.GetComponent<NetworkView>().RPC ("GetCurrentGameLevel", RPCMode.AllBuffered, Application.loadedLevelName, lastLevelPrefix);		
	}
	
	void OnGUI ()
	{
		GUI.skin.label.fontSize = 14;
		GUI.skin.label.normal.textColor = Color.white;
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		string gametype = "Local game";
		if (!LanOnly)
			gametype = "Online";
		if (Network.isServer) {
			GUI.Label (new Rect (0, 0, 300, 30), gametype + " Is Server IP: " + MasterServer.ipAddress + " (" + Network.connections.Length + ") Players ");
		} else {
			if (Network.isClient)
				GUI.Label (new Rect (0, 0, 300, 30), gametype + " Is Client");
		}
	}

	public void StartLoadLevel (string level,string door)
	{
		DoorID = door;
		Debug.Log ("Go to new level");
		if ((Network.isServer || Network.isClient)) {
			if (IsConnected) {
				Network.RemoveRPCsInGroup (0);
				Network.RemoveRPCsInGroup (1);
				// Telling other players to changing Level
				GetComponent<NetworkView>().RPC ("SceneLoadLevel", RPCMode.All, level, lastLevelPrefix + 1,DoorID);	
			}
		} else {
			StartCoroutine (SceneLoadLevel (level, lastLevelPrefix,DoorID));
		}
	}

	[RPC]// Level loader, 
	IEnumerator SceneLoadLevel (string level, int levelPrefix,string door)
	{
		DoorID = door;
		// Got Message from some player whos changing level.
		Debug.Log ("Load level " + level);
		PlayerManager player = (PlayerManager)GameObject.FindObjectOfType (typeof(PlayerManager));
		if (player) {
			if (player.GetComponent<PlayerSave> ()) {
				player.GetComponent<PlayerSave> ().Save ();
			}
		}

		lastLevelPrefix = levelPrefix;
		// Pause all sender and reader pacakge until the level has loaded.
		if (Network.isServer && Network.isClient) {
			Network.SetSendingEnabled (0, false);    
			Network.isMessageQueueRunning = false;
			Network.SetLevelPrefix (levelPrefix);
			foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
				if (go.GetComponent<NetworkView>()) {
					if ((go.GetComponent<NetworkView>().isMine || Network.isServer) && go.GetComponent<NetworkView>().group != 1) {
						Network.RemoveRPCs (go.GetComponent<NetworkView>().viewID);
						Network.Destroy (go.gameObject);	
					}
				}
			}
		} else {
			foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
				if (go.gameObject != this.gameObject) {
					GameObject.Destroy (go.gameObject);	
				}
			}
		}

		lastLevelLoaded = level;
		Application.LoadLevel (level);
		
		yield return null;
		yield return null;

		if (Network.isServer && Network.isClient)
			Network.isMessageQueueRunning = true;
	
	}
	
	[HideInInspector]
	public string DoorID;
	void OnLevelWasLoaded ()
	{
		Debug.Log("Level was loaded");
		// Must wait until the server was Loaded!
		if (IsPlaying) {
			if (!Network.isServer && !Network.isClient) {
				OnServerLevelLoaded ();
			} else {
				if (Network.isServer) {
					if (Application.loadedLevelName == lastLevelLoaded) {
						GetComponent<NetworkView>().RPC ("OnServerLevelLoaded", RPCMode.All, null);	
					}
				}
			}
		}
	}

	[RPC] 
	void OnServerLevelLoaded ()
	{
		Debug.Log ("New level on server is ready!");
		if (Network.isServer || Network.isClient) {
			Network.SetSendingEnabled (0, true);
		}
		// Respawn and play
		if(gameManager)
			gameManager.RespawnPlayer ();

		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
			go.SendMessage ("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver); 
	}

	

}

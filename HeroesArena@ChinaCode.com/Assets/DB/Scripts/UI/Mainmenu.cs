/// <summary>
/// Mainmenu. Just Main menu GUI
/// </summary>
using UnityEngine;
using System.Collections;

public class Mainmenu : MonoBehaviour
{

	public Texture2D LogoGame;
	public GUISkin skin;
	public int PageState = 0;
	public GameObject[] TargetLookat;
	public CharacterCreator characterCreator;
	public MultiplayerManager multiplayer;
	
	private float delta;
	private int pageTemp;
	
	void Awake ()
	{
		// Alway checking first.. Never let this component get a douplicated.
		MultiplayerManager[] multiPlayers = (MultiplayerManager[])GameObject.FindObjectsOfType (typeof(MultiplayerManager));
		for (int i=0; i<multiPlayers.Length && multiPlayers.Length>1; i++) {
			if (multiPlayers [i].lastLevelPrefix <= 0) {
				GameObject.Destroy (multiPlayers [i].gameObject);
			}
		}
	}
	
	void Start ()
	{
		delta = 1;
		StyleManager StyleManage = (StyleManager)GameObject.FindObjectOfType (typeof(StyleManager));
		if (StyleManage)
			skin = StyleManage.GetSkin (0);
		
		PlayerPrefs.SetString ("landingpage", Application.loadedLevelName);
		characterCreator = this.gameObject.GetComponent<CharacterCreator> ();
		multiplayer = (MultiplayerManager)GameObject.FindObjectOfType (typeof(MultiplayerManager));
	}

	bool showfeatures;

	void DrawFeatures ()
	{
		if (showfeatures) {
			GameManager gameManage = (GameManager)GameObject.FindObjectOfType (typeof(GameManager));
			GUI.Label (new Rect (20, 20, 120, 30), "Game Mode");
			
			if (GUI.Button (new Rect (20, 50, 200, 30), Application.loadedLevelName)) {
				if (Application.loadedLevelName == "MainMenu_casual") {
					Application.LoadLevel ("MainMenu_creator");
				} else {
					Application.LoadLevel ("MainMenu_casual");
				}
			}
			if (gameManage) {
				GUI.Label (new Rect (20, 80, 120, 30), "Game View");
			
				if (GUI.Button (new Rect (20, 111, 120, 30), gameManage.GameView.ToString ())) {
					if (gameManage.GameView == GameStyle.ThirdPerson) {
						gameManage.GameView = GameStyle.TopDown;		
					} else {
						gameManage.GameView = GameStyle.ThirdPerson;
					}
				}	
			}
			if (GUI.Button (new Rect (20, 150, 120, 30), "Close")) {
				showfeatures = false;
			}
			
		} else {
			if (GUI.Button (new Rect (20, 20, 160, 40), "New Features!")) {
				showfeatures = true;
			}
		}	
	}
	
	Vector2 scrollPosition;
	void DrawGameLobby ()
	{
		if (multiplayer) {
			if (!multiplayer.refreshing) {
				if (multiplayer.gameList != null) {
					scrollPosition = GUI.BeginScrollView (new Rect (Screen.width / 2 - 275, 50, 550, Screen.height - 200), scrollPosition, new Rect (0, 0, 500, 60 * multiplayer.gameList.Length));

					for (int i=0; i<multiplayer.gameList.Length; i++) {
						HostData hostgame = multiplayer.gameList [i];
						string ips = "";
						foreach (string ip in hostgame.ip) {
							ips += ip;
						}
						if (GUI.Button (new Rect (0, i * 60, 500, 50), hostgame.gameName + " " + ips)) {
							multiplayer.LanOnly = false;
							multiplayer.GameSelected (hostgame);
							if (characterCreator != null) {
								characterCreator.Open(true);
							}
							PageState = 1;
						}
					}
					GUI.EndScrollView ();
				} else {
					GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2, 200, 50), "No game Found");
				}
			} else {
				GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2, 200, 50), "Refreshing..");
			}
		}
	}
	
	

	void OnGUI ()
	{
		Screen.lockCursor = false;
		if (skin)
			GUI.skin = skin;

		GUI.skin.button.fontSize = 17;
		
		switch (PageState) {
			
		case 0:
			DrawFeatures ();
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 20 + (-100 * delta), 260, 50), "Single Player")) {
				var logManager = (ChatLog)GameObject.FindObjectOfType (typeof(ChatLog));
				logManager.AddLog(Random.Range(0,100).ToString());
				if (characterCreator != null)
					characterCreator.Open(true);
				
				if (multiplayer)
					multiplayer.OfflineMode = true;
				
				PageState = 1;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 80+ (-100 * delta), 260, 50), "Network")) {
			
				PageState = 2;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 140+ (-100 * delta), 260, 50), "Puchase")) {
				Application.OpenURL ("https://www.assetstore.unity3d.com/#/content/10043");
			}

			GUI.DrawTexture (new Rect (Screen.width / 2 - (LogoGame.width * 0.5f) / 2, Screen.height / 2 - 200+ (-300 * delta), LogoGame.width * 0.5f, LogoGame.height * 0.5f), LogoGame);	
		
			break;
		case 1:
			
			if (characterCreator != null && !characterCreator.Active) {
				if (multiplayer)
					multiplayer.KillGame ();
				PageState = 0;
			}
			if (characterCreator == null) {
				if (GUI.Button (new Rect (50+ (-300 * delta), 50, 160, 50), "Back")) {
					PageState = 0;
					if (multiplayer)
						multiplayer.KillGame ();
				}	
			}
			break;
			
		case 2:
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 20+ (50 * delta), 260, 50), "Host Game")) {

				PageState = 7;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 80+ (50 * delta), 260, 50), "Find Game")) {
				PageState = 4;
				if (multiplayer)
					multiplayer.Refresh ();
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 140+ (50 * delta), 260, 50), "Connect IP")) {
				PageState = 3;
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 200+ (50 * delta), 260, 50), "Back")) {
				PageState = 0;
			}

			GUI.DrawTexture (new Rect (Screen.width / 2 - (LogoGame.width * 0.5f) / 2, Screen.height / 2 - 200, LogoGame.width * 0.5f, LogoGame.height * 0.5f), LogoGame);	

			break;
			
		case 3:
			
			multiplayer.Port = int.Parse (GUI.TextField (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 20, 180, 50), multiplayer.Port.ToString ()));
			GUI.Label (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 20, 100, 50), "Port");

			multiplayer.IPServer = GUI.TextField (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 80, 180, 50), multiplayer.IPServer);
			GUI.Label (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 80, 100, 50), "IP");

			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 140+ (50 * delta), 260, 50), "Connect")) {
				if (characterCreator != null) {
					characterCreator.Open(true);
				}
				PageState = 1;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 200+ (50 * delta), 260, 50), "Back")) {
				PageState = 2;
			}
			GUI.DrawTexture (new Rect (Screen.width / 2 - (LogoGame.width * 0.5f) / 2, Screen.height / 2 - 200, LogoGame.width * 0.5f, LogoGame.height * 0.5f), LogoGame);	
			break;
			
		case 4:
			
			GUI.Box (new Rect (Screen.width / 2 - 275, 50, 550, Screen.height - 200), "");
			DrawGameLobby ();

			if (GUI.Button (new Rect (Screen.width / 2 - 130+ (-300 * delta), Screen.height - 120, 260, 50), "Back")) {
				PageState = 2;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 150, Screen.height - 120, 100, 50), "Refresh")) {
				if (multiplayer)
					multiplayer.Refresh ();
			}
			break;
		case 5:
			multiplayer.Port = int.Parse (GUI.TextField (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 20, 180, 50), multiplayer.Port.ToString ()));
			GUI.Label (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 20, 100, 50), "Port");
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 80+ (50 * delta), 260, 50), "Host Game")) {
				if (multiplayer) {
					multiplayer.LanOnly = false;
					multiplayer.CreateGame ();
					
				}
				if (characterCreator != null) {
					characterCreator.Open(true);
				}
				PageState = 1;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 140+ (50 * delta), 260, 50), "Back")) {
				PageState = 7;
			}
			GUI.DrawTexture (new Rect (Screen.width / 2 - (LogoGame.width * 0.5f) / 2, Screen.height / 2 - 200, LogoGame.width * 0.5f, LogoGame.height * 0.5f), LogoGame);	
			break;
		case 6:
			multiplayer.Port = int.Parse (GUI.TextField (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 20, 180, 50), multiplayer.Port.ToString ()));
			GUI.Label (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 20, 100, 50), "Port");
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 80+ (50 * delta), 260, 50), "Host Local Game")) {
				if (multiplayer) {
					multiplayer.LanOnly = true;
					multiplayer.CreateGame ();
					
				}
				if (characterCreator != null) {
					characterCreator.Open(true);
				}
				PageState = 1;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 140+ (50 * delta), 260, 50), "Back")) {
				PageState = 7;
			}
			GUI.DrawTexture (new Rect (Screen.width / 2 - (LogoGame.width * 0.5f) / 2, Screen.height / 2 - 200, LogoGame.width * 0.5f, LogoGame.height * 0.5f), LogoGame);	
			break;
		case 7:
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 20+ (50 * delta), 260, 50), "Master Server")) {
				if (multiplayer)
					multiplayer.LanOnly = false;
				PageState = 5;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 80+ (50 * delta), 260, 50), "Local Game")) {
				if (multiplayer)
					multiplayer.LanOnly = true;

				PageState = 6;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 130, Screen.height / 2 + 140+ (50 * delta), 260, 50), "Back")) {
				PageState = 2;
			}
			
			GUI.DrawTexture (new Rect (Screen.width / 2 - (LogoGame.width * 0.5f) / 2, Screen.height / 2 - 200, LogoGame.width * 0.5f, LogoGame.height * 0.5f), LogoGame);	
			
			break;
		}
		
		GUI.skin.label.fontSize = 14;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.skin.label.normal.textColor = Color.white;
		GUI.Label (new Rect (0, Screen.height - 50, Screen.width, 30), "Dungeon Breaker Starter Kit 3.0. | www.hardworkerstudio.com");
	}

	void Update ()
	{
		delta += (0-delta)/10f;
		if(pageTemp!=PageState){
			delta = 1;
			pageTemp = PageState;
		}
		if (TargetLookat.Length > 0 && PageState < TargetLookat.Length) {
			this.transform.position = Vector3.Lerp (this.transform.position, TargetLookat [PageState].transform.position, 1.0f * Time.deltaTime);
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, TargetLookat [PageState].transform.rotation, 1.0f * Time.deltaTime);	
		}
	}
}

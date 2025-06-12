/// <summary>
/// Game manager.
/// will collected a player score and try to read an event 
/// what happened in the game and how to do next  
/// </summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SkillManager))]
[RequireComponent(typeof(ItemManager))]
[RequireComponent(typeof(BlackFade))]
public class GameManager : MonoBehaviour
{
	public GUISkin Skin;
	[HideInInspector]
	public int Score = 0;
	[HideInInspector]
	public bool IsPlaying;
	[HideInInspector]
	public int Page;
	[HideInInspector]
	private GameObject cameraMain;
	[HideInInspector]
	public GameObject PlayCharacter;
	public GameStyle GameView;
	public GameObject GameCamera;
	public GameObject GameCameraTopDown;
	public int TargetFrameRate = 60;

	void Start ()
	{
		StyleManager StyleManage = (StyleManager)GameObject.FindObjectOfType (typeof(StyleManager));
		if (StyleManage) {
			Skin = StyleManage.GetSkin (0);
		}
		Application.targetFrameRate = TargetFrameRate;
		DontDestroyOnLoad (this.gameObject);
		IsPlaying = true;
	}

	bool offlineMode;

	void Update ()
	{
		offlineMode = (!Network.isServer && !Network.isClient);
		// checking game camera or setup if not exist
		if (cameraMain == null) {
			OrbitGameObject cam = (OrbitGameObject)GameObject.FindObjectOfType (typeof(OrbitGameObject));
			if (cam != null) {
				cameraMain = cam.gameObject;
			} else {
				if (Camera.main == null) {
					switch (GameView) {
					case GameStyle.ThirdPerson:
						if (GameCamera != null) {
							cameraMain = (GameObject)GameObject.Instantiate (GameCamera, Vector3.zero, Quaternion.identity);	
						}
						break;
					case GameStyle.TopDown:
						if (GameCameraTopDown != null) {
							cameraMain = (GameObject)GameObject.Instantiate (GameCameraTopDown, Vector3.zero, Quaternion.identity);	
						}
						break;
					}
				} else {
					cameraMain = Camera.main.GetComponent<Camera>().gameObject;
				}
			}
		}
	}



	// Read message from Game Object and making an event.
	public void GameEvent (string message)
	{
		switch (message) {
		case "endgame":
			IsPlaying = false;
			Page = 1;
			break;
		}
	}

	public void SaveAndExit ()
	{
		
		PlayerManager player = (PlayerManager)GameObject.FindObjectOfType (typeof(PlayerManager));
		MultiplayerManager mp = (MultiplayerManager)GameObject.FindObjectOfType (typeof(MultiplayerManager));
		// save character
		if (player) {
			if (player.gameObject.GetComponent<PlayerSave> ())
				player.gameObject.GetComponent<PlayerSave> ().Save ();
			
			if (player.GetComponent<CharacterSystem> ())
				player.GetComponent<CharacterSystem> ().DontDestroy = false;
		}
		
		if (offlineMode) {
			if (Application.loadedLevelName != PlayerPrefs.GetString ("landingpage"))
				Application.LoadLevel (PlayerPrefs.GetString ("landingpage"));
			
			if (player) {
				if (player.GetComponent<CharacterSystem> ())
					player.GetComponent<CharacterSystem> ().DontDestroy = false;
			}
			
			GameObject.Destroy (this.gameObject);
		} else {
			if (mp) {
				mp.KillGame ();
			}
		}
		// Clean up all characters
		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
			if (go.GetComponent<CharacterSystem> ()) {
				go.GetComponent<CharacterSystem> ().DontDestroy = false;
			} 
		}
		
		IsPlaying = true;
	}

	public void RespawnPlayer ()
	{
		Debug.Log ("Respawn!!");
		var spawner = (CharacterSpawner)FindObjectOfType (typeof(CharacterSpawner));
		var mp = (MultiplayerManager)FindObjectOfType (typeof(MultiplayerManager));
		
		if (spawner) {
			//Debug.Log ("Re Spawn Character..." + PlayCharacter.name);
			var character = spawner.Spawn (PlayCharacter);
			
			// Spawn at the right door.
			if (character != null && mp != null) {
				Teleporter[] doors = (Teleporter[])GameObject.FindObjectsOfType (typeof(Teleporter));
				for (int i=0; i<doors.Length; i++) {
					if (mp.DoorID == doors [i].DoorID) {
						character.transform.position = doors [i].transform.position + doors [i].SpawnOffset;
						Debug.Log ("Teleported " + doors [i].name);
						break;
					}
				}
			}
		}
		
	}
	
	void OnGUI ()
	{
		if (Skin != null)
			GUI.skin = Skin;

		if (IsPlaying) {

			
		} else {
			Screen.lockCursor = false;
			switch (Page) {
			case 0:
				GUI.skin.label.fontSize = 25;
				GUI.skin.label.alignment = TextAnchor.MiddleCenter;
				GUI.skin.label.normal.textColor = Color.white;
				GUI.Label (new Rect (0, Screen.height / 2 - 150, Screen.width, 30), "Pause Game");


				if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 50), "Save")) {
					PlayerManager player = (PlayerManager)GameObject.FindObjectOfType (typeof(PlayerManager));
					if (player.gameObject.GetComponent<PlayerSave> ())
						player.gameObject.GetComponent<PlayerSave> ().Save ();
					IsPlaying = true;
				}

				if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 40, 200, 50), "Resume")) {
					IsPlaying = true;
					Page = 0;
				}

				if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 20, 200, 50), "Exit")) {
					SaveAndExit ();
				}

				break;
			case 1:
				GUI.skin.label.fontSize = 25;
				GUI.skin.label.alignment = TextAnchor.MiddleCenter;
				GUI.skin.label.normal.textColor = Color.white;
				GUI.Label (new Rect (0, Screen.height / 2 - 150, Screen.width, 50), "You Died!");


				if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 50), "Respawn")) {
					MultiplayerManager mp = (MultiplayerManager)GameObject.FindObjectOfType (typeof(MultiplayerManager));
					if (mp) {
						if (mp.IsConnected || (!Network.isClient && !Network.isServer)) {
							RespawnPlayer ();
							IsPlaying = true;
							Page = 0;
						} 
					}
				}

				if (GUI.Button (new Rect (Screen.width / 2 - 80, Screen.height / 2 - 40, 160, 50), "Exit")) {
					SaveAndExit ();
				}
				
				break;
			}
		
		}
	}
}

public enum GameStyle
{
	TopDown,
	ThirdPerson
}

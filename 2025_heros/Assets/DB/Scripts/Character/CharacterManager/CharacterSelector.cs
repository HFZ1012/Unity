using UnityEngine;
using System.Collections;

public class CharacterSelector : MonoBehaviour
{
	public bool Active = true;
	public GUISkin skin;
	public GameObject CharacterSlected;
	[HideInInspector]
	public string Text = "Name";
	public string SceneNameStart = "Setting";
	public bool ResetEveryRound;
	private MultiplayerManager mp;
	private	GameManager gameManager;
	void Start ()
	{
		gameManager = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));
		mp = (MultiplayerManager)GameObject.FindObjectOfType (typeof(MultiplayerManager));
	}

	void Update ()
	{
		
		if (mp) {
			if (!mp.OfflineMode) {
				// if not offline mode. have to connected first or be a server.
				if ((Network.isClient && mp.IsConnected) || Network.isServer) {
					Spawning ();
				}
			} else {
				// in offline mode we just going normally
				Spawning ();
				
			}
		}
	}

	public void Spawning ()
	{
		var spawner = (CharacterSpawner)FindObjectOfType (typeof(CharacterSpawner));
		if (spawner) {
			// found the spawner point	
			if (gameManager)// save this character to temp. using for the next spawing in other level or revive after dead
				gameManager.PlayCharacter = CharacterSlected;
			// keep this variable to global variable. we have to use it in CharacterSpawner.cs
			PlayerPrefs.SetString ("ResetEveryRound", ResetEveryRound.ToString ());
		
			// Spawn this character
			GameObject characterSpawned = spawner.Spawn (CharacterSlected);
			if (characterSpawned)// save Character name to global variable too
				PlayerPrefs.SetString ("PlayerTemp", characterSpawned.GetComponent<CharacterStatus> ().Name);
		
			// then destroy this character deliver
			Destroy (this.gameObject);
		}
	}

	public void StartThisCharacter ()
	{
		// Let's start with this character
		
		// join the game
		if (mp)
			mp.join (SceneNameStart);	

		BlackFade fader = (BlackFade)GameObject.FindObjectOfType (typeof(BlackFade));
		if (fader)
			fader.Fade (1, 0);
		
		// After we selected a character
		// do not destroy this object yet!! 
		// Keep this until a level was loaded and it delivered this character to spawing point on the level.
		DontDestroyOnLoad (this.gameObject);
	}
	
	void OnGUI ()
	{
		if (!Active)
			return;
		
		if (skin)
			GUI.skin = skin;
		
		if (Camera.main != null) {
		
			Vector3 screenPos = Camera.main.GetComponent<Camera>().WorldToScreenPoint (this.gameObject.transform.position);	
			var dir = (Camera.main.GetComponent<Camera>().transform.position - this.transform.position).normalized;
			var direction = Vector3.Dot (dir, Camera.main.GetComponent<Camera>().transform.forward);
	    
			if (direction < 0.6f) {
				if (GUI.Button (new Rect (screenPos.x - 75, Screen.height - screenPos.y, 200, 50), Text)) {
					StartThisCharacter ();
				}
			}
		}
	}
}

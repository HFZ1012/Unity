using UnityEngine;
using System.Collections;

public struct CharacterSave
{
	public string Name;
	public int Level;
	public int CharacterBaseIndex;
}

public class CharacterCreator : MonoBehaviour
{

	public GUISkin skin;
	public bool Active = false;
	public GameObject CharacterStarter;
	public GameObject[] CharacterBase;
	public Texture2D[] CharacterBaseIcon;
	public CharacterSelector CharacterLauncher;
	private bool createMode;
	private string newCharacterName = "Enter Your Name";
	private CharacterSave[] characterList;
	private Vector2 scrollPosition;
	private bool characterLoaded;
	private int indexModel;
	private bool removeConfirm;
	private CharacterStarterItem characterItemPreview;
	
	void Start ()
	{
		if (CharacterLauncher == null)
			CharacterLauncher = (CharacterSelector)GameObject.FindObjectOfType (typeof(CharacterSelector));

		StyleManager StyleManage = (StyleManager)GameObject.FindObjectOfType (typeof(StyleManager));
		if (StyleManage) {
			skin = StyleManage.GetSkin (0);
		}
		//load all characters data to the lists
		loadCharacterList ();
	}

	void Awake ()
	{
		if (CharacterStarter != null) {
			if (CharacterStarter.GetComponent<CharacterSystem> ()) {
				CharacterStarter.GetComponent<CharacterSystem> ().DontDestroy = false;
			}	
		}
	}

	int characterCount = 0;

	void SetCharacter (int index)
	{
		Debug.Log ("Set Start Character");
		indexModel = index;
		GameObject.Destroy (CharacterStarter.gameObject);
		// clone character prefab to CharacterStarter
		CharacterStarter = (GameObject)GameObject.Instantiate (CharacterBase [indexModel], CharacterLauncher.transform.position, CharacterLauncher.transform.rotation);
		if (CharacterStarter.GetComponent<CharacterStarterItem> ()) {
			CharacterStarter.GetComponent<CharacterStarterItem> ().Active = false;
		}		
		if (CharacterStarter.GetComponent<CharacterSystem> ()) {
			CharacterStarter.GetComponent<CharacterSystem> ().DontDestroy = false;
		}
		if (CharacterStarter.GetComponent<NetworkView>())
			Destroy (CharacterStarter.GetComponent<NetworkView>());
		
		characterItemPreview = CharacterStarter.GetComponent<CharacterStarterItem> ();
	}
	
	public void Open (bool active)
	{
		// setup every opening
		indexModel = 0;
		Active = active;
		loadCharacterList ();
	}
	
	void OnGUI ()
	{
		if (!Active)
			return;
		
		if (skin)
			GUI.skin = skin;
		
		if (CharacterStarter) {
			if (createMode) {
				// CREATE CHARACTER PAGE =======================================================
				GUI.skin.label.fontSize = 20;
				GUI.skin.label.alignment = TextAnchor.MiddleCenter;
				GUI.skin.label.normal.textColor = Color.white;
				GUI.Label (new Rect (50, 50, 160, 30), "Create Character");
				
				// character name
				newCharacterName = GUI.TextField (new Rect (50, 100, 200, 39), newCharacterName);
				characterItemPreview = CharacterStarter.GetComponent<CharacterStarterItem> ();
				if (characterItemPreview) {
					
					if (GUI.Button (new Rect (50, 160, 200, 50), "Sword Man")) {
						SetCharacter (0);// use model from CharacterBase[0]
						characterItemPreview.Active = true;
						characterItemPreview.StarterItem [0] = 1;// set start item
						characterItemPreview.StarterItem [1] = 2;// set start item
						characterItemPreview.Setting ();
					}
					
					if (GUI.Button (new Rect (50, 220, 200, 50), "Berserker")) {
						SetCharacter (1);// use model from CharacterBase[1]
						characterItemPreview.Active = true;
						characterItemPreview.StarterItem [0] = 0;// set start item
						characterItemPreview.StarterItem [1] = 6;// set start item
						characterItemPreview.Setting ();
					}
					if (GUI.Button (new Rect (50, 280, 200, 50), "Wizard")) {
						SetCharacter (1);// use model from CharacterBase[1]
						characterItemPreview.Active = true;
						characterItemPreview.StarterItem [0] = 5;// set start item
						characterItemPreview.StarterItem [1] = -1;// set start item (-1 = no item)
						characterItemPreview.Setting ();
					}
					
					// finish 
					if (GUI.Button (new Rect (Screen.width - 240, Screen.height - 140, 200, 50), "Accept")) {
						CharacterStarter.GetComponent<CharacterStatus> ().ModelIndex = indexModel;
						if (CharacterStarter.GetComponent<PlayerSave> ().NewCharacter (newCharacterName)) {
							createMode = false;
							loadCharacterList ();
						}
					}
					if (GUI.Button (new Rect (50, Screen.height - 140, 200, 50), "Cancel")) {
						loadCharacterList ();
						createMode = false;
					}
				}

			} else {
				
				// DISPLAY ALL CHARACTER FROM LIST ==========================================================
				GUI.skin.label.fontSize = 20;
				GUI.skin.label.alignment = TextAnchor.MiddleCenter;
				GUI.skin.label.normal.textColor = Color.white;
				GUI.Label (new Rect (50, 50, 160, 30), "Character List");

				if (characterList != null) {
					scrollPosition = GUI.BeginScrollView (new Rect (50, 100, 320, Screen.height - 400), scrollPosition, new Rect (0, 0, 300, characterCount * 105));
					characterCount = 0;
					for (int i=0; i<characterList.Length; i++) {
						// show Icon , Name , Level 
						if (characterList [i].Name != "" && characterList [i].Level > 0) {
							characterCount++;
							GUI.skin.label.fontSize = 16;
							GUI.skin.label.alignment = TextAnchor.MiddleLeft;
							GUI.Box (new Rect (105, 105 * i, 195, 100), "");
							GUI.skin.label.normal.textColor = Color.black;
							if (CharacterStarter.GetComponent<CharacterStatus> ().Name == characterList [i].Name) {
								
								GUI.skin.label.normal.textColor = Color.white;
							}
							
							GUI.skin.label.fontSize = 25;
							GUI.Label (new Rect (120, 105 * i + 10, 180, 50), characterList [i].Name);
							GUI.skin.label.fontSize = 16;
							GUI.Label (new Rect (120, 105 * i + 40, 180, 50), "Level " + characterList [i].Level);
							
							if (GUI.Button (new Rect (0, 105 * i, 100, 100), CharacterBaseIcon [characterList [i].CharacterBaseIndex])) {
								SetCharacter (CharacterStarter.GetComponent<PlayerSave> ().LoadIndexModel (characterList [i].Name));
								CharacterStarter.GetComponent<CharacterStatus> ().Name = characterList [i].Name;
								CharacterStarter.GetComponent<PlayerSave> ().Load ();
							}
							
						}
						
					}
					GUI.EndScrollView ();
				}
				// if you have chosen one
				if (characterLoaded) {
					// if removing
					if (removeConfirm) {
						if (GUI.Button (new Rect (50, Screen.height - 285, 100, 40), "Confirm")) {
							CharacterStarter.GetComponent<PlayerSave> ().RemoveCharacter ();
							createMode = false;
							loadCharacterList ();
						}
						if (GUI.Button (new Rect (155, Screen.height - 285, 100, 40), "Cancel")) {
							removeConfirm = false;
						}
					} else {
						// remove this character
						if (GUI.Button (new Rect (50, Screen.height - 280, 200, 40), "Remove Character")) {
							removeConfirm = true;
						}	
					}
					
					// start playing this character
					if (characterNum > 0) {
						// must have at least 1 character
						if (GUI.Button (new Rect (Screen.width - 240, Screen.height - 140, 200, 50), "Start")) {
							//Copy objects to CharacterSlected Using character prefab from CharacterBase [indexModel];
							CharacterLauncher.CharacterSlected = CharacterBase [indexModel];
							CharacterLauncher.CharacterSlected.GetComponent<CharacterStatus> ().Name = CharacterStarter.GetComponent<CharacterStatus> ().Name;
							GameObject.DontDestroyOnLoad (CharacterLauncher.CharacterSlected);
							CharacterLauncher.StartThisCharacter ();
						}
					}
				}
				
				if (GUI.Button (new Rect (50, Screen.height - 230, 200, 40), "Create Character")) {
					createMode = true;	
				}
				
				if (GUI.Button (new Rect (50, Screen.height - 140, 200, 50), "Main Menu")) {
					Active = false;
				}
			}
		}
		
	}
	int characterNum = 0;
	void loadCharacterList ()
	{
		// load all save characters to characterList[]
		characterLoaded = false;
		characterNum = 0;
		string[] gamechars = PlayerPrefs.GetString ("GAME_CHARACTER").Split ("|" [0]);
		characterList = new CharacterSave[gamechars.Length];
		for (int i=0; i<gamechars.Length; i++) {
			if (gamechars [i] != "") {
				characterNum++;
				characterList [i].Name = gamechars [i];
				characterList [i].Level = PlayerPrefs.GetInt ("LEVEL_" + gamechars [i]);
				characterList [i].CharacterBaseIndex = PlayerPrefs.GetInt ("MODELINDEX_" + gamechars [i]);
			}
		}

		if (characterList [0].Name != "") {
			// set starter chatacter. characterList[0] will show up first.
			SetCharacter (CharacterStarter.GetComponent<PlayerSave> ().LoadIndexModel (characterList [0].Name));
			CharacterStarter.GetComponent<CharacterStatus> ().Name = characterList [0].Name;
			CharacterStarter.GetComponent<PlayerSave> ().Load ();
			characterLoaded = true;
		}
	}
}

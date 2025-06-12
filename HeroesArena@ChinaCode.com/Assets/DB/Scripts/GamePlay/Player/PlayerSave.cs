// Save all character data
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterSystem))]

public class PlayerSave : MonoBehaviour
{
	private CharacterSystem character;
	public string Prefix = "";
	
	void Awake ()
	{
		character = this.GetComponent<CharacterSystem> ();
	}
	void Start(){
	}
	
	
	
	public bool NewCharacter (string Name)
	{
		bool res = true;
		string[] characterlist = PlayerPrefs.GetString ("GAME_CHARACTER").Split ("|" [0]);
		for (int i=0; i<characterlist.Length; i++) {
			if (characterlist [i] == Name) {
				res = false;
				break;	
			}
		}
		if (res) {
			character.characterStatus.Name = Name;
			PlayerPrefs.SetString ("GAME_CHARACTER", PlayerPrefs.GetString ("GAME_CHARACTER") + Name + "|");
			Save ();
		}
		Debug.Log (PlayerPrefs.GetString ("GAME_CHARACTER"));
		return res;
	}
	
	
	
	public bool RemoveCharacter ()
	{
		bool res = false;
		string[] characterlist = PlayerPrefs.GetString ("GAME_CHARACTER").Split ("|" [0]);
		for (int i=0; i<characterlist.Length; i++) {
			if (characterlist [i] == character.characterStatus.Name) {
				characterlist [i] = "";	
				res = true;
				break;
			}
		}
		if (res) {
			string list = "";
			for (int i=0; i<characterlist.Length; i++) {
				if (characterlist [i] != "") {
					list += characterlist [i] + "|";	
				}
			}
			PlayerPrefs.SetString ("GAME_CHARACTER", list);
			
		}
		Debug.Log (PlayerPrefs.GetString ("GAME_CHARACTER"));
		return res;
	}
	
	
	
	public bool Save ()
	{
		if(!character)
			return false;

		string namesave = "_" + character.characterStatus.Name + Prefix;
		// save status
		PlayerPrefs.SetString ("SAVEDATE" + namesave, System.DateTime.Now.ToString ());
		PlayerPrefs.SetInt ("STR" + namesave, character.characterStatus.STR);
		PlayerPrefs.SetInt ("AGI" + namesave, character.characterStatus.AGI);
		PlayerPrefs.SetInt ("INT" + namesave, character.characterStatus.INT);
		PlayerPrefs.SetInt ("LEVEL" + namesave, character.characterStatus.LEVEL);
		PlayerPrefs.SetInt ("EXP" + namesave, character.characterStatus.EXP);
		PlayerPrefs.SetInt ("EXPmax" + namesave, character.characterStatus.EXPmax);
		PlayerPrefs.SetInt ("HP" + namesave, character.characterStatus.HP);
		PlayerPrefs.SetInt ("SP" + namesave, character.characterStatus.SP);
		PlayerPrefs.SetInt ("POINT" + namesave, character.characterStatus.StatusPoint);
		PlayerPrefs.SetInt ("MODELINDEX" + namesave, character.characterStatus.ModelIndex);
		PlayerPrefs.SetInt ("MONEY" + namesave, character.characterInventory.Money);

		var skillDeployer = character.gameObject.GetComponent<CharacterSkillBase> ();
		if (skillDeployer != null)
		PlayerPrefs.SetInt ("SKILLPOINT" + namesave, skillDeployer.SkillPoint);
		
		string itemIndex = "";
		string itemNum = "";
		for (int i=0; i<character.characterInventory.ItemSlots.Count; i++) {
			if (character.characterInventory.ItemSlots [i]!=null) {
				itemIndex += character.characterInventory.ItemSlots [i].Index + ",";
				itemNum += character.characterInventory.ItemSlots [i].Num + ",";
			}
		}
		PlayerPrefs.SetString ("ItemsIndex" + namesave, itemIndex);
		PlayerPrefs.SetString ("ItemsNum" + namesave, itemNum);
		
		string itemEqIndex = "";
		string itemEqActive = "";
		for (int i=0; i<character.characterInventory.ItemsEquiped.Length; i++) {
			if (character.characterInventory.ItemsEquiped [i] != null) {
				itemEqIndex += character.characterInventory.ItemsEquiped [i].Index + ",";
				itemEqActive += character.characterInventory.ItemsEquiped [i].Active +",";
			}
		}

		PlayerPrefs.SetString ("ItemsEqIndex" + namesave, itemEqIndex+"%"+itemEqActive);
		Debug.Log ("Save Game as : "+namesave);
		return true;
	}
	
	
	
	public int LoadIndexModel(string name){
		string namesave = "_" + name + Prefix;
		return PlayerPrefs.GetInt ("MODELINDEX" + namesave);
	}
	
	
	public bool Load ()
	{
		if(!character)
			return false;

		string nameTemp = PlayerPrefs.GetString ("PlayerTemp");
		if(nameTemp!=""){
			character.characterStatus.Name = nameTemp;
		}

		string namesave = "_" + character.characterStatus.Name + Prefix;
		if (PlayerPrefs.GetString ("SAVEDATE" + namesave) == "") {
			Debug.Log ("No Save Game");
			return false;
		}

		
		character.characterStatus.STR = PlayerPrefs.GetInt ("STR" + namesave);
		character.characterStatus.AGI = PlayerPrefs.GetInt ("AGI" + namesave);
		character.characterStatus.INT = PlayerPrefs.GetInt ("INT" + namesave);
		character.characterStatus.LEVEL = PlayerPrefs.GetInt ("LEVEL" + namesave);
		character.characterStatus.EXP = PlayerPrefs.GetInt ("EXP" + namesave);
		character.characterStatus.EXPmax = PlayerPrefs.GetInt ("EXPmax" + namesave);
		character.characterStatus.HP = PlayerPrefs.GetInt ("HP" + namesave);
		character.characterStatus.SP = PlayerPrefs.GetInt ("SP" + namesave);
		character.characterStatus.StatusPoint = PlayerPrefs.GetInt ("POINT" + namesave);
		character.characterStatus.ModelIndex = PlayerPrefs.GetInt ("MODELINDEX" + namesave);
		character.characterInventory.Money = PlayerPrefs.GetInt ("MONEY" + namesave);

		var skillDeployer = character.gameObject.GetComponent<CharacterSkillBase> ();
		if (skillDeployer != null)
			skillDeployer.SkillPoint = PlayerPrefs.GetInt ("SKILLPOINT" + namesave);
	
		
		string[] itemIndex = PlayerPrefs.GetString ("ItemsIndex" + namesave).Split ("," [0]);
		string[] itemNum = PlayerPrefs.GetString ("ItemsNum" + namesave).Split ("," [0]);

		string[] itemEqDataPack = PlayerPrefs.GetString ("ItemsEqIndex" + namesave).Split ("%" [0]);
		string[] itemEqIndex = new string[0];
		string[] itemEqActive = new string[0];
		if(itemEqDataPack.Length > 1){

		itemEqIndex = itemEqDataPack[0].Split ("," [0]);
		itemEqActive = itemEqDataPack[1].Split ("," [0]);


		character.characterInventory.ItemSlots.Clear ();
		for (int i=0; i<itemIndex.Length; i++) {
			if (itemIndex [i] != "") {
				ItemSlot itemS = new ItemSlot ();
				itemS.Index = int.Parse (itemIndex [i]);
				itemS.Num = int.Parse (itemNum [i]);
				character.characterInventory.ItemSlots.Add (itemS);
			}
		}
		character.characterInventory.UnEquipAll ();

		for (int i=0; i<itemEqIndex.Length; i++) {
			if (itemEqIndex [i] != null && itemEqIndex [i] != "") {
				ItemSlot itemQe = new ItemSlot ();
				
				itemQe.Index = int.Parse (itemEqIndex [i]);
				itemQe.Active = false;

				if(itemEqActive.Length >0 && itemEqActive[i]!=null){
					if(itemEqActive[i] == "True"){
						character.characterInventory.EquipItem (itemQe);
					}
				}


			}
		}
		}
		Debug.Log ("Load Game as : "+namesave);
		GenCodetData(namesave);
		return true;
	}
	
	// in case: if you wanted to generate text data like xml
	public void GenCodetData(string namesave){
		string phase = "|";
		string inphase = ",";
		
		string res = PlayerPrefs.GetInt ("STR" + namesave)+inphase+
		PlayerPrefs.GetInt ("AGI" + namesave)+inphase+
		PlayerPrefs.GetInt ("INT" + namesave)+inphase+
		PlayerPrefs.GetInt ("LEVEL" + namesave)+inphase+
		PlayerPrefs.GetInt ("EXP" + namesave)+inphase+
		PlayerPrefs.GetInt ("EXPmax" + namesave)+inphase+
		PlayerPrefs.GetInt ("HP" + namesave)+inphase+
		PlayerPrefs.GetInt ("SP" + namesave)+inphase+
		PlayerPrefs.GetInt ("POINT" + namesave)+inphase+
		PlayerPrefs.GetInt ("SKILLPOINT" + namesave)+phase+
		PlayerPrefs.GetInt ("MODELINDEX" + namesave)+inphase+
		PlayerPrefs.GetInt ("MONEY" + namesave)+phase+

		PlayerPrefs.GetString ("ItemsIndex" + namesave)+phase+
		PlayerPrefs.GetString ("ItemsNum" + namesave)+phase+
		PlayerPrefs.GetString ("ItemsEqIndex" + namesave);
		
		//Debug.Log("Code data "+ res);
	}

}

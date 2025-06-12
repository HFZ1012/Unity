/// <summary>
/// Character inventory.
/// this class is an Item Equipment and Inventory sorting System
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterInventory : MonoBehaviour
{
	public GameObject[] ItemEmbedSlot;// list of embedded objects.

	public ItemSlot[] ItemsEquiped;// list of item equiped
	//[HideInInspector]
	public List<ItemSlot> ItemSlots = new List<ItemSlot> ();// list of items collected
	public int Money = 50;
	[HideInInspector]
	public ItemManager itemManager;// Item data base
	[HideInInspector]
	public bool IsArmed;
	private CharacterSystem characterSystem;
	public int ItemCount;

	void Awake ()
	{
		characterSystem = this.gameObject.GetComponent<CharacterSystem> ();	
		itemManager = (ItemManager)FindObjectOfType (typeof(ItemManager));
		ItemsEquiped = new ItemSlot[ItemEmbedSlot.Length];
		for (int i=0; i<ItemsEquiped.Length; i++) {
			ItemsEquiped [i] = new ItemSlot ();
			ItemsEquiped [i].Active = false;

		}

	}
	
	// remove al child from parent'
	private void removeAllChild (GameObject parent)
	{
		foreach (Transform trans in parent.transform) {
			if (trans != null) {
				GameObject.Destroy (trans.gameObject);
			}
		}
	}
	
	// unequip all items
	public void UnEquipAll ()
	{
		for (int i =0; i<ItemsEquiped.Length; i++) {
			removeAllChild (ItemEmbedSlot [i]);
			ItemsEquiped [i].Active = false;
		}
	}
	
	// get number of ItemSlots[index]
	public int GetItemNum (int itemIndex)
	{
		int res = 0;
		foreach (var itemSlot in ItemSlots) {
			if (itemSlot != null && itemSlot.Index == itemIndex) {
				res = itemSlot.Num;
				break;
			}
		}
		return res;
	}

	// add item to collector
	public void AddItem (int itemIndex, int num)
	{
		//Debug.Log ("Add Item " + itemIndex + " Num " + num);
		foreach (var itemSlot in ItemSlots) {
			if (itemSlot != null && itemSlot.Index == itemIndex) {
				itemSlot.Num += num;
				return;
			}
		}

		var itemgot = new ItemSlot ();
		itemgot.Index = itemIndex;
		itemgot.Num = num;
		itemgot.Active = true;
		
		ItemSlots.Add (itemgot);
		EquipItem (itemgot);
		
	}

	// remove item from collector by number
	public void RemoveItem (int itemIndex, int num)
	{
		foreach (var itemSlot in ItemSlots) {
			if (itemSlot != null && itemSlot.Index == itemIndex) {
				if (itemSlot.Num > 0) {
					itemSlot.Num -= num;
					if (itemSlot.Num <= 0) {
						ItemSlots.Remove (itemSlot);
					}
				}
				if (CheckEquiped (itemSlot)) {
					UnEquipItem (itemSlot);
				}
				return;
			}
		}
	}

	public void RemoveItem (ItemSlot item, int num)
	{
		if (item != null) {
			if (item.Num >= num) {
				item.Num -= num;
			}
			if (item.Num <= 0) {
				ItemSlots.Remove (item);
			}
			if (CheckEquiped (item)) {
				UnEquipItem (item);
			}
		}
	}

	// remove all item from collector
	public void RemoveAllItem ()
	{
		for (int i=0; i<ItemSlots.Count; i++) {

			if (CheckEquiped (ItemSlots [i])) {
				UnEquipItem (ItemSlots [i]);
			}
		}
		ItemSlots.Clear ();
		
	}

	string EquipCharDataTemp = "";
	// Generate inventory to text data 
	public string GetItemEquipCharData ()
	{
		string data = "";
		string active = "";
		for (int i=0; i<ItemsEquiped.Length; i++) {
			data += ItemsEquiped [i].Index + ",";
			active += ItemsEquiped [i].Active + ",";
		}
		return data + "|" + active;
	}
	
	// update inventory parse all items from text data
	public void ReadItemEquipCharData (string data)
	{
		string[] datapack = data.Split ("|" [0]);
		string[] itemlist = datapack [0].Split ("," [0]);
		string[] activelist = datapack [1].Split ("," [0]);
		
		for (int i=0; i<itemlist.Length; i++) {
			if (itemlist [i] != "" && activelist [i] != "" && i < ItemsEquiped.Length) {
				ItemsEquiped [i] = new ItemSlot ();
				if (activelist [i] == "True") {
					ItemsEquiped [i].Index = int.Parse (itemlist [i]);
					ItemsEquiped [i].Num = 1;
					ItemsEquiped [i].Active = true;
					EquipItem (ItemsEquiped [i]);
				}
				if (activelist [i] == "False") {
					ItemsEquiped [i].Index = int.Parse (itemlist [i]);
					ItemsEquiped [i].Num = 1;
					ItemsEquiped [i].Active = false;
					removeAllChild (ItemEmbedSlot [i]);
				}
			}
		}
	}

	// recieved inventory text data
	[RPC]
	public void InventoryUpdate (string data)
	{
		if (GetItemEquipCharData () != data) {
			ReadItemEquipCharData (data);
			EquipCharDataTemp = data;
		}
	}


	// equip item by ItemSlot object
	public void EquipItem (int slotIndex)
	{
		if (slotIndex > 0 && slotIndex < ItemSlots.Count && slotIndex < ItemSlots.Count)
			EquipItem (ItemSlots [slotIndex]);
	}

	public void EquipItem (ItemSlot slot)
	{

		// checking this item is exit
		if (itemManager == null || slot.Index >= itemManager.Items.Length || slot.Index < 0)
			return;


		// checking this item must contain a prefab object
		var itemCollector = itemManager.Items [slot.Index];
		if (itemCollector.ItemPrefab != null) {
			//Get a Strcture of Embedded item
			var itemget = itemCollector.ItemPrefab.GetComponent<ItemInventory> ();
			if (itemget != null) {

				int slotIndex = itemget.ItemEmbedSlotIndex;
				// clone a prefab from Embedded item Strcture
				if (slotIndex < ItemEmbedSlot.Length && slotIndex >= 0) {
					GameObject item = (GameObject)GameObject.Instantiate (itemCollector.ItemPrefab, ItemEmbedSlot [slotIndex].transform.position, ItemEmbedSlot [slotIndex].transform.rotation);
					// remove old object
					removeAllChild (ItemEmbedSlot [slotIndex]);
					// embedded the prefab together
					item.transform.parent = ItemEmbedSlot [slotIndex].transform;
					item.transform.localScale = itemCollector.ItemPrefab.transform.localScale;
					ItemsEquiped [slotIndex] = slot;
					ItemsEquiped [slotIndex].Active = true;
				}
				//Debug.Log ("Equiped " + itemget);
			}
		}
		//EquipCharDataTemp = GetItemEquipCharData ();
	}
	
	// UnEquipItem by ItemSlot object
	public void UnEquipItem (ItemSlot slot)
	{
		//Debug.Log ("Unequip");
		if (slot.Index < itemManager.Items.Length) {
			//Get a Strcture of Embedded item
			var itemget = itemManager.Items [slot.Index].ItemPrefab.GetComponent<ItemInventory> ();
			// get an index of equipped object
			int slotIndex = itemget.GetComponent<ItemInventory> ().ItemEmbedSlotIndex;
			// remove old object
			if (slotIndex < ItemEmbedSlot.Length && slotIndex >= 0) {
				removeAllChild (ItemEmbedSlot [slotIndex]);
				ItemsEquiped [slotIndex].Active = false;
			}
			//Debug.Log ("UnEquipped " + itemget);
		}
	}
	
	// Using item by ItemSlot object
	public void UseItem (ItemSlot slot)
	{
		if (slot.Index >= itemManager.Items.Length || slot.Index < 0)
			return;
		
		if (slot.Num > 0 && itemManager.Items [slot.Index].ItemPrefab) {
			// the concept is embedded an object into this character and let it work
			var item = (GameObject)Instantiate (itemManager.Items [slot.Index].ItemPrefab, this.transform.position, this.transform.rotation);
			item.transform.parent = this.gameObject.transform;
			RemoveItem (slot, 1);// this item hasbeen used ,remove it from list

		}
	}	
	
	// checking equipped item
	public bool CheckEquiped (ItemSlot slot)
	{
		if (slot.Index >= itemManager.Items.Length || slot.Index < 0)
			return false;
		
		if(!itemManager.Items [slot.Index].ItemPrefab || !itemManager.Items [slot.Index].ItemPrefab.GetComponent<ItemInventory> ())
			return false;
		
		var itemget = itemManager.Items [slot.Index].ItemPrefab.GetComponent<ItemInventory> ();
		if (itemget != null && itemget.GetComponent<ItemInventory> ()) {
			int slotIndex = itemget.GetComponent<ItemInventory> ().ItemEmbedSlotIndex;
			return slotIndex >= 0 && slotIndex < ItemsEquiped.Length && ItemsEquiped [slotIndex] != null && ItemsEquiped [slotIndex].Active && ItemsEquiped [slotIndex].Index == slot.Index;
		} else {
			return false;	
		}
	}
	
	// find index of slot via item index
	public int FindSlotIndexFromItem (int itemIndex)
	{
		int indexres = -1;
		for (int i=0; i<ItemSlots.Count; i++) {
			if (ItemSlots [i].Index == itemIndex) {
				if (ItemSlots [i].Num > 0) {
					indexres = i;
				}
				break;
			}
		}
		return indexres;
	}
	
	// check if an item is exist
	public bool IsExist (int itemIndex)
	{
		bool res = false;
		for (int i=0; i<ItemSlots.Count; i++) {
			if (ItemSlots [i].Index == itemIndex) {
				if (ItemSlots [i].Num > 0) {
					res = true;
				}
				break;
			}
		}
		return res;
	}
	
	// find number of item via item index
	public int FindNumberFromItem (int itemIndex)
	{
		int num = 0;
		for (int i=0; i<ItemSlots.Count; i++) {
			if (ItemSlots [i].Index == itemIndex) {
				num = ItemSlots [i].Num;
				break;
			}
		}
		return num;
	}
	
	// get item collector data vid slot index
	public ItemCollector GetItemFromSlot (int slotIndex)
	{
		if (ItemSlots [slotIndex].Num > 0) {
			return itemManager.Items [ItemSlots [slotIndex].Index];	
		} else {
			return null;	
		}
	}
	
	// launcher projectile from ranged weapon
	public void InventoryRangeOption ()
	{
		for (int i=0; i<ItemsEquiped.Length; i++) {
			if (ItemsEquiped [i] != null && ItemsEquiped [i].Active && ItemEmbedSlot [i] != null) {
				ItemInventory itemIv = itemManager.Items [ItemsEquiped [i].Index].ItemPrefab.GetComponent<ItemInventory> ();
				if (itemIv.Type == WeaponType.Ranged) {
					Vector3 position = ItemEmbedSlot [i].transform.position;
					GameObject missile = itemIv.Missle;
					if (missile) {
						GameObject obj = (GameObject)GameObject.Instantiate (missile, position, Quaternion.identity);	
						obj.transform.forward = this.gameObject.transform.forward;
						if (obj.GetComponent<MissileBase> ()) {
							obj.GetComponent<MissileBase> ().Owner = this.gameObject;
							obj.GetComponent<MissileBase> ().Damage = itemIv.Damage;
						}
					}
				}
			}
		}	
	}
	
	void Update ()
	{	
		IsArmed = false;
		// Calculate all status to Character.  <CharacterStatus.cs>
		if (ItemEmbedSlot.Length <= 0 || itemManager == null || characterSystem == null)
			return;
		ItemCount = ItemSlots.Count;
		int damage = 0;
		int defend = 0;
		// if no any weapon set base of attack speed to 1 
		characterSystem.characterStatus.AttackSpeedInventory = 1;
		
		for (int i=0; i<ItemsEquiped.Length; i++) {

			if (ItemsEquiped [i] != null && ItemsEquiped [i].Active) {
				ItemInventory itemIv = itemManager.Items [ItemsEquiped [i].Index].ItemPrefab.GetComponent<ItemInventory> ();
				damage += itemIv.Damage;
				defend += itemIv.Defend;
				
				if (itemIv.PrimaryWeapon) {
					IsArmed = true;
					if (characterSystem) {
						characterSystem.characterStatus.PrimaryWeaponType = itemIv.Type;
						characterSystem.characterStatus.AttackSpeedInventory = itemIv.SpeedAttack;	
						characterSystem.characterStatus.PrimaryWeaponDistance = itemIv.Distance;
						characterSystem.characterStatus.SoundLaunch = itemIv.SoundLaunch;
						characterSystem.characterAttack.SoundHit = itemIv.SoundHit;
					}
				}
			
			} else {


			}
		}

		characterSystem.characterStatus.DamageInventory = damage;
		characterSystem.characterStatus.DefendInventory = defend;
		
		if ((Network.isClient || Network.isServer) && GetComponent<NetworkView>()) {
			if (GetComponent<NetworkView>().isMine) {
				
				GetComponent<NetworkView>().RPC ("InventoryUpdate", RPCMode.Others, GetItemEquipCharData ());
			}
		}
	}


}




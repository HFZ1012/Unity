using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemRenderer : Frame
{
	
	private ItemManager itemManage;
	private Vector2 scrollPosition;

	public override void Inz (Vector2 position, PlayerCharacterUI ui)
	{
		itemManage = (ItemManager)UnityEngine.GameObject.FindObjectOfType (typeof(ItemManager));
		base.Inz (position, ui);
	}
	
	public void Draw (List<ItemSlot> Items, CharacterInventory characterInventory, ItemRenderMode renderMode, string headertext)
	{
		if (Show && Items != null) {
			
			GUI.BeginGroup (new Rect (Position.x, Position.y, 300, 380));
			GUI.Box (new Rect (0, 0, 300, 380), "");
			
			if (GUI.Button (new Rect (190, 330, 100, 40), "Close")) {
				Show = false;
			}	
			
			GUI.skin.label.normal.textColor = Color.black;
			GUI.skin.label.fontSize = 17;
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			GUI.Label (new Rect (20, 340, 250, 40),"$ "+characterInventory.Money.ToString ("n0"));
			
			
			scrollPosition = GUI.BeginScrollView (new Rect (0, 40, 300, 290), scrollPosition, new Rect (0, 50, 280, Items.Count * 60));
			int num = 0;
			for (int i=0; i<Items.Count; i++) {
				if(Items [i]!=null && Items [i].Index < itemManage.Items.Length && Items [i].Index>=0){
					DrawItemBoxDetail (i, Items [i], new Vector2 (0, (num * 60) + 50), characterInventory, renderMode);
					num+=1;
				}
			}
			
			GUI.EndScrollView ();
			GUI.EndGroup ();
			
			if (GUI.Button (new Rect (Position.x-5, Position.y-2, 310, 40), headertext)) {
				OnDraging ();
			}
			
			
			
		}
	}
	
	public void DrawItemBoxDetail (int indexSlot, ItemSlot itemslot, Vector2 position, CharacterInventory characterInventory, ItemRenderMode renderMode)
	{
		if (itemslot != null) {
			var item = itemManage.Items [itemslot.Index];
			GUI.skin.label.normal.textColor = Color.white;
			//GUI.Box(new Rect(10 + position.x,10 + position.y,50,50),"");	
			if (GUI.Button (new Rect (10 + position.x, 10 + position.y, 50, 50), item.Icon)) {
				if (renderMode == ItemRenderMode.Player) {
					PlayerUI.shotcutRenderer.AddShotCut (indexSlot, 0, 1);	
				}
			}
			
			if (itemslot.Num > 0) {
				GUI.skin.label.fontSize = 16;
				GUI.skin.label.alignment = TextAnchor.UpperLeft;
				GUI.Label (new Rect (14 + position.x, 14 + position.y, 30, 30), itemslot.Num.ToString ());
			}
			GUI.skin.label.fontSize = 16;
			GUI.skin.label.alignment = TextAnchor.MiddleLeft;
			GUI.skin.label.normal.textColor = Color.black;
			GUI.Label (new Rect (position.x + 70, position.y, 100, 60), item.Name);
			
			if (!characterInventory)
				return;
			
			switch (renderMode) {
			case ItemRenderMode.Buy:
				if (GUI.Button (new Rect (200 + position.x, position.y + 10, 80, 30), "- " + item.Price + "$")) {
					if (characterInventory.Money >= item.Price) {
						characterInventory.AddItem (itemslot.Index, 1);
						characterInventory.Money -= item.Price;
					}
				}
				break;
			case ItemRenderMode.Sell:
				if (GUI.Button (new Rect (200 + position.x, position.y + 10, 80, 30), "+ " + item.Price + "$")) {
					characterInventory.RemoveItem (itemslot, 1);
					characterInventory.Money += item.Price;
				}
				break;
			case ItemRenderMode.Player:
				
				switch (item.ItemType) {
				case ItemType.Weapon:
					if (characterInventory.CheckEquiped (itemslot)) {
						if (GUI.Button (new Rect (200 + position.x, position.y + 10, 80, 30), "Remove")) {
							characterInventory.UnEquipItem (itemslot);
						}
					} else {
						if (GUI.Button (new Rect (200 + position.x, position.y + 10, 80, 30), "Wear")) {
							characterInventory.EquipItem (itemslot);
						}
					}
					break;
				case ItemType.Edible:
					if (GUI.Button (new Rect (200 + position.x, position.y + 10, 80, 30), "Use")) {
						characterInventory.UseItem (itemslot);
					}
					break;
				}
				break;
			}
		}
	}
}

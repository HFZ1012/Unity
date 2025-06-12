/// <summary>
/// Item slot.
/// Structure of Items Collector Lists
/// </summary>

using UnityEngine;
using System.Collections;
[System.Serializable]
public class ItemSlot{
	public int Index;
	public int Num;
	public bool Active;
	
	public ItemSlot(){
		Index = 0;
		Num = 0;
	}
}

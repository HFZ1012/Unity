/// <summary>
/// Locked chest. add this scrip to the chest player will need a item key to open it
/// </summary>
using UnityEngine;
using System.Collections;

public class LockedChest : DamageManager
{
	
	public int KeyItem;
	public bool RemoveItemKey = true;
	public bool RemoveChest = true;
	public bool Locked = true;
	public string OpenAnimationName = "Open";
	public GameObject[] ItemDropAfterDead;
	public int ItemLifeTime = 10;
	public float ChestTimeRemove = 4;
	public AudioClip SoundOpen;
	public AudioClip SoundActive;
	public AudioClip SoundLocked;
	
	private bool actived;
	
	void Start ()
	{
	
	}

	public void OpenChest ()
	{
		// Play chest open sound
		if (SoundOpen != null) {
			AudioSource.PlayClipAtPoint (SoundOpen, this.transform.position);
		}
		// Play animation "Open chest" if animation is included.
		if (GetComponent<Animation>() != null && GetComponent<Animation>() [OpenAnimationName] != null) {
			GetComponent<Animation>().PlayQueued (OpenAnimationName);
		}
		
		if (ItemDropAfterDead != null && ItemDropAfterDead.Length > 0) {
			// Drop item and adding some force
			int randomindex = Random.Range (0, ItemDropAfterDead.Length);
			if (ItemDropAfterDead [randomindex] != null) {
				GameObject item = (GameObject)Instantiate (ItemDropAfterDead [randomindex], this.gameObject.transform.position + Vector3.up * 2, this.gameObject.transform.rotation);
				if (item.GetComponent<Rigidbody>()) {
					item.GetComponent<Rigidbody>().AddForce ((-this.transform.forward + Vector3.up) * 100);
					item.GetComponent<Rigidbody>().AddTorque ((-this.transform.forward + Vector3.up) * 100);	
				}
				GameObject.Destroy (item, ItemLifeTime);
			}
		}
		actived = true;
		if(RemoveChest)
			GameObject.Destroy(this.gameObject,ChestTimeRemove);
	}
	
	public override int ApplayDamage (int damage, Vector3 dirdamge, GameObject attacker)
	{
		if(actived)
			return damage;
		
		// is locked
		if (Locked) {
			// get item inventory from attacket ( Character)
			CharacterInventory characterInv = attacker.GetComponent<CharacterInventory> ();
			
			if (characterInv != null) {
				
				// get index slot in character inventory from KeyItem
				int index = characterInv.FindSlotIndexFromItem (KeyItem);
			
				if (index != -1) {
					// item is exist ?
					var item = characterInv.GetItemFromSlot (index);
					int num = characterInv.ItemSlots [index].Num;
					// item number is more than 0
					if (characterInv.ItemSlots [index].Num > 0) {
						// play sound active;
						if (SoundActive != null)
							AudioSource.PlayClipAtPoint (SoundActive, this.transform.position);
			
						if (RemoveItemKey) {
							// remove item key
							Debug.Log ("Remove");
							characterInv.RemoveItem (KeyItem, 1);
						}
						
						OpenChest ();
						return damage;
					}
			
				}
			}
			// play sound locked;
			if (SoundLocked != null)
				AudioSource.PlayClipAtPoint (SoundLocked, this.transform.position);
			
		} else {
			// is not locked
			OpenChest ();
			
		}
		return damage;
	}

}

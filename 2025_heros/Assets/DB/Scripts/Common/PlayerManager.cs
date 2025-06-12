using UnityEngine;
using System.Collections;
// this script using to notify which a character is Player
[RequireComponent(typeof(PlayerInstance))]
[RequireComponent(typeof(PlayerCharacterUI))]
[RequireComponent(typeof(PlayerQuestManager))]
[RequireComponent(typeof(PlayerSave))]

public class PlayerManager : MonoBehaviour
{
	[HideInInspector]
	public GameObject Player;

	
	void Start ()
	{
		this.GetComponent<PlayerCharacterUI> ().Active = true;
	}
	
	void Awake ()
	{
		Player = this.gameObject;
	}


}

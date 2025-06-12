using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterSystem))]
public class PlayerInstance : MonoBehaviour
{
	public CharacterSystem character;

	void Start ()
	{
		character = this.GetComponent<CharacterSystem> ();
	}
	
}

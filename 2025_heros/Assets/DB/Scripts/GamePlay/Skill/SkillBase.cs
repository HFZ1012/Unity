using UnityEngine;
using System.Collections;

public class SkillBase : MonoBehaviour {
	[HideInInspector]
	public GameObject Owner;
	public int Damage;
	public string[] TagDamage = {"Enemy"};
	
}

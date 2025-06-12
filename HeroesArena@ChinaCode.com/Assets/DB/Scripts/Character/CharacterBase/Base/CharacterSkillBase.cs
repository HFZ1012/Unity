using UnityEngine;
using System.Collections;

public class CharacterSkillBase : MonoBehaviour
{

	public int indexSkill;// Current skill index	
	[HideInInspector]
	public SkillManager skillManage;
	[HideInInspector]
	public bool attackingSkill;
	[HideInInspector]
	public CharacterStatus character;
	[HideInInspector]
	public CharacterAttack characterAttack;
	[HideInInspector]
	public CharacterSystem characterSystem;
	[HideInInspector]
	public float[] cooldownTemp;
	public int SkillPoint;
	
	void Start ()
	{
		Inz ();
	}
	
	public void Inz ()
	{
		
		if (this.gameObject.GetComponent<CharacterStatus> ()) {
			character = this.gameObject.GetComponent<CharacterStatus> ();
		}
		if (this.gameObject.GetComponent<CharacterAttack> ()) {
			characterAttack = this.gameObject.GetComponent<CharacterAttack> ();
		}
		if (this.gameObject.GetComponent<CharacterSystem> ()) {
			characterSystem = this.gameObject.GetComponent<CharacterSystem> ();
		}
		
		skillManage = (SkillManager)GameObject.FindObjectOfType (typeof(SkillManager));
		if(skillManage)
		cooldownTemp = new float[skillManage.Skills.Length];

	}
	
	[RPC]
	public virtual void DeploySkillIndex (int index)
	{
		indexSkill = index;
		DeploySkill ();
	}
	
	[RPC]
	public virtual void DeploySkill ()
	{

	}
	
	public virtual void DeployWithAttacking (int index)
	{
		if (characterSystem)
			characterSystem.Attack ();
		indexSkill = index;
		attackingSkill = true;		
	}
	
	public virtual void DeployWithAttacking ()
	{
		if (characterSystem)
			characterSystem.Attack ();
		attackingSkill = true;
	}
	
	void Update ()
	{
		if (attackingSkill && characterAttack.Activated) {
			//DeploySkill ();
			if(Network.isClient || Network.isServer){
				character.GetComponent<NetworkView>().RPC ("DeploySkill", RPCMode.AllBuffered,null);
			}else{
				DeploySkill ();
			}
			
			attackingSkill = false;
			characterAttack.Activated = false;
		}
	}
}

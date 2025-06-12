/// <summary>
/// Character skill deployer.
/// the skills is reference to Skills in SkillManager
/// </summary>
using UnityEngine;
using System.Collections;

public class CharacterSkillManager : CharacterSkillBase
{

	public int[] SkillIndex;// list of available skills 
	public int[] SkillLevel;// list of skills levels
	[RPC]
	public override void DeploySkill ()
	{
		
		if (skillManage == null)
			return;

		if (cooldownTemp.Length <= 0 || Time.time + cooldownTemp [SkillIndex [indexSkill]] < skillManage.GetCooldown (SkillIndex [indexSkill], SkillLevel [indexSkill]) || Time.time >= skillManage.GetCooldown (SkillIndex [indexSkill], SkillLevel [indexSkill]) + cooldownTemp [SkillIndex [indexSkill]]) {
			// Launch an ojbect sync with Animation Attacking
			if (SkillIndex.Length > 0 && skillManage.Skills [SkillIndex [indexSkill]].SkillLevel != null) {
				
				if (character != null && character.SP >= skillManage.GetManaCost (SkillIndex [indexSkill], SkillLevel [indexSkill])) {
					var skillleveldata = skillManage.GetSkillLevel (SkillIndex [indexSkill], SkillLevel [indexSkill]);
					for (int i=0; i<skillleveldata.Num; i++) {
						var skill = (GameObject)GameObject.Instantiate (skillManage.GetSkillObject (SkillIndex [indexSkill], SkillLevel [indexSkill]), this.transform.position, this.transform.rotation);
						var skillbase = skill.GetComponent<SkillBase> ();
						if (skillbase) {
							skillbase.Owner = this.gameObject;	
							skillbase.Damage = (int)skillleveldata.Damage;
						}
						skill.transform.forward = this.transform.forward + new Vector3((i - (int)(skillleveldata.Num/2.0f)) * (Random.Range(0,10)*0.1f),0,0);
					}
					
					character.SP -= skillManage.GetManaCost (SkillIndex [indexSkill], SkillLevel [indexSkill]);
				}
				
				
				if (cooldownTemp.Length > 0) {
					cooldownTemp [SkillIndex [indexSkill]] = Time.time;
				}
			}
		}
		base.DeploySkill ();
	}
}

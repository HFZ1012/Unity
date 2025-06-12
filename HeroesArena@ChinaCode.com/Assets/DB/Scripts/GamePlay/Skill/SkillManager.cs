using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour {

	public SkillData[] Skills;
	
	void Start(){
		
	}
	public int GetManaCost(int skillIndex,int level){
		if(Skills[skillIndex].SkillLevel.Length<=0)
			return 0;
		
		if(level-1>=Skills[skillIndex].SkillLevel.Length){
			return Skills[skillIndex].SkillLevel[Skills[skillIndex].SkillLevel.Length-1].ManaCost;
		}
		return Skills[skillIndex].SkillLevel[level-1].ManaCost;
	}
	
	
	public float GetCooldown(int skillIndex,int level){
		if(Skills[skillIndex].SkillLevel.Length<=0)
			return 0;
		
		if(level-1>=Skills[skillIndex].SkillLevel.Length){
			return Skills[skillIndex].SkillLevel[Skills[skillIndex].SkillLevel.Length-1].CoolDown;
		}
		
		return Skills[skillIndex].SkillLevel[level-1].CoolDown;
	}
	
	
	public GameObject GetSkillObject(int skillIndex,int level){
		
		if(Skills[skillIndex].SkillLevel.Length<=0)
			return null;
		
		if(level-1>=Skills[skillIndex].SkillLevel.Length){
			return Skills[skillIndex].SkillLevel[Skills[skillIndex].SkillLevel.Length-1].SkillObject;
		}
		return Skills[skillIndex].SkillLevel[level-1].SkillObject;
	}
	
	public SkillLevel GetSkillLevel(int skillIndex,int level){
		if(Skills[skillIndex].SkillLevel.Length<=0)
			return null;
		
		if(level-1>=Skills[skillIndex].SkillLevel.Length){
			return Skills[skillIndex].SkillLevel[Skills[skillIndex].SkillLevel.Length-1];
		}
		return Skills[skillIndex].SkillLevel[level-1];
	}
}

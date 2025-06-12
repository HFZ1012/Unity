using UnityEngine;
using System.Collections;

[System.Serializable]
public class SkillData{
	
	public Texture2D SkillIcon;
	public string SkillName = "Skill Name";
	public string Descrtiption = "Description";
	public int Level = 1;
	public int LevelMax = 1;
	public SkillLevel[] SkillLevel;
	
	public SkillData(int levelmax){
		Level = 1;
		LevelMax = levelmax;
		SkillLevel = new SkillLevel[levelmax];
	}
	
}

[System.Serializable]

public class SkillLevel{
	public int ManaCost = 2;
	public float CoolDown;
	public int Damage = 10;
	public int Num = 1;
	public GameObject SkillObject;
}
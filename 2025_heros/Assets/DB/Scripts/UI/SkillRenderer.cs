﻿using UnityEngine;
using System.Collections;

public class SkillRenderer : Frame
{

	private SkillManager skillManage;
	private Vector2 scrollPosition;
	
	public override void Inz (Vector2 position, PlayerCharacterUI ui)
	{
		skillManage = (SkillManager)UnityEngine.GameObject.FindObjectOfType (typeof(SkillManager));
		base.Inz (position, ui);
	}
	
	public void Draw (CharacterSkillManager characterSkill)
	{
		if (Show && characterSkill != null && characterSkill.SkillIndex.Length > 0) {
			GUI.BeginGroup (new Rect (Position.x, Position.y, 300, 380));
			GUI.Box (new Rect (0, 0, 300, 380), "");
			
			if (GUI.Button (new Rect (190, 330, 100, 40), "Close")) {
				Show = false;
			}	
		
			GUI.skin.label.normal.textColor = Color.black;
			GUI.skin.label.fontSize = 17;
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			GUI.Label (new Rect (20, 340, 250, 40), "Skill Point " + characterSkill.SkillPoint.ToString ());
			
			scrollPosition = GUI.BeginScrollView (new Rect (0, 40, 300, 290), scrollPosition, new Rect (0, 50, 280, characterSkill.SkillIndex.Length * 60));
			for (int i=0; i<characterSkill.SkillIndex.Length; i++) {
				DrowSkill (i, i, new Vector2 (0, (i * 60) + 50), characterSkill);
			}
			
			GUI.EndScrollView ();
			GUI.EndGroup ();
			if (GUI.Button (new Rect (Position.x - 5, Position.y - 2, 310, 40), "Skills")) {
				OnDraging ();
			}
		}
	}
	
	public void DrowSkill (int indexSlot, int indexSkill, Vector2 position, CharacterSkillManager characterSkill)
	{
		if (!skillManage)
			return;
		
		if (!characterSkill)
			return;
		
		if (indexSkill < characterSkill.SkillIndex.Length && characterSkill.SkillIndex [indexSkill] < skillManage.Skills.Length) {
			if (GUI.Button (new Rect (10 + position.x, 10 + position.y, 50, 50), skillManage.Skills [characterSkill.SkillIndex [indexSkill]].SkillIcon)) {
				PlayerUI.shotcutRenderer.AddShotCut (indexSkill, 1, 0.1f);	
			}
			
			float cooldown = 0;
			if (characterSkill.cooldownTemp.Length > 0) {
				cooldown = ((skillManage.GetCooldown (characterSkill.SkillIndex [indexSkill], characterSkill.SkillLevel [indexSkill]) + characterSkill.cooldownTemp [characterSkill.SkillIndex [indexSkill]]) - Time.time);
			}
			GUI.skin.label.fontSize = 16;
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			if (cooldown > 0) {
				GUI.skin.label.normal.textColor = Color.red;
				GUI.Label (new Rect (14 + position.x, 14 + position.y, 50, 30), cooldown.ToString ("f1") + " s.");
			} else {
				GUI.skin.label.normal.textColor = Color.white;
				GUI.Label (new Rect (14 + position.x, 14 + position.y, 30, 30), characterSkill.SkillLevel [indexSkill].ToString ());
			}
		
			GUI.skin.label.normal.textColor = Color.black;
			GUI.skin.label.alignment = TextAnchor.MiddleLeft;
			GUI.Label (new Rect (position.x + 70, position.y, 100, 60), skillManage.Skills [characterSkill.SkillIndex [indexSkill]].SkillName);
			GUI.skin.label.normal.textColor = new Color (0.1f, 0.5f, 1.0f, 1);
			GUI.Label (new Rect (position.x + 70, position.y + 15, 100, 60), "Mana " + skillManage.GetManaCost (characterSkill.SkillIndex [indexSkill], characterSkill.SkillLevel [indexSkill]).ToString ());
			GUI.skin.label.normal.textColor = new Color (0.5f, 0.5f, 0.5f, 1);
			GUI.Label (new Rect (position.x + 150, position.y + 15, 100, 60), "CD " + skillManage.GetCooldown (characterSkill.SkillIndex [indexSkill], characterSkill.SkillLevel [indexSkill]).ToString () + " s.");
			
			
			if (characterSkill.SkillPoint > 0) {
				if (GUI.Button (new Rect (240 + position.x, position.y + 10, 50, 30), "Up")) {
					if (characterSkill.SkillLevel [indexSkill] < skillManage.Skills [characterSkill.SkillIndex [indexSkill]].LevelMax) {
						if (characterSkill.SkillPoint > 0) {
							characterSkill.SkillLevel [indexSkill] += 1;
							characterSkill.SkillPoint -= 1;
						}
					}
				}
			}
		}
	}
}

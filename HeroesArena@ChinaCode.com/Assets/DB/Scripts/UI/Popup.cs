﻿using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour
{

	public GUISkin skin;
	public Texture2D bg;
	public string Text = "";
	public bool Active;
	
	void Start ()
	{
		StyleManager StyleManage = (StyleManager)GameObject.FindObjectOfType (typeof(StyleManager));
		if (StyleManage)
			skin = StyleManage.GetSkin (0);
	}
	
	
	public void ShowPopup(string text){
		Active = true;
		Text = text;
	}
	
	
	void OnGUI ()
	{
		
		
		if (skin)
			GUI.skin = skin;
		GUI.depth = 1;
		if (Active) {
			if (bg)
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bg);
			GUI.BeginGroup (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 150, 400, 300));
			GUI.Box (new Rect (0, 0, 400, 300), "");
			if (GUI.Button (new Rect (100, 230, 200, 50), "Close")) {
				Active = false;
			}
		
			GUI.skin.label.fontSize = 20;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.normal.textColor = Color.black;	
			GUI.Label (new Rect (20, 20, 360, 200), Text);

			GUI.EndGroup ();
		}
		GUI.depth = 0;
	}
}

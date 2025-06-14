﻿// Chat Log manager

using UnityEngine;
using System.Collections;

public class ChatLog : MonoBehaviour
{
	private MultiplayerManager multiplayerManage;
	public string Log;
	public Color TextColor = Color.white;
	public bool ActiveChat;
	public float ShowTextDuration = 5;
	float timeTemp;
	
	void Start ()
	{
		multiplayerManage = (MultiplayerManager)GameObject.FindObjectOfType (typeof(MultiplayerManager));
	}
	
	public void AddLog (string text)
	{
		if (Network.isClient || Network.isServer) {
			if (GetComponent<NetworkView>())
				GetComponent<NetworkView>().RPC ("SendChatMessage", RPCMode.All, text);
		}
	
	}

	[RPC]
	void SendChatMessage (string text)
	{
		Log += "\n" + text;
		timeTemp = Time.time;
		showLog = true;
	}

	bool showLog = false;

	void Update ()
	{
		if (!multiplayerManage)
			return;
		
		if (Input.GetKeyDown (KeyCode.Return)) {
			
			ActiveChat = !ActiveChat;
			if (ActiveChat) {
				timeTemp = Time.time;
				showLog = true;
			}
		}
		if (showLog) {
			if (Time.time >= timeTemp + ShowTextDuration) {
				showLog = false;	
			}
		}
	
	}

	public void Clear ()
	{
		Log = string.Empty;
	}

	string chattext = "";

	void OnGUI ()
	{
		if (!multiplayerManage || !multiplayerManage.IsPlaying)
			return;
		
		GUI.skin.label.fontSize = 17;
		GUI.skin.label.normal.textColor = TextColor;
		GUI.skin.label.alignment = TextAnchor.LowerLeft;
		
		if (showLog)
			GUI.Label (new Rect (10, 10, Screen.width, 200), Log);
		
		if (ActiveChat) {
			timeTemp = Time.time;
			GUI.SetNextControlName ("Chattext");
			chattext = GUI.TextField (new Rect (10, 210, 200, 20), chattext);
			
			if (Event.current != null && Event.current.keyCode == KeyCode.Return) {
				if (chattext != string.Empty) {
					AddLog ("<color=yellow>" + PlayerPrefs.GetString ("PlayerTemp") + " : </color>" + chattext);
					ActiveChat = false;
					chattext = string.Empty;
				}
			}
			GUI.FocusControl ("Chattext");
		}
		
	}
}

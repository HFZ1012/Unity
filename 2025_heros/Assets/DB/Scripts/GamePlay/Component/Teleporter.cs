using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	
	public GUISkin skin;
	public string DoorName = "";
	public string SceneNameToGo = "";
	public string DoorID = "D1";
	public Vector3 SpawnOffset = Vector3.zero;
	public bool ShowGUI = true;
	
	
	[HideInInspector]
	public bool entering = false;
	[HideInInspector]
	public GameObject player;

	
	void Start(){
	}
	
	
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.GetComponent<PlayerManager>()){
			entering = true;
			player = collider.gameObject;
		}
	}
		
		
	public void Enter(){
		if(player){
			if(SceneNameToGo!=""){
				PlayerManager playerManage = (PlayerManager)GameObject.FindObjectOfType(typeof(PlayerManager));
				BlackFade fader = (BlackFade)GameObject.FindObjectOfType(typeof(BlackFade));
				
				if(playerManage){

					if(fader)
					fader.Fade(1,0);

					MultiplayerManager mp = (MultiplayerManager)GameObject.FindObjectOfType (typeof(MultiplayerManager));
					if (mp) {
						mp.StartLoadLevel(SceneNameToGo,DoorID);
					}
				}
			}
		}
	}
	
	void OnGUI(){
		if(skin)
			GUI.skin = skin;	
		
		if(!entering || !player)
			return;
		
		if(Vector3.Distance(player.transform.position,this.transform.position)>3){
			entering = false;	
		}
		
		if(ShowGUI){
			Vector3 screenPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position + Vector3.up * 2);	
		
			if(GUI.Button(new Rect(screenPos.x - 75,Screen.height - screenPos.y,150,30),"Enter - "+DoorName)){
				Enter();
			}
		}
		
	}
}

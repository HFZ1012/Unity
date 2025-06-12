/// <summary>
/// Teleporter hit enter. using as teleporter with out GUI click
/// </summary>
using UnityEngine;
using System.Collections;

public class TeleporterHitEnter : Teleporter {


	void Start(){
	}
	
	void Update(){
		if(base.entering){
			Enter();	
		}
	}


}

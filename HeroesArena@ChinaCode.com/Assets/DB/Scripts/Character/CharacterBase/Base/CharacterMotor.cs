using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class CharacterMotor : MonoBehaviour
{
	public float GravityMult = 1;
	public float Slip = 10;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 targetDirection = Vector3.zero;
	private float fallvelocity = 0;
	public CharacterController controller;
	public Animation hero;
	
	void Awake ()
	{
		controller = GetComponent<CharacterController> ();
	}

	void Update ()
	{
		if(!hero.IsPlaying("atack")){
		moveDirection = Vector3.Lerp(moveDirection,targetDirection,Time.deltaTime * Slip);
		moveDirection.y = fallvelocity;

		controller.Move (moveDirection * Time.deltaTime);
		
	
		if(controller.isGrounded){
			fallvelocity = 0;
		}else{
			fallvelocity -= 90 * GravityMult * Time.deltaTime;
		}
		}
	}

	public void Jump (float jumpSpeed)
	{
		fallvelocity = jumpSpeed;
	}

	public void Move (Vector3 dir)
	{
		if(controller){
			if (controller.isGrounded) {
				targetDirection = dir;
			}
		}
	}
	public void Stop(){
		moveDirection = Vector3.zero;
		targetDirection = Vector3.zero;
	}
}


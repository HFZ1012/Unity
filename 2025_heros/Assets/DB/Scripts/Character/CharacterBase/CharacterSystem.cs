using UnityEngine;
using System.Linq;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterMotor))]
[RequireComponent(typeof(CharacterStatus))]
[RequireComponent(typeof(CharacterAttack))]
[RequireComponent(typeof(CharacterInventory))]
[RequireComponent(typeof(CharacterSkillManager))]

public class CharacterSystem : MonoBehaviour
{
	[HideInInspector]
	public CharacterStatus characterStatus;
	[HideInInspector]
	public CharacterAttack characterAttack;
	[HideInInspector]
	public CharacterInventory characterInventory;
	[HideInInspector]
	public CharacterSkillManager characterSkill;
	[HideInInspector]
	public CharacterMotor motor;
	public float MoveMagnitude = 0.05f;
	public float Speed = 1; // Move speed
	public float SpeedMultWhileAttack = 0.5f; // Move speed while attaking
	public float SpeedAttack = 0.5f; // Attack speed
	[HideInInspector]
	public float speedAttack = 0;
	public float TurnSpeed = 10; // turning speed
	public float SpeedJump = 20.0f;
	public string[] TargetTag = {"Enemy"};
	public AttackAnimation[] AttackAnimations;
	public string[] ComboAttackLists;// list of combo set
	public int ComboType; // type of attacking
	
	public string PoseHit = "Hit";// pose animation when character got hit
	public string PoseIdle = "Idle";
	public string PoseRun = "Run";
	public bool IsHero;

	//private variable

	private bool diddamaged;
	private int attackStep = 0;
	private string[] comboList;
	private int attackStack;
	private float attackStackTimeTemp;
	private float speedMoveMult;
	private float frozetime;
	private bool hited;
	private bool attacking;
	public bool Mecanim = false;
	public bool IsDead;
	private Animator animator;
	public bool DontDestroy = true;
	
	void Awake ()
	{
		// instancing all components.
		motor = gameObject.GetComponent<CharacterMotor> ();
		characterStatus = gameObject.GetComponent<CharacterStatus> ();
		characterAttack = gameObject.GetComponent<CharacterAttack> ();
		characterInventory = gameObject.GetComponent<CharacterInventory> ();
		characterSkill = gameObject.GetComponent<CharacterSkillManager> ();
		
		if (GetComponent<NetworkView>()) {
			GetComponent<NetworkView>().stateSynchronization = NetworkStateSynchronization.Off;
			GetComponent<NetworkView>().observed = null;
		}

	}
	
	void Start ()
	{
		// Play pose Idle first
		if (Mecanim) {
			this.gameObject.AddComponent<Animator> ();
			animator = this.gameObject.GetComponent<Animator> ();
			animator.applyRootMotion = false;
		} else {
			if (this.gameObject.GetComponent<Animation>() != null) {
				gameObject.GetComponent<Animation>().CrossFade (PoseIdle);
			}
		}

		attacking = false;
		speedMoveMult = 1;
		
		if (DontDestroy)
			DontDestroyOnLoad (this.gameObject);
		
	}

	void Update ()
	{
		if (Time.time > attackStackTimeTemp + 0.5f) {
			attackStack = 0;	
		}
		attacking = false;
		if (ComboAttackLists.Length <= 0 || ComboType >= ComboAttackLists.Length) {// if have no combo list
			return;
		}

		// Animation combo system
		comboList = ComboAttackLists [ComboType].Split ("," [0]);// Get list of animation index from combolists split by ComboType
		if (Mecanim) {
			if (animator.GetInteger ("State") == 2) {
				if (comboList.Length > attackStep) {
					animator.speed = speedAttack + SpeedAttack;
					
					AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo (0);
					
					if (stateinfo.IsTag ("Attack")) {
						attacking = true;
						int poseIndex = int.Parse (comboList [attackStep]);// Read index of current animation from combo array
						if (stateinfo.normalizedTime >= 0.1f) {
							// set attacking to True when time of attack animation is running to 10% of animation
							
						}
//						Debug.Log(this.gameObject.name+"  "+stateinfo.normalizedTime +"/"+ AttackAnimations [poseIndex].AttackTime);
							
						if (stateinfo.normalizedTime >= AttackAnimations [poseIndex].AttackTime) {
							// if the time of attack animation is running to marking point (AttackAnimations[poseIndex].AttackTime) 
							// calling CharacterAttack.cs to push a damage out
							if (!diddamaged) {
								// push a damage out
								diddamaged = true;
								this.gameObject.GetComponent<CharacterAttack> ().DoAttack (); 
								
							}
						}
						if (stateinfo.normalizedTime > 0.9f) {
							animator.ForceStateNormalizedTime (0);
							// if the time of attack animation is running to 80% of animation. It's should be Finish this pose.
							// set State in AnimationControl ot Idle state
							animator.SetInteger ("State", 0);
							diddamaged = false;
							attacking = false;
							attackStep += 1;
							if (attackStack > 1) {
								// continue next attack pose if action is stacked
								fightAnimation ();	
							} else {
								// if action is done stop attacking
								if (attackStep >= comboList.Length) {
									// finish combo and reset to idle pose
									resetCombo ();
								}	
							}
							// reset character damage system
							this.gameObject.GetComponent<CharacterAttack> ().StartDamage ();
						}
					}
				}
			}
		} else {
			if (comboList.Length > attackStep) {
				int poseIndex = int.Parse (comboList [attackStep]);// Read index of current animation from combo array
				
				// Make sure those animations is exist.
				if (poseIndex < AttackAnimations.Length && (this.gameObject.GetComponent<Animation>() [AttackAnimations [poseIndex].AttackName] || AttackAnimations [poseIndex].Motion)) {	
					
					// get animation state
					AnimationState attackState;
					if (AttackAnimations [poseIndex].Motion) {
						attackState = this.gameObject.GetComponent<Animation>() [AttackAnimations [poseIndex].Motion.name];
					} else {
						attackState = this.gameObject.GetComponent<Animation>() [AttackAnimations [poseIndex].AttackName];
					}
					
					if (GetComponent<Animation>().clip.name == AttackAnimations [poseIndex].AttackName || GetComponent<Animation>().clip == AttackAnimations [poseIndex].Motion) {
						if (GetComponent<Animation>().IsPlaying (GetComponent<Animation>().clip.name)) {
							attackState.layer = 2;
							attackState.speed = speedAttack + SpeedAttack;
							attacking = true;
	
							if (attackState.time >= AttackAnimations [poseIndex].AttackTime) {
								// if the time of attack animation is running to marking point (AttackAnimations[poseIndex].AttackTime) 
								// calling CharacterAttack.cs to push a damage out
								if (!diddamaged) {
									// push a damage out
									diddamaged = true;
									this.gameObject.GetComponent<CharacterAttack> ().DoAttack (); 
						
								}
							}
					
							if (attackState.normalizedTime >= 0.9f) {
								// if the time of attack animation is running to 90% of animation. It's should be Finish this pose.
							
								diddamaged = false;
								attacking = false;
								attackStep += 1;
								attackState.normalizedTime = 0;
							
								if (attackStack > 1) {
									// continue next attack pose if action is stacked
									fightAnimation ();	
								} else {
									// if action is done stop attacking
									this.gameObject.GetComponent<Animation>().Stop ();
									if (attackStep >= comboList.Length) {
										// finish combo and reset to idle pose
										resetCombo ();
									}	
								}
								// reset character damage system
								this.gameObject.GetComponent<CharacterAttack> ().StartDamage ();
							}
						}
					}
				}
			}
		}
		// restore to normal speed
		speedMoveMult = Mathf.Lerp (speedMoveMult, 1, Time.deltaTime * 100);
		
		if (hited) {// Freeze when got hit
			if (frozetime > 0.0f) {
				frozetime -= Time.deltaTime;	
			} else {
				hited = false;
				if (Mecanim) {
					// set State in AnimationControl ot Idle state
					animator.SetInteger ("State", 0);
				} else {
					if (this.gameObject.GetComponent<Animation>() [PoseIdle])
						this.gameObject.GetComponent<Animation>().Play (PoseIdle);
				}
			}
		}
		if ((Network.isClient || Network.isServer) && GetComponent<NetworkView>()) {
			if (GetComponent<NetworkView>().isMine) {
				GetComponent<NetworkView>().RPC ("MoveToPositionRotation", RPCMode.Others, this.transform.position, this.transform.rotation, 1.0f, motor.controller.velocity.magnitude);
			}
		}
	}

	public void GotHit (float time)
	{
		if (!IsHero) {
			if (Mecanim) {
				// set State in AnimationControl ot Hit state
				animator.SetInteger ("State", 3);
			} else {
				//if (this.gameObject.GetComponent<Animation>() [PoseHit]) {
					//this.gameObject.GetComponent<Animation>().Play (PoseHit, PlayMode.StopAll);
				//}
			}
			frozetime = time * Time.deltaTime;// froze time when got hit
			hited = true;
				
		}
	}
	
	private void resetCombo ()
	{
		attackStep = 0;
		attackStack = 0;
		attacking = false;
	}
	
	private void fightAnimation ()
	{
		if (comboList != null && attackStep >= comboList.Length) {
			resetCombo ();	
		}

		
		if (comboList != null && comboList.Length > 0) {
			int poseIndex = int.Parse (comboList [attackStep]);
			if (poseIndex < AttackAnimations.Length) {// checking poseIndex is must in the AttackAnimations list.
				if (this.gameObject.GetComponent<CharacterAttack> ()) {
					// Play Attack Animation 
					if (Mecanim) {
						// set State in AnimationControl ot Attack state
						animator.SetInteger ("State", 2);
						animator.SetInteger ("AttackType", ComboType);
						animator.SetInteger ("AttackIndex", attackStep);
					} else {
						if (this.gameObject.GetComponent<Animation>() [AttackAnimations [poseIndex].AttackName] || (AttackAnimations [poseIndex].Motion && this.gameObject.GetComponent<Animation>() [AttackAnimations [poseIndex].Motion.name])) {
							if (AttackAnimations [poseIndex].Motion) {
								this.gameObject.GetComponent<Animation>().clip = AttackAnimations [poseIndex].Motion;
							} else {
								this.gameObject.GetComponent<Animation>().clip = this.gameObject.GetComponent<Animation>() [AttackAnimations [poseIndex].AttackName].clip;
							}
							this.gameObject.GetComponent<Animation>() [this.gameObject.GetComponent<Animation>().clip.name].blendMode = AttackAnimations [poseIndex].BlendMode;
							this.gameObject.GetComponent<Animation>().Play (PlayMode.StopSameLayer);
						}
						
					}
				}
			}
		}
	}
	
	public void Attack ()
	{	
		if (Network.isServer || Network.isClient) {
			if (GetComponent<NetworkView>()) {
				GetComponent<NetworkView>().RPC ("Attacking", RPCMode.All, null);
			}
		} else {
			Attacking ();
		}
	}

	[RPC]
	public void Attacking ()
	{
		if (!hited) {
			
			if (attackStack < 1 || (Time.time > attackStackTimeTemp + 0.2f && Time.time < attackStackTimeTemp + 1)) {
				attackStack += 1;
				attackStackTimeTemp = Time.time;
			}
			fightAnimation ();
		}	
	}

	public void Moving (Vector3 dir, float mult)
	{
		if (!hited) {
			if (attacking) {
				// Moving slow down when Attacking
				
				speedMoveMult = SpeedMultWhileAttack * mult;
			} else {
				speedMoveMult = 1 * mult;
			}
			moveDirection = dir;
		}
	}

	[RPC]
	public void UpdateTransform (Vector3 position, Quaternion rotation)
	{
		this.transform.position = Vector3.Lerp (this.transform.position, position, 1);
		this.transform.rotation = Quaternion.Lerp (this.transform.rotation, rotation, 1);
	}
	
	Vector3 direction;

	private Vector3 moveDirection {
		get { return direction; }
		set {
			direction = value * speedMoveMult;
			if (direction.magnitude > 0.1f) {
				var newRotation = Quaternion.LookRotation (direction);
				transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * TurnSpeed);
			}
			direction *= Speed * (Vector3.Dot (gameObject.transform.forward, direction) + 1) * 5;
			motor.Move (direction);
			AnimationMove (motor.controller.velocity.magnitude * 0.1f);

				
		}
	}

	[RPC]
	public void MoveToPosition (Vector3 position, float speedMult)
	{
		float speed = Speed * speedMoveMult * 2 * 5 * speedMult;
		Vector3 direction = (position - transform.position);
		Quaternion newRotation = this.transform.rotation;
		direction.y = 0;
		if (direction.magnitude > 0.1f) {
			motor.Move (direction.normalized * speed);
			newRotation = Quaternion.LookRotation (direction);
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * TurnSpeed);
		} else {
			motor.Stop ();
		}

		AnimationMove (motor.controller.velocity.magnitude * 0.1f);

	}

	float magnitudeTemp;

	[RPC]
	public void MoveToPositionRotation (Vector3 position, Quaternion newRotation, float speedMult, float magnitude)
	{
		float speed = Speed * speedMoveMult * 2 * 5 * speedMult;
		Vector3 direction = (position - transform.position);

		if (direction.magnitude > 0.1f) {
			motor.Move (direction.normalized * speed);
		} else {
			motor.Stop ();
		}

		magnitudeTemp = magnitude;
		UpdateTransform (position, newRotation);
		AnimationMove (magnitudeTemp * 0.1f);
		
	}

	[RPC]
	public void Jump ()
	{
		motor.Jump (SpeedJump);	
	}

	void AnimationMove (float magnitude)
	{
		if (magnitude > MoveMagnitude) {
			// Play Runing Animation when moving
			float speedaimation = magnitude * 2;
			if (speedaimation < 1) {
				speedaimation = 1;	
			}
				
			if (Mecanim) {
				if (animator.GetInteger ("State") != 2) {
					// set State in AnimationControl ot Run state
					animator.SetInteger ("State", 1);
					attacking = false;
					animator.speed = speedaimation;
				}
			} else {
				// Speed animation sync to Move Speed
				gameObject.GetComponent<Animation>() [PoseRun].speed = speedaimation;
				gameObject.GetComponent<Animation>().CrossFade (PoseRun);
				attacking = false;
			}
				
			
		} else {
			// Play Idle Animation when stoped
			if (Mecanim) {
				if (animator.GetInteger ("State") != 2) {
					// set State in AnimationControl ot Idle state
					animator.SetInteger ("State", 0);
				}
			} else {
				gameObject.GetComponent<Animation>().CrossFade (PoseIdle);
			}
		}
	}
	
	float pushPower = 2.0f;

	void OnControllerColliderHit (ControllerColliderHit hit)// Character can push an object.
	{
		var body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) {
			return;
		}
		if (hit.moveDirection.y < -0.3) {
			return;
		}
		
		var pushDir = Vector3.Scale (hit.moveDirection, new Vector3 (1, 0, 1));
		body.velocity = pushDir * pushPower;
	}
	
	void OnNetworkLoadedLevel ()
	{
		
	}
	void OnLevelWasLoaded ()
	{
		if(!DontDestroy)
		GameObject.Destroy(this.gameObject);
	}

}
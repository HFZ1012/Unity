/// <summary>
/// AI character controller.
/// Just A basic AI Character controller 
/// will looking for a Target and moving to and Attacking
/// </summary>
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterSystem))]

public class AICharacterController : MonoBehaviour
{
	public string[] TargetTag;
	public GameObject ObjectTarget;
	[HideInInspector]
	public Vector3 PositionTarget;
	private CharacterSystem character;
	[HideInInspector]
	public float DistanceAttack = 2;
	public float DistanceMoveTo = 5;
	public float TurnSpeed = 10.0f;
	public bool BrutalMode;
	public bool RushMode;
	public float PatrolRange = 10;
	private Vector3 positionTemp;
	private int aiTime = 0;
	private int aiState = 0;

	
	void Start ()
	{
		character = gameObject.GetComponent<CharacterSystem> ();
		if (TargetTag.Length > 0)
			character.TargetTag = TargetTag;
		positionTemp = this.transform.position;
		aiState = 0;
	}
	
	void Update ()
	{
		bool offlineMode = (!Network.isServer && !Network.isClient);
		
		if (Network.isServer || offlineMode) {
			var direction = Vector3.zero;
		
			// Random adding status when level up
			if (character.characterStatus.StatusPoint > 0) {
				int d = Random.Range (0, 2);
				switch (d) {
				case 0:
					character.characterStatus.STR += 1;
					break;
				case 1:
					character.characterStatus.AGI += 1;
					break;
				}
				character.characterStatus.StatusPoint -= 1;
			}
		
		
			DistanceAttack = character.characterStatus.PrimaryWeaponDistance;	
		
		
		
			float distance = Vector3.Distance (PositionTarget, this.gameObject.transform.position);
			Quaternion targetRotation = Quaternion.LookRotation (PositionTarget - this.transform.position);
			targetRotation.x = 0;
			targetRotation.z = 0;
			float str = TurnSpeed * Time.time;
		
			transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
		
			direction = this.transform.forward;
		
			if (ObjectTarget!=null) {
				PositionTarget = ObjectTarget.transform.position;
			
				if (aiTime <= 0) {
					aiState = Random.Range (0, 4);
					aiTime = Random.Range (10, 100);
				} else {
					aiTime--;
				}
			
				if (distance <= DistanceAttack) {
					if (aiState == 0 || BrutalMode) {
						character.Attack ();
						if (Random.Range (0, 100) > 80) {
							if (this.gameObject.GetComponent<CharacterSkillBase> ()) {
								this.gameObject.GetComponent<CharacterSkillBase> ().DeployWithAttacking ();	
							}
						}
					}
				} else {
					if (distance <= DistanceMoveTo) {
						transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
					
					} else {
						ObjectTarget = null;
						if (aiState == 0) {
							aiState = 1;
							aiTime = Random.Range (10, 500);
							PositionTarget = positionTemp + new Vector3 (Random.Range (-PatrolRange, PatrolRange), 0, Random.Range (-PatrolRange, PatrolRange));
						}
					}
				}
	
			} else {
	
				float length = float.MaxValue;
				for (int t=0; t<character.TargetTag.Length; t++) {
					GameObject[] targets = (GameObject[])GameObject.FindGameObjectsWithTag (character.TargetTag [t]);
				
					for (int i=0; i<targets.Length; i++) {
						float distancetargets = Vector3.Distance (targets [i].gameObject.transform.position, this.gameObject.transform.position);
						if ((distancetargets <= length && (distancetargets <= DistanceMoveTo || distancetargets <= DistanceAttack || RushMode)) && ObjectTarget != targets [i].gameObject) {
							length = distancetargets;
							ObjectTarget = targets [i].gameObject;
						}
					}
				}
				if (aiState == 0) {
					aiState = 1;
					aiTime = Random.Range (10, 200);
					PositionTarget = positionTemp + new Vector3 (Random.Range (-PatrolRange, PatrolRange), 0, Random.Range (-PatrolRange, PatrolRange));
				}
				if (aiTime <= 0) {
					aiState = Random.Range (0, 4);
					aiTime = Random.Range (10, 200);
				} else {
					aiTime--;
				}
			
			
			}
			if(!offlineMode){
				character.GetComponent<NetworkView>().RPC ("MoveToPosition", RPCMode.All, PositionTarget,1.0f);
			}else{
				character.MoveToPosition (PositionTarget, 1);
			}
		}
	}
}

/// <summary>
/// Player character controller.
/// Player Controller by Keyboard and Mouse
/// </summary>
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class PlayerCharacterController : MonoBehaviour
{
	
	public CharacterSystem character;
	public bool lookingForPlayerManager = true;
	// touch screen controller
	private TouchScreenVal touchScreenMover;
	private TouchScreenVal touchScreenPress;
	
	void Start ()
	{
		//setting touch screen controller. (Specify area of touching and position)
		touchScreenMover = new TouchScreenVal (new Rect (0, 0, Screen.width / 2, Screen.height));
		touchScreenPress = new TouchScreenVal (new Rect (Screen.width / 2, 0, Screen.width / 2, Screen.height));
		
		// get character instance
		if (character == null) {
			if (this.gameObject.GetComponent<CharacterSystem> ()) {
				character = this.gameObject.GetComponent<CharacterSystem> ();
			}
		}
		
		Screen.lockCursor = true;
		FindMainCharacter ();
	}
	
	void FindMainCharacter ()
	{
		if (character == null) {
			PlayerManager player = (PlayerManager)GameObject.FindObjectOfType (typeof(PlayerManager));
			if (player != null && player.GetComponent<CharacterSystem> ()) {
				character = player.gameObject.GetComponent<CharacterSystem> ();
			} else {
				if(!lookingForPlayerManager){
					PlayerInstance playerIns = (PlayerInstance)GameObject.FindObjectOfType (typeof(PlayerInstance));
					if (playerIns != null && playerIns.GetComponent<CharacterSystem> ()) {
						character = playerIns.gameObject.GetComponent<CharacterSystem> ();
					}
				}
			}
		}
	}
	
	void Update ()
	{
		bool offlineMode = (!Network.isServer && !Network.isClient);
		FindMainCharacter ();
		
		if (!character)
			return;
			
		if ((character.GetComponent<NetworkView>() && character.GetComponent<NetworkView>().isMine && (Network.isClient || Network.isServer)) || offlineMode) {
			
	
			#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
			// works only webplayer and desktop devices
			standaloneController();
			#else
			// works only mobile devices
			mobileController ();
			#endif
		}
	}
	
	// mouse and keyboard controller
	void standaloneController ()
	{
		
		var direction = Vector3.zero;
		var forward = Quaternion.AngleAxis (-90, Vector3.up) * Camera.main.transform.right;
		
		direction += forward * Input.GetAxis ("Vertical");
		direction += Camera.main.transform.right * Input.GetAxis ("Horizontal");
			
		var orbit = (OrbitGameObject)FindObjectOfType (typeof(OrbitGameObject));
			
		if (Input.GetButton ("Fire3")) {
			orbit.HoldAim ();
		}
		if (Screen.lockCursor) {	
			if (Input.GetButton ("Fire1")) {
				
				character.Attack ();
			}		
			if (Input.GetButton ("Fire2")) {
				character.Attack ();
				var skillDeployer = character.gameObject.GetComponent<CharacterSkillBase> ();
				if (skillDeployer != null)
					skillDeployer.DeployWithAttacking ();	
			}
				
		}
		
		if (Screen.lockCursor && Input.GetKeyDown (KeyCode.Tab)) {
			Screen.lockCursor = false;	
		}
		if (Screen.lockCursor && Input.GetKeyDown (KeyCode.Space)) {
			character.Jump ();
			
		}
		
		direction.Normalize ();
		character.Moving (direction.normalized, 1);
		
		
		// hide cursor when character move
		if (direction.magnitude > 0) {
			if (!Screen.lockCursor) {
				Screen.lockCursor = true;
			}
		}
	}
	
	// Touchscreen controller function 
	void mobileController ()
	{
		if (!character)
			return;
		
		touchScreenPress.AreaTouch = new Rect (Screen.width / 2, 0, Screen.width / 2, Screen.height / 2);
		if (touchScreenPress.OnTouchPress ()) {
			character.Attack ();	
		}
		touchScreenPress.AreaTouch = new Rect (Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2);
		if (touchScreenPress.OnTouchPress ()) {
			character.Attack ();
			var skillDeployer = character.gameObject.GetComponent<CharacterSkillBase> ();
			if (skillDeployer != null)
				skillDeployer.DeployWithAttacking ();	
		}
		
		
		var direction = Vector3.zero;
		var touchDirection = touchScreenMover.OnTouchDirection ();
		direction.x = touchDirection.x;
		direction.z = touchDirection.y;
		
		character.Moving (direction, 1);

		
	}

	
}


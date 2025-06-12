using UnityEngine;
using System.Collections;

public class MiniMaper : MonoBehaviour
{
	public GameObject MiniMapCamera;
	public Camera GameCamera;
	private GameObject minimaper;
	public GameObject Target;
	public bool lookingForPlayerManager = true;
	public bool LockRotation = true;
	
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (minimaper == null && MiniMapCamera == null) {
			return;
		}
		if (minimaper == null) {
			if (MiniMapCamera)
				minimaper = (GameObject)GameObject.Instantiate (MiniMapCamera.gameObject, this.transform.position, MiniMapCamera.transform.rotation);
		}
		if (GameCamera == null) {
			if (Camera.current)
				GameCamera = Camera.current.GetComponent<Camera>();	
		}
		if (Target == null) {
			if (!lookingForPlayerManager) {
				PlayerInstance characterInstance = (PlayerInstance)FindObjectOfType (typeof(PlayerInstance));
				if (characterInstance) {
					Target = characterInstance.gameObject;	
					return;
				}
			}
			PlayerManager character = (PlayerManager)FindObjectOfType (typeof(PlayerManager));
			if (character) {
				Target = character.gameObject;
				return;
			}
		} else {
			if (minimaper != null)
				minimaper.transform.position = new Vector3 (Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
			
			if (!LockRotation && minimaper != null && GameCamera != null) {
				Quaternion lookat = Quaternion.LookRotation (-(GameCamera.gameObject.transform.position - Target.transform.position).normalized);
				Quaternion rotationTemp = minimaper.transform.rotation;
				rotationTemp.eulerAngles = new Vector3 (rotationTemp.eulerAngles.x, lookat.eulerAngles.y, rotationTemp.eulerAngles.z);
				minimaper.transform.rotation = rotationTemp;
			}
		}
			
	}
}

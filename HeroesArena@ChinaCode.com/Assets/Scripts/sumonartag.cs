using UnityEngine;
using System.Collections;

public class sumonartag : MonoBehaviour {
	public GameObject hero;
	public int pode;
	// Use this for initialization
	void Start () {
	//	StartCoroutine (mudartag ());
	
	}

	// Update is called once per frame
	void Update () {
		pode = MainController.checando;

		if (pode == 1) {
		
			hero.gameObject.tag = "Player";

		
		}
	
	}
}

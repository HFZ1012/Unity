using UnityEngine;
using System.Collections;

public class controledetorre : MonoBehaviour {


	public GameObject arqueiro;
	public GameObject torre_boa;
	public GameObject torre_destruida;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (arqueiro.gameObject == null) {
		
			torre_boa.gameObject.SetActive (false);
			torre_destruida.gameObject.SetActive(true);
		
		} 
	
	}
}

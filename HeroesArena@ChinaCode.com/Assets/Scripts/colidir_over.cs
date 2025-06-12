using UnityEngine;
using System.Collections;

public class colidir_over : MonoBehaviour {
	public int nopode;
	public static bool teste;
	public int pode;
	// Use this for initialization
	void Start () {
		nopode = 2;
	}
	void OnTriggerStay(Collider other) {
		if (other.tag == "sumon") {
			if(pode == 2){
			teste = true;
			
			}else{

				teste = false;
			}
		} 
	}


	// Update is called once per frame
	void Update () {

		pode = MainController.checando;

		if (pode == 1) {
		
			teste = false;
		}
	
	}
}

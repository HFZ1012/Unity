using UnityEngine;
using System.Collections;

public class load_menu1 : MonoBehaviour {
	
	public int select1;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (checar ());
	
		
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(3f);
		
		
		Application.LoadLevel ("menu");
		
		
		
		yield break;
		
	}
	// Update is called once per frame
	void Update () {
		

		
		
	}
}

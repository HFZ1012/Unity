using UnityEngine;
using System.Collections;

public class nonet : MonoBehaviour {
	
	public int select1;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (checar ());
		
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(5f);
		
		
		Application.LoadLevel ("menu");
		
		
		
		yield break;
		
	}
	// Update is called once per frame
	void Update () {
		
		
		
		
	}
}

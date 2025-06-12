using UnityEngine;
using System.Collections;

public class load_battle1 : MonoBehaviour {

	public int select1;

	// Use this for initialization
	void Start () {
		StartCoroutine (checar ());
		select1 = PlayerPrefs.GetInt ("selectarena");
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(3f);


		Application.LoadLevel ("gameplay" + select1.ToString());

			

		yield break;
		
	}
	// Update is called once per frame
	void Update () {

		select1 = PlayerPrefs.GetInt ("selectarena");

	
	}
}

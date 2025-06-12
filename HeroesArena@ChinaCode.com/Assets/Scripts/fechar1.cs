using UnityEngine;
using System.Collections;

public class fechar1 : MonoBehaviour {

	public GameObject estrela;

	public int xp;
	public int info1;
	// Use this for initialization
	void Start () {

		xp = PlayerPrefs.GetInt ("xp");
		StartCoroutine (desligar ());
	
	}
	IEnumerator desligar () {
		
		yield return new WaitForSeconds(2f);
		xp = xp + 3;
		PlayerPrefs.SetInt ("xp", xp);

		StartCoroutine (desligar2 ());
		yield break;
		
	}
	IEnumerator desligar2 () {
		
		yield return new WaitForSeconds(1f);
		
		estrela.gameObject.SetActive (false);

		yield break;
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}

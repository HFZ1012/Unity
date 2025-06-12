using UnityEngine;
using System.Collections;

public class gernciar_arenas : MonoBehaviour {

	public GameObject card1;
	public GameObject card1pb;
	public string valorhero;
	public int valorhero1;
	public int codigo_hero;


	// Use this for initialization
	void Start () {

		StartCoroutine (checar ());

	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.2f);
		if (codigo_hero != 3) {
		
			card1.gameObject.SetActive (true);
			card1pb.gameObject.SetActive (false);
		} else {
			card1pb.gameObject.SetActive (true);
			card1.gameObject.SetActive (false);
		}
		
		
		yield break;
		
	}
	// Update is called once per frame
	void Update () {

		codigo_hero = PlayerPrefs.GetInt ("codigo_hero" + valorhero);

	
	
	}
}

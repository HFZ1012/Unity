using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ger_arena : MonoBehaviour {
	
	public int primeiravez;
	public int hero;
	public Sprite[] cards;
	public Image card;
	public int nova_arena;
	// Use this for initialization
	void Start () {
		nova_arena = PlayerPrefs.GetInt ("nova_arena");
		StartCoroutine (checar ());
		if (nova_arena == 0) {
			
			PlayerPrefs.SetInt("nova_arena", 2);
			
		}


		if (nova_arena == 1) {
		
			PlayerPrefs.SetInt("nova_arena", 2);
		
		}
		if (nova_arena == 3) {
			
			PlayerPrefs.SetInt("nova_arena", 4);
			
		}
		if (nova_arena == 5) {
			
			PlayerPrefs.SetInt("nova_arena", 6);
			
		}
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(5f);
		
		Application.LoadLevel ("menu");
		
		yield break;
		
	}
	// Update is called once per frame
	void Update () {
		hero = PlayerPrefs.GetInt ("nova_arena");
		card.sprite = cards[hero];
		
		
		
	}
}
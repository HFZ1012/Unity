using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class newhero : MonoBehaviour {
	
	public int primeiravez;
	public int hero;
	public Sprite[] cards;
	public Image card;
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
		hero = PlayerPrefs.GetInt ("primeira1");
		card.sprite = cards[hero];
		
		
		
	}
}
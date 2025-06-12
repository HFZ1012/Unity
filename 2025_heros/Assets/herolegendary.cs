using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class herolegendary : MonoBehaviour {
	

	public int hero;
	public Sprite[] cards;
	public Image card;
	// Use this for initialization
	void Start () {
	//	PlayerPrefs.SetInt ("legendary1", 0);
		//PlayerPrefs.SetInt ("slot55", 1);
		//PlayerPrefs.SetInt ("ouro2", 500);
	}
	
	// Update is called once per frame
	void Update () {
		hero = PlayerPrefs.GetInt ("legendary1");
		card.sprite = cards[hero];
		
		
		
	}
}

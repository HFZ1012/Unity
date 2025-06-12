using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class hero_certo : MonoBehaviour {

	public int primeiravez;
	public int hero;
	public Sprite[] cards;
	public Image card;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		hero = PlayerPrefs.GetInt ("primeira1");
		card.sprite = cards[hero];

	
	
	}
}

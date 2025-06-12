using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class newhero2 : MonoBehaviour {
	
	public int primeiravez;
	public int hero;
	public Sprite[] cards;
	public Image card;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("legendary1", 0);
		hero = PlayerPrefs.GetInt ("legendary1");
		StartCoroutine (checar ());
		PlayerPrefs.SetInt ("slot55", 0);
		PlayerPrefs.SetInt ("ouro2", 0);
		if (hero == 0) {
			PlayerPrefs.SetInt ("legendary1", 1);
			if (hero == 0) {
				PlayerPrefs.SetInt ("codigo_hero44", 2);
				PlayerPrefs.SetInt ("hitpoint44", 130);
				PlayerPrefs.SetInt ("damage44", 35);
				
			}
			
		}
		
		if (hero == 1) {
			PlayerPrefs.SetInt ("legendary1", 2);
			if (hero == 0) {
				PlayerPrefs.SetInt ("codigo_hero45", 2);
				PlayerPrefs.SetInt ("hitpoint45", 750);
				PlayerPrefs.SetInt ("damage45", 85);
				
			}
			
		}
		if (hero == 2) {
			PlayerPrefs.SetInt ("legendary1", 3);
			if (hero == 0) {
				PlayerPrefs.SetInt ("codigo_hero49", 2);
				PlayerPrefs.SetInt ("hitpoint49", 190);
				PlayerPrefs.SetInt ("damage49", 70);
				
			}
			
		}
		if (hero == 3) {
			PlayerPrefs.SetInt ("legendary1", 4);
			if (hero == 0) {
				PlayerPrefs.SetInt ("codigo_hero41", 2);
				PlayerPrefs.SetInt ("hitpoint41", 1500);
				PlayerPrefs.SetInt ("damage41", 130);
				
			}
			
		}
		if (hero == 4) {
			PlayerPrefs.SetInt ("legendary1", 5);
			if (hero == 0) {
				PlayerPrefs.SetInt ("codigo_hero40", 2);
				PlayerPrefs.SetInt ("hitpoint40", 3000);
				PlayerPrefs.SetInt ("damage40", 190);
				
			}
			
		}
		if (hero == 5) {
			PlayerPrefs.SetInt ("legendary1", 6);
			if (hero == 0) {
				PlayerPrefs.SetInt ("codigo_hero47", 2);
				PlayerPrefs.SetInt ("hitpoint47", 990);
				PlayerPrefs.SetInt ("damage47", 90);
				
			}
			
		}
		if (hero == 6) {
			PlayerPrefs.SetInt ("legendary1", 7);
			if (hero == 0) {
				PlayerPrefs.SetInt ("codigo_hero48", 2);
				PlayerPrefs.SetInt ("hitpoint48", 1100);
				PlayerPrefs.SetInt ("damage48", 90);
				
			}
			
		}
		if (hero == 7) {
			PlayerPrefs.SetInt ("legendary1", 8);
			if (hero == 0) {
				PlayerPrefs.SetInt ("codigo_hero50", 2);
				PlayerPrefs.SetInt ("hitpoint50", 1500);
				PlayerPrefs.SetInt ("damage50", 100);
				
			}
			
		}
		if (hero == 8) {
			PlayerPrefs.SetInt ("legendary1", 9);
			if (hero == 0) {
				PlayerPrefs.SetInt ("codigo_hero42", 2);
				PlayerPrefs.SetInt ("hitpoint42", 3500);
				PlayerPrefs.SetInt ("damage42", 250);
				
			}
			
		}
		if (hero == 9) {
			PlayerPrefs.SetInt ("legendary1", 10);
			if (hero == 0) {
				PlayerPrefs.SetInt ("codigo_hero46", 2);
				PlayerPrefs.SetInt ("hitpoint46", 2500);
				PlayerPrefs.SetInt ("damage46", 130);
				
			}
			
		}

	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(5f);
		
		Application.LoadLevel ("menu");
	
		
		yield break;
		
	}

	// Update is called once per frame
	void Update () {
		hero = PlayerPrefs.GetInt ("legendary1");
		card.sprite = cards[hero - 1];
		
		
		
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class gerenciar_persongem : MonoBehaviour {

	public Image hero1;
	public string valorhero;
	public int myInt;
	public int numerosoket;
	public int codigo_hero;
	public int nivel;
	public int xp;
	public int maxp;
	public Text valorxp;
	public Text valornivel;
	public Image barra;
	public Slider barraxp;

	// Use this for initialization
	void Start () {

		StartCoroutine (checar ());
		valorhero = hero1.sprite.texture.name.ToString ();
		myInt = int.Parse(valorhero);

	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.2f);
		
		if (nivel == 0) {
		
			nivel = 1;
			PlayerPrefs.SetInt("nivel" + myInt, 1);
		}
		
		
		yield break;
		
	}
	
	// Update is called once per frame
	void Update () {
		barraxp.maxValue = maxp;
		barraxp.value = xp;

		if (myInt == 1) {
			valornivel.color = Color.cyan;
				
		}
		if (myInt == 2) {
			valornivel.color = Color.green;
			
		}
		if (myInt == 3) {
			valornivel.color = Color.green;
			
		}
		if (myInt == 4) {
			valornivel.color = Color.yellow;
			
		}
		if (myInt == 5) {
			valornivel.color = Color.cyan;
			
		}
		if (myInt == 6) {
			valornivel.color = Color.yellow;
			
		}
		if (myInt == 7) {
			valornivel.color = Color.yellow;
			
		}
		if (myInt == 8) {
			valornivel.color = Color.green;
			
		}
		if (myInt == 9) {
			valornivel.color = Color.cyan;
			
		}
		if (myInt == 10) {
			valornivel.color = Color.yellow;
			
		}
		if (myInt == 11) {
			valornivel.color = Color.cyan;
			
		}
		if (myInt == 12) {
			valornivel.color = Color.yellow;
			
		}
		if (myInt == 13) {
			valornivel.color = Color.yellow;
			
		}
		if (myInt == 14) {
			valornivel.color = Color.cyan;
			
		}
		if (myInt == 15) {
			valornivel.color = Color.cyan;
			
		}
		if (myInt == 16) {
			valornivel.color = Color.yellow;
			
		}
		if (myInt == 17) {
			valornivel.color = Color.green;
			
		}
		if (myInt == 18) {
			valornivel.color = Color.green;
			
		}
		if (myInt == 19) {
			valornivel.color = Color.cyan;
			
		}
		if (myInt == 20) {
			valornivel.color = Color.green;
			
		}
		if (myInt == 21) {
			valornivel.color = Color.cyan;
			
		}
		if (myInt == 22) {
			valornivel.color = Color.yellow;
			
		}
		if (myInt == 23) {
			valornivel.color = Color.yellow;
			
		}
		if (myInt == 24) {
			valornivel.color = Color.green;
			
		}
		if (myInt == 25) {
			valornivel.color = Color.cyan;
			
		}
		if (myInt == 26) {
			valornivel.color = Color.green;
			
		}

		xp = PlayerPrefs.GetInt ("xp" + myInt);
		nivel = PlayerPrefs.GetInt ("nivel" + myInt);
		codigo_hero = PlayerPrefs.GetInt ("codigo_hero" + myInt);
		valorxp.text = xp.ToString () + "/" + maxp.ToString ();
		valornivel.text = "Level " + nivel.ToString ();

		if (xp >= maxp) {
		
		
			barra.color = Color.green;
		
		} else {
		
			barra.color = Color.yellow;

		
		}


		if (nivel == 1) {
		
			maxp = 2;
		
		}

		
		if (nivel == 2) {
			
			maxp = 4;
			
		}

		
		if (nivel == 3) {
			
			maxp = 8;
			
		}

		
		if (nivel == 4) {
			
			maxp = 15;
			
		}

		
		if (nivel == 5) {
			
			maxp = 25;
			
		}

		
		if (nivel == 6) {
			
			maxp = 40;
			
		}

		
		if (nivel == 7) {
			
			maxp = 65;
			
		}

		
		if (nivel == 8) {
			
			maxp = 80;
			
		}

		
		if (nivel == 9) {
			
			maxp = 100;
			
		}
		
		if (nivel == 10) {
			
			maxp = 130;
			
		}

		if (nivel == 11) {
			
			maxp = 145;
			
		}

		if (nivel == 12) {
			
			maxp = 200;
			
		}

		if (nivel == 13) {
			
			maxp = 230;
			
		}
		if (nivel == 14) {
			
			maxp = 300;
			
		}



		//PlayerPrefs.SetInt ("sok" + numerosoket, myInt);
		if (codigo_hero != 1) {
			PlayerPrefs.SetInt ("codigo_hero" + myInt, 2);
		}
	
	}
}

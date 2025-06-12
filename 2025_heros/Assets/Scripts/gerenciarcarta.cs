using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class gerenciarcarta : MonoBehaviour {
	public int sok1;
	public int sok2;
	public int sok3;
	public int sok4;
	public int sok5;
	public int sok6;
	public int sok7;
	public int sok8;

	public GameObject hero1;
	public string valorhero;
	public int myInt;
	public int modo1;
	public GameObject ativo;
	public GameObject desativo;
	public GameObject naoencontrado;
	public int codigo_hero;
	public GameObject luz;
	public GameObject botoes;
	public GameObject barra;
	public Animation btn;
	public int fechar;

	public int nivel;
	public int xp;
	public int maxp;
	public Text valorxp;
	public Text valornivel;
	public Image barra1;
	public Slider barraxp;
	public int confirmar1;
	// Use this for initialization
	void Start () {


	//	valorhero = hero1.gameObject.name;
	//	myInt = int.Parse(valorhero);
	

	
		StartCoroutine (checar ());

		codigo_hero = PlayerPrefs.GetInt("codigo_hero" + myInt);

		
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.2f);
	

		if (nivel == 0) {
			
			nivel = 1;
			PlayerPrefs.SetInt("nivel" + myInt, 1);

		}
		if (xp >= maxp) {
			
			
			barra1.color = Color.green;
			
			PlayerPrefs.SetInt("xp" + myInt, maxp);
			
		} else {
			
			barra1.color = Color.yellow;
			
			
		}
		if (codigo_hero == 1) {
			ativo.gameObject.SetActive(true);
			desativo.gameObject.SetActive(false);
			naoencontrado.gameObject.SetActive(false);
		}
		if (codigo_hero == 2) {
			ativo.gameObject.SetActive(false);
			desativo.gameObject.SetActive(true);
			naoencontrado.gameObject.SetActive(false);
		}
		if (codigo_hero == 3) {
			ativo.gameObject.SetActive(false);
			desativo.gameObject.SetActive(false);
			naoencontrado.gameObject.SetActive(true);
		}

		
		
		yield break;
		
	}

	public void carta(){


		PlayerPrefs.SetInt ("modo1", 2);
	
		valorhero = hero1.gameObject.name;
		myInt = int.Parse(valorhero);
		PlayerPrefs.SetInt ("cartaescolhida", myInt);
		btn.GetComponent<Animation>().Play ("diminui");
		botoes.gameObject.SetActive (false);
		barra.gameObject.SetActive (true);
		luz.gameObject.SetActive (false);

	}

	public void open(){
		btn.GetComponent<Animation>().Play ("cresce");
		botoes.gameObject.SetActive (true);
		barra.gameObject.SetActive (false);
		luz.gameObject.SetActive (true);
		StartCoroutine (fechar1 ());
		PlayerPrefs.SetInt("info", myInt);
	
	
		
	}

	IEnumerator fechar1 () {
		
		yield return new WaitForSeconds(8.2f);
		
		btn.GetComponent<Animation>().Play ("diminui");
		botoes.gameObject.SetActive (false);
		barra.gameObject.SetActive (true);
		luz.gameObject.SetActive (false);
		
		
		yield break;
		
	}

	// Update is called once per frame
	void Update () {
	

		if (codigo_hero == 1) {
			ativo.gameObject.SetActive(true);
			desativo.gameObject.SetActive(false);
			naoencontrado.gameObject.SetActive(false);
		}
		if (codigo_hero == 2) {
			ativo.gameObject.SetActive(false);
			desativo.gameObject.SetActive(true);
			naoencontrado.gameObject.SetActive(false);
		}
		if (codigo_hero == 3) {
			ativo.gameObject.SetActive(false);
			desativo.gameObject.SetActive(false);
			naoencontrado.gameObject.SetActive(true);
		}

		if (codigo_hero == 0) {
			ativo.gameObject.SetActive(false);
			desativo.gameObject.SetActive(false);
			naoencontrado.gameObject.SetActive(true);
		}

		sok1 = PlayerPrefs.GetInt("sok1");
		sok2 = PlayerPrefs.GetInt("sok2");
		sok3 = PlayerPrefs.GetInt("sok3");
		sok4 = PlayerPrefs.GetInt("sok4");
		sok5 = PlayerPrefs.GetInt("sok5");
		sok6 = PlayerPrefs.GetInt("sok6");
		sok7 = PlayerPrefs.GetInt("sok7");
		sok8 = PlayerPrefs.GetInt("sok8");

		if (myInt != sok1) {
			if (myInt != sok2) {
				if (myInt != sok3) {
					if (myInt != sok4) {
						if (myInt != sok5) {
							if (myInt != sok6) {
								if (myInt != sok7) {
									if (myInt != sok8) {

										if (codigo_hero != 3) {
											PlayerPrefs.SetInt("codigo_hero" + myInt, 1);

										}

									}
								}
							}
						}
					}
				}
			}
		
		
		}
	
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
		valornivel.text = "Nivel " + nivel.ToString ();
		
		if (xp >= maxp) {
			
			
			barra1.color = Color.green;

			//PlayerPrefs.SetInt("xp" + myInt, maxp);
			
		} else {
			
			barra1.color = Color.yellow;
			
			
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

		//slot = PlayerPrefs.GetInt ("slot");
		modo1 = PlayerPrefs.GetInt("modo1");







	
	}
}

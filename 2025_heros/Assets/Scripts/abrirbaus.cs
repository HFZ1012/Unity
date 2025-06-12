using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class abrirbaus : MonoBehaviour {

	public Image card;
	public Sprite[] cards_1;
	public string valorhero;
	public int myInt;
	public int bonus;
	public int selectpremio;
	public AudioSource abre;
	public AudioSource abre2;
	public GameObject baufechado;
	public GameObject bauaberto;
	public GameObject efei1;
	public int totalpremio;
	public Text totalpremiotx;
	public GameObject brinde;
	public int vitoria;
	public int xphero;
	public int valorbrinde;
	public int valorrecurso;
	public int gold;
	public int gema;
	public int variavel1;

	public Slider barra;
	public int maxp;
	public int nivel;
	public Text namehero;
	public Text type1;
	public Text ganhos;
	public Text xpherotx;
	// Use this for initialization
	void Start () {

		PlayerPrefs.SetInt ("evoluirxp", 2);
		valorbrinde = Random.Range (1, 4);
		valorrecurso = Random.Range (30, 80);
		vitoria = PlayerPrefs.GetInt ("vitoria");
		bonus = 1;
		StartCoroutine(caida());
		if (variavel1 == 1) {
		
			PlayerPrefs.SetInt ("coroas", 0);
		
		}

		if (variavel1 == 2) {
			
			PlayerPrefs.SetFloat ("tempo", 10000);
			
		}

	}
	public void abrir(){

		if (totalpremio > 0) {
			totalpremio = totalpremio - 1;
			bauaberto.gameObject.SetActive (true);
			baufechado.gameObject.SetActive (false);
			StartCoroutine(explo());
			StartCoroutine(explo2());
			abre.GetComponent<AudioSource>().Play();
			abre2.GetComponent<AudioSource>().Play();
		}

	}
	public void abrir2(){
		
		if (totalpremio > 0) {
			StartCoroutine (explo ());
			valorbrinde = Random.Range (1, 4);
			valorrecurso = Random.Range (30, 80);
			bauaberto.gameObject.SetActive (false);
			baufechado.gameObject.SetActive (true);
			selectpremio = Random.Range (1, 6);
			StartCoroutine (checar2 ());
			StartCoroutine (explo2 ());
			brinde.gameObject.SetActive (false);
			abre.GetComponent<AudioSource> ().Play ();
			abre2.GetComponent<AudioSource> ().Play ();
			if (vitoria <= 10) {
				bonus = Random.Range (1, 11);
			}
			if (vitoria <= 25) {
				if (vitoria > 11) {
					bonus = Random.Range (1, 13);
				}
			}
			if (vitoria <= 40) {
				if (vitoria > 13) {
					bonus = Random.Range (1, 18);
				}
			}
			if (vitoria <= 70) {
				if (vitoria > 18) {
					bonus = Random.Range (1, 20);
				}
			}
			if (vitoria <= 130) {
				if (vitoria > 18) {
					bonus = Random.Range (1, 23);
				}
			}
			if (vitoria <= 200) {
				if (vitoria > 130) {
					bonus = Random.Range (1, 25);
				}
			}
			if (vitoria <= 250) {
				if (vitoria > 200) {
					bonus = Random.Range (1, 26);
				}
			}
			
			if (vitoria <= 300) {
				if (vitoria > 250) {
					bonus = Random.Range (1, 29);
				}
			}
			
			if (vitoria <= 350) {
				if (vitoria > 300) {
					bonus = Random.Range (1, 32);
				}
			}
			
			if (vitoria <= 450) {
				if (vitoria > 350) {
					bonus = Random.Range (1, 34);
				}
			}
			
			if (vitoria <= 600) {
				if (vitoria > 450) {
					bonus = Random.Range (1, 38);
				}
			}
			if (vitoria > 700) {
				if (vitoria > 600) {
					bonus = Random.Range (1, 49);
				}
			}

		} else {
		

			Application.LoadLevel("menu");
		
		}
		
	}

	IEnumerator checar2 () {
		
		yield return new WaitForSeconds(0.2f);
	
		totalpremio = totalpremio - 1;
		bauaberto.gameObject.SetActive (true);
		baufechado.gameObject.SetActive (false);

		yield break;
		
	}
	IEnumerator caida () {
		
		yield return new WaitForSeconds(3f);
		
		efei1.gameObject.SetActive (false);
		
		yield break;
		
	}
	IEnumerator explo () {
		
		yield return new WaitForSeconds(1.2f);
		
		brinde.gameObject.SetActive (true);
		StartCoroutine (colete ());
		
		yield break;
		
	}
	IEnumerator colete () {
		
		yield return new WaitForSeconds(0.3f);
		
		if (valorhero != "moeda" && valorhero != "gema") {
			xphero = xphero + valorbrinde;
			PlayerPrefs.SetInt("xp" + valorhero, xphero);
		
		}

		if (valorhero == "gema") {
			gema = gema + valorrecurso;
			PlayerPrefs.SetInt("gema", gema);
			
		}
		if (valorhero == "moeda") {
			gold = gold + valorrecurso;
			PlayerPrefs.SetInt("gold", gold);
			
		}
		yield break;
		
	}
	IEnumerator explo2 () {
		
		yield return new WaitForSeconds(1f);
		
	
		yield break;
		
	}

	// Update is called once per frame
	void Update () {
		nivel = PlayerPrefs.GetInt ("nivel" + valorhero);
		xphero = PlayerPrefs.GetInt ("xp" + valorhero);
		barra.maxValue = maxp;
		barra.value = xphero;
		xpherotx.text = xphero.ToString() + "/" + maxp.ToString ();


		if (valorhero == "moeda") {
		
			barra.gameObject.SetActive (false);
			ganhos.text = "x" + valorrecurso.ToString ();
		
		} else {
			if (valorhero != "gema") {
			barra.gameObject.SetActive (true);
				ganhos.text = "x" + valorbrinde.ToString ();
			}

			if (valorhero == "gema") {
				barra.gameObject.SetActive (false);
				ganhos.text = "x" + valorrecurso.ToString ();
			}
		
		}
	valorhero = card.sprite.texture.name.ToString ();
		//myInt = int.Parse(valorhero);
		vitoria = PlayerPrefs.GetInt ("vitoria");
	
		gold = PlayerPrefs.GetInt ("gold");
		gema = PlayerPrefs.GetInt ("gema");
		totalpremiotx.text = totalpremio.ToString ();


			card.sprite = cards_1[bonus];
		
		if(valorhero == "1"){
			namehero.text = "Archer Elf";
			type1.text = "Common";
			
			
		}
		if(valorhero == "2"){
			namehero.text = "White Angel";
			type1.text = "Rare";

		}
		if(valorhero == "3"){
			namehero.text = "Archer Nibus";
			type1.text = "Rare";
			
		}
		if(valorhero == "4"){
			namehero.text = "Cerberus";
			type1.text = "Epic";
			
		}
		if(valorhero == "5"){
			namehero.text = "OrcPokus";

			type1.text = "Common";
		}
		if(valorhero == "6"){
			namehero.text = "Dark Angel";
			type1.text = "Epic";
			
		}
		if(valorhero == "7"){
			namehero.text = "Mino Thaurus";
			type1.text = "Epic";
			
		}
		if(valorhero == "8"){
			namehero.text = "Viking Giulia";
			type1.text = "Common";
			
		}
		if(valorhero == "9"){
			namehero.text = "Witch Nina";
			type1.text = "Common";
			
		}
		if(valorhero == "10"){
			namehero.text = "Arkhina";
			type1.text = "Epic";
			
		}
		if(valorhero == "11"){
			namehero.text = "FireGirl";
			type1.text = "Common";
			
		}
		if(valorhero == "12"){
			namehero.text = "Golem";
			type1.text = "Epic";
			
		}
		if(valorhero == "13"){
			namehero.text = "Bear Fire";
			type1.text = "Epic";
			
		}
		if(valorhero == "14"){
			namehero.text = "Knight Kramer";
			type1.text = "Common";
		
		}
		if(valorhero == "15"){
			namehero.text = "Crunch";
			type1.text = "Common";
			
		}
		if(valorhero == "16"){
			namehero.text = "Drachus";
			type1.text = "Epic";
			
		}
		if(valorhero == "17"){
			namehero.text = "HobGreen";
			type1.text = "Rare";
			
		}
		if(valorhero == "18"){
			namehero.text = "Khalena";
			type1.text = "Rare";
			
		}
		if(valorhero == "19"){
			namehero.text = "Gorpo";
			type1.text = "Common";
			
		}
		if(valorhero == "20"){
			namehero.text = "Gemini Elf";
			type1.text = "Rare";
			
		}
		if(valorhero == "21"){
			namehero.text = "Fire Ball";
			type1.text = "Common";
			
		}
		if(valorhero == "22"){
			namehero.text = "Crows";
			type1.text = "Rare";
			
		}
		if(valorhero == "23"){
			namehero.text = "Thunder";
			type1.text = "Epic";
			
		}
		if(valorhero == "24"){
			namehero.text = "Green poison";
			type1.text = "Common";
		}
		if(valorhero == "25"){
			namehero.text = "Lantra";
			type1.text = "Common";
			
		}
		if(valorhero == "26"){
			namehero.text = "Trops";
			type1.text = "Rare";
			
		}

		if(valorhero == "moeda"){
			namehero.text = "Gold";
			type1.text = "Resource";
			
		}

		if(valorhero == "gema"){
			namehero.text = "Gem";
			type1.text = "Resource";
			
		}

		if(valorhero == "40"){
			namehero.text = "Gruu";
			type1.text = "Legendary";
			
		}
		if(valorhero == "41"){
			namehero.text = "Death";
			type1.text = "Legendary";
			
		}


		if(valorhero == "42"){
			namehero.text = "Nhaja";
			type1.text = "Legendary";
			
		}

		if(valorhero == "44"){
			namehero.text = "Canon";
			type1.text = "Legendary";
			
		}

		if(valorhero == "45"){
			namehero.text = "KingMon";
			type1.text = "Legendary";
			
		}

		if(valorhero == "46"){
			namehero.text = "Spider";
			type1.text = "Legendary";
			
		}

		if(valorhero == "47"){
			namehero.text = "Kramas";
			type1.text = "Legendary";
			
		}

		if(valorhero == "48"){
			namehero.text = "Assassin";
			type1.text = "Legendary";
			
		}

		if(valorhero == "49"){
			namehero.text = "KingBomb";
			type1.text = "Legendary";
			
		}

		if(valorhero == "50"){
			namehero.text = "Shocker";
			type1.text = "Legendary";
			
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

	
	
	}
}

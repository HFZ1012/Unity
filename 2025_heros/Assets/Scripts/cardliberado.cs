using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class cardliberado : MonoBehaviour {


	public int vitoria;
	public int gold;
	public GameObject card;
	public int meta;
	public Slider barra;
	public int tipo;
	public int valor;
	public int xp;
	public int gema;
	public GameObject brilho;
	public AudioSource click;
	public AudioSource click2;
	public int slot1;
	public int numberslot;
	public Text aqui;
	public int ouro;
	public int ouro2;
	public int receptor;
	public GameObject aviso1;
	// Use this for initialization
	void Start () {

	
	}
	public void abrir(){


		if (valor >= meta) {
		
			click.GetComponent<AudioSource>().Play ();


			if(tipo == 1){

				gold = gold - 1500;
				PlayerPrefs.SetInt("gold", gold);
				StartCoroutine(checar ());
			}
			if(tipo == 2){
				
				gema = gema - 200;
				PlayerPrefs.SetInt("gema", gema);
				StartCoroutine(checar ());
			}
			if(tipo == 3){
				
				vitoria = vitoria - 500;
				PlayerPrefs.SetInt("vitoria1", vitoria);
				StartCoroutine(checar ());
			}
			if(tipo == 4){
				
				ouro = ouro - 100;
				PlayerPrefs.SetInt("ouro", ouro);
				StartCoroutine(checar ());
			}

			if(tipo == 5){
				
				ouro2 = ouro2 - 170;
				PlayerPrefs.SetInt("ouro2", ouro2);
				StartCoroutine(checar ());
			}
		
		} else {
			click2.GetComponent<AudioSource>().Play ();
			aviso1.gameObject.SetActive(true);

		
		}

	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.2f);
		StartCoroutine(checar3 ());
		PlayerPrefs.SetInt("slot" + numberslot, 0);
		if (tipo == 1) {
			Application.LoadLevel ("bauouro");
		}
		if (tipo == 2) {
			Application.LoadLevel ("bauespecial");
		}
		if (tipo == 3) {
			Application.LoadLevel ("arena1");
		}
		if (tipo == 4) {
			PlayerPrefs.SetInt("receptor", 2);
		}
		if (tipo == 5) {
			Application.LoadLevel ("hero2");
		}
		yield break;
		
	}
	IEnumerator checar3 () {
		
		yield return new WaitForSeconds(0.2f);

		PlayerPrefs.SetInt("slot" + numberslot, 0);

		yield break;
		
	}
	public void fechar(){
	
		aviso1.gameObject.SetActive(false);
		click.GetComponent<AudioSource>().Play ();
	
	}
	// Update is called once per frame
	void Update () {
		slot1 = PlayerPrefs.GetInt ("slot" + numberslot);
		gema = PlayerPrefs.GetInt ("gema");
		gold = PlayerPrefs.GetInt ("gold");
		vitoria = PlayerPrefs.GetInt ("vitoria1");
		ouro = PlayerPrefs.GetInt ("ouro");
		ouro2 = PlayerPrefs.GetInt ("ouro2");
		aqui.text = valor.ToString () + "/" + meta.ToString ();

		if (valor >= meta) {
		
			brilho.gameObject.SetActive (true);
		
		} else {
		
			brilho.gameObject.SetActive (false);
		
		}
		if (slot1 == 1) {
		
			card.gameObject.SetActive (true);
		
		} else {
		
		
			card.gameObject.SetActive (false);
		
		}

		barra.maxValue = meta;
		barra.value = valor;


		if(tipo == 1){
			valor = gold;
		}
		if(tipo == 2){
			valor = gema;
		}
		if(tipo == 3){
			valor = vitoria;
		}
		if(tipo == 4){
			valor = ouro;
		}
		if(tipo == 5){
			valor = ouro2;
		}

	
	}
}

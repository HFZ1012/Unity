using UnityEngine;
using System.Collections;

public class gerenciar_arenas : MonoBehaviour {

	public int vitorias;
	public GameObject aren1;
	public GameObject aren1pb;
	public GameObject aren2;
	public GameObject aren2pb;
	public GameObject aren3;
	public GameObject aren3pb;
	public int valorpraliberar;
	public int valordaar;
	public AudioSource clik;
	public GameObject brilho1;
	public GameObject brilho2;
	public GameObject brilho3;
	public GameObject brilho4;
	public int selecionada;
	public GameObject tela;
	public GameObject tela2;
	public int nova_arena;
	// Use this for initialization
	void Start () {

		vitorias = PlayerPrefs.GetInt ("vitoria1");

	 
	
	}
	public void selectarena1(){
	
		PlayerPrefs.SetInt ("selectarena", 1);
		clik.GetComponent<AudioSource>().Play ();
		tela.gameObject.SetActive (false);
		tela2.gameObject.SetActive (true);
	}
	public void selectarena2(){
		
		PlayerPrefs.SetInt ("selectarena", 2);
		clik.GetComponent<AudioSource>().Play ();
		tela.gameObject.SetActive (false);
		tela2.gameObject.SetActive (true);
	}
	public void selectarena3(){
		
		PlayerPrefs.SetInt ("selectarena", 3);
		clik.GetComponent<AudioSource>().Play ();
		tela.gameObject.SetActive (false);
		tela2.gameObject.SetActive (true);
	}
	public void selectarena4(){
		
		PlayerPrefs.SetInt ("selectarena", 4);
		clik.GetComponent<AudioSource>().Play ();
		tela.gameObject.SetActive (false);
		tela2.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		vitorias = PlayerPrefs.GetInt ("vitoria1");
		nova_arena = PlayerPrefs.GetInt ("nova_arena");

			if(nova_arena >= 1){
				
				aren1.gameObject.SetActive (true);
				aren1pb.gameObject.SetActive (false);
				PlayerPrefs.SetInt("vitoria1", 0);
				
			}
			



			if(nova_arena >= 2){
				
				aren2.gameObject.SetActive (true);
				aren2pb.gameObject.SetActive (false);
				PlayerPrefs.SetInt("vitoria1", 0);

			}
			



			if(nova_arena >= 3){
				
				aren3.gameObject.SetActive (true);
				aren3pb.gameObject.SetActive (false);
				PlayerPrefs.SetInt("vitoria1", 0);
				
			}
			



		selecionada = PlayerPrefs.GetInt("selectarena");
		if (selecionada == 1) {
		
			brilho1.gameObject.SetActive (true);
		
		} else {
			brilho1.gameObject.SetActive (false);
		
		}
		if (selecionada == 2) {
			
			brilho2.gameObject.SetActive (true);
			
		} else {
			brilho2.gameObject.SetActive (false);
			
		}
		if (selecionada == 3) {
			
			brilho3.gameObject.SetActive (true);
			
		} else {
			brilho3.gameObject.SetActive (false);
			
		}
		if (selecionada == 4) {
			
			brilho4.gameObject.SetActive (true);
			
		} else {
			brilho4.gameObject.SetActive (false);
			
		}
	
	}
}

using UnityEngine;
using System.Collections;

public class gerenciarloja : MonoBehaviour {
	public GameObject alerta;
	public AudioSource click;
	public int gemas;

	// Use this for initialization
	void Start () {
	
	}
	public void fecharalerta(){

		alerta.gameObject.SetActive (false);
		click.GetComponent<AudioSource>().Play ();

	}

	public void compra1(){
		click.GetComponent<AudioSource>().Play ();
		if (gemas >= 20000) {
			gemas = gemas - 20000;
			PlayerPrefs.SetInt("gema", gemas);
			PlayerPrefs.SetInt("codigo_hero16", 3);

		}else {
			alerta.gameObject.SetActive(true);
			
		}

	}
	public void compra2(){
		click.GetComponent<AudioSource>().Play ();
		if (gemas >= 10000) {
			gemas = gemas - 10000;
			PlayerPrefs.SetInt("gema", gemas);
			PlayerPrefs.SetInt("codigo_hero12", 3);
			
		}else {
			alerta.gameObject.SetActive(true);
			
		}
		
	}
	public void compra3(){
		
		if (gemas >= 5000) {
			gemas = gemas - 5000;
			PlayerPrefs.SetInt("gema", gemas);
			PlayerPrefs.SetInt("codigo_hero4", 3);
			
		}else {
			alerta.gameObject.SetActive(true);
			
		}
		
	}
	public void compra4(){
		click.GetComponent<AudioSource>().Play ();
		if (gemas >= 7000) {
			gemas = gemas - 7000;
			PlayerPrefs.SetInt("gema", gemas);
			PlayerPrefs.SetInt("codigo_hero13", 3);
			
		}else {
			alerta.gameObject.SetActive(true);
			
		}
		
	}
	public void compra5(){
		click.GetComponent<AudioSource>().Play ();
		if (gemas >= 400) {
			gemas = gemas - 400;
			PlayerPrefs.SetInt("gema", gemas);
			Application.LoadLevel("baumadeira");
			
		}else {
			alerta.gameObject.SetActive(true);
			
		}
		
	}
	public void compra6(){
		click.GetComponent<AudioSource>().Play ();
		if (gemas >= 650) {
			gemas = gemas - 650;
			PlayerPrefs.SetInt ("gema", gemas);
			Application.LoadLevel("bauouro");
			
		} else {
			alerta.gameObject.SetActive(true);
		
		}
		
	}
	public void scret(){
		click.GetComponent<AudioSource>().Play ();
		if (gemas >= 1000000) {
			gemas = gemas - 1000000;
			PlayerPrefs.SetInt ("gema", gemas);
		
			
		} else {

			
		}
		
	}
	// Update is called once per frame
	void Update () {
		gemas = PlayerPrefs.GetInt ("gema");
	
	}
}

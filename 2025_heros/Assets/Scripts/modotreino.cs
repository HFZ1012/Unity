using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class modotreino : MonoBehaviour {
	
	public int estrategia;
	public int usuario;
	public string names;
	public int nomejogador;
	public int selecionada;

	public float tempo;
	public Text tempotx;
	public string nomeescolhido;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("selectarena", 1);
		selecionada = PlayerPrefs.GetInt ("selectarena");
		PlayerPrefs.SetInt ("tipojogo", 1);
		tempo = Random.Range (2, 6);

		//usuario = Random.Range (0, 999);
		nomejogador = Random.Range (10, 99);
		estrategia = Random.Range (0, 10);
		PlayerPrefs.SetInt ("estrategia", estrategia);
		PlayerPrefs.SetString ("usuario", "Trainer" + nomejogador.ToString());
		
		StartCoroutine (checar ());
		
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.2f);
		PlayerPrefs.SetInt ("estrategia", estrategia);
		PlayerPrefs.SetString ("usuario", "Trainer" + nomejogador.ToString());
		
		yield break;
		
	}
	// Update is called once per frame
	void Update () {

		selecionada = PlayerPrefs.GetInt ("selectarena");
		tempotx.text = tempo.ToString ("#") + " s";
		tempo -= Time.deltaTime; 
		nomeescolhido = PlayerPrefs.GetString("usuario");
		
		if (tempo <= 0) {

				Application.LoadLevel("gameplay1");
					
			
		}
		
	}
}

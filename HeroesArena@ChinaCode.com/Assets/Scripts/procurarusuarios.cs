using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class procurarusuarios : MonoBehaviour {

	public int estrategia;
	public int usuario;
	public string[] names;
	public int nomejogador;
	public int selecionada;
	public Image arenas;
	public Sprite[] cenario;
	public float tempo;
	public Text tempotx;
	public string nomeescolhido;
	public int vitoric;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("tipojogo", 2);
		vitoric = Random.Range (33, 900);
		PlayerPrefs.SetInt ("victory", vitoric);
		selecionada = PlayerPrefs.GetInt ("selectarena");
		arenas.sprite = cenario [selecionada];
		tempo = Random.Range (2, 6);
		//usuario = Random.Range (0, 999);
		nomejogador = Random.Range (0, 200);
		estrategia = Random.Range (0, 10);
		PlayerPrefs.SetInt ("estrategia", estrategia);
		PlayerPrefs.SetString ("usuario", names[nomejogador]);

		StartCoroutine (checar ());
	
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.2f);
		PlayerPrefs.SetInt ("estrategia", estrategia);
		PlayerPrefs.SetString ("usuario", names[nomejogador]);
		PlayerPrefs.SetInt ("victory", vitoric);
		yield break;
		
	}
	// Update is called once per frame
	void Update () {
		arenas.sprite = cenario [selecionada];
		selecionada = PlayerPrefs.GetInt ("selectarena");
		tempotx.text = tempo.ToString ("#") + " s";
		tempo -= Time.deltaTime; 
		nomeescolhido = PlayerPrefs.GetString("usuario");

		if (tempo <= 0) {

			Application.LoadLevel("load_battle");



		
		}
	
	}
}

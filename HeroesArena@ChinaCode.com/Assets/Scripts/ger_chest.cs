using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ger_chest : MonoBehaviour {
	public int slot;
	public int liberado;
	public GameObject bauaparece;
	public GameObject avisoabre;
	public int gema;
	public int hour1;
	public int min1;
	public int sec1;
	public string hor;
	public string hor_conf;
	public string hor1;
	public string hor_conf1;
	public float gameTimer;
	public GameObject chestfreeliberado;
	public int contador;
	private string remainingTime;
	public int seconds;
	public int minutes;
	public Text horario;
	// Use this for initialization
	void Start () {
		contador = 0;
		hour1 = PlayerPrefs.GetInt ("net_hora");
		min1 = PlayerPrefs.GetInt ("net_minuto");
		sec1 = PlayerPrefs.GetInt ("net_segundo");
		PlayerPrefs.SetInt("slot"+ slot, 1);
		liberado = PlayerPrefs.GetInt ("slot" + slot);
		hor = System.DateTime.Now.Hour.ToString ();
		hor1 = System.DateTime.Now.Hour.ToString ();
		hor_conf = PlayerPrefs.GetString ("hor" + slot);
		hor_conf1 = PlayerPrefs.GetString ("hor1" + slot);
		if (liberado == 1) {
		
			bauaparece.gameObject.SetActive(true);
			PlayerPrefs.SetInt("slot" + slot, 2);
		
		}



			
			if (hor1 != hor_conf1) {
				chestfreeliberado.gameObject.active = true;
				PlayerPrefs.SetString ("hor1" + slot, hor1);
				hor1 = System.DateTime.Now.Hour.ToString ();
				gameTimer = 0;
				PlayerPrefs.SetFloat("tempo" + slot, gameTimer);
				
			}
			if (hor1 == hor_conf1) {
				
				gameTimer = 3600 - min1 * 60;
				PlayerPrefs.SetFloat("tempo" + slot, gameTimer);
				StartCoroutine (checar2 ());
				
			}
		
		

	
	}
	public void chestfree(){
		
		if (chestfreeliberado.gameObject.active == true) {
			
			Application.LoadLevel("bauouro");
			
			

			
			
			
		}
		
		
	}
	public void toquebau(){


		avisoabre.gameObject.SetActive (true);

	}

	

IEnumerator checar () {
	
	yield return new WaitForSeconds(0.5f);
	
	
	Application.LoadLevel ("bauouro");
		PlayerPrefs.SetInt("slot" + slot, 0);
	
	
	yield break;
	
}
	IEnumerator checar2 () {
		
		yield return new WaitForSeconds(0.1f);
		
gameTimer = PlayerPrefs.GetInt ("slot" + slot);
		
		
		yield break;
		
	}
	IEnumerator checar3 () {
		
		yield return new WaitForSeconds(0.1f);

		
		PlayerPrefs.SetInt("slot" + slot, 3);
		yield break;
		
	}
	public void comprar(){
		if (gema >= 50) {
		
			StartCoroutine (checar ());
			gema = gema - 50;
			PlayerPrefs.SetInt("gema", gema);
			PlayerPrefs.SetInt("slot" + slot, 0);
		}
		
		avisoabre.gameObject.SetActive (true);
		
	}
	public void tempo(){

			
				

		StartCoroutine (checar2 ());
		avisoabre.gameObject.SetActive (false);
		
	}
	// Update is called once per frame
	void Update () {
		liberado = PlayerPrefs.GetInt ("slot" + slot);
			gema = PlayerPrefs.GetInt ("gema");
		if (liberado == 1) {
			
			bauaparece.gameObject.SetActive(true);

			
		}
		if (liberado == 0) {
			
			bauaparece.gameObject.SetActive(false);
			chestfreeliberado.gameObject.active = false;
			
			
		}

		if (liberado == 3) {
		
			if (contador == 0) {
				seconds = Mathf.CeilToInt (gameTimer - Time.timeSinceLevelLoad) % 60;
				minutes = Mathf.CeilToInt (gameTimer - Time.timeSinceLevelLoad) / 60; 
			}
			
			if (seconds == 0 && minutes == 0) {
				chestfreeliberado.gameObject.SetActive(true);
				contador = 2;
			}
			
			
		
			
			remainingTime = string.Format("{0:00} : {1:00}", minutes, seconds); 
			if (seconds != 0 && minutes != 0) {
				horario.text = remainingTime.ToString ();
			} else {
				
				horario.text = "Get";
			}
		
		
		}
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class evolucaook : MonoBehaviour {
	public int hitpoint;
	public Text hitpoint_tx;
	public int damage;
	public Text damage_tx;
	public float hitspeed;
	public Text hitspeed_tx;

	public int ganhohitpoint;
	public float ganhohitspeed;
	public int ganhodamage;
	public GameObject tela;
	public Text ganhohitpoint_tx;
	public Text ganhohitspeed_tx;
	public Text ganhodamage_tx;

	public int estagio;
	public int totalhitpoint;
	public float totalhitspeed;
	public int totaldamage;
	public Text namehero;
	public int xp;
	public Text xp_tx;
	public Slider barra;
	public int maxp;
	public int nivel;
	public Text niveltx;
	public int info1;
	public GameObject botaosair;
	public GameObject passoudenivel;
	public Image card;
	public Sprite[] cards;
	public AudioSource audio1;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("evoluirxp", 2);
		info1 = PlayerPrefs.GetInt ("info");
		estagio = 0;
		StartCoroutine (parte1 ());
	
		card.sprite = cards [info1];
		nivel = PlayerPrefs.GetInt ("nivel" + info1);
		niveltx.text = "Level " + nivel.ToString ();
		if(info1 == 1){
			namehero.text = "Archer Elf";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
			
		}
		if(info1 == 2){
			namehero.text = "White Angel";
			
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
		}
		if(info1 == 3){
			namehero.text = "Archer Nibus";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 4){
			namehero.text = "Cerberus";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 5){
			namehero.text = "OrcPokus";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 6){
			namehero.text = "Dark Angel";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 7){
			namehero.text = "Mino Thaurus";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 8){
			namehero.text = "Viking Giulia";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 9){
			namehero.text = "Witch Nina";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 10){
			namehero.text = "Arkhina";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 11){
			namehero.text = "FireGirl";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 12){
			namehero.text = "Golem";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 13){
			namehero.text = "Ursa";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 14){
			namehero.text = "Knight";
			
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
		}
		if(info1 == 15){
			namehero.text = "Crunch";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 16){
			namehero.text = "Drachus";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 17){
			namehero.text = "HobGreen";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 18){
			namehero.text = "Khalena";
			
			
		}
		if(info1 == 19){
			namehero.text = "Gorpo";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 20){
			namehero.text = "Gemini Elf";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 21){
			namehero.text = "Fire Ball";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 22){
			namehero.text = "Crows";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 23){
			namehero.text = "Thunder";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 24){
			namehero.text = "Green poison";
			
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
		}
		if(info1 == 25){
			namehero.text = "Lantra";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 26){
			namehero.text = "Trops";
			ganhodamage = 5;
			ganhohitpoint = 5;
			ganhohitspeed = 0.1f;
			
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
		hitpoint = PlayerPrefs.GetInt ("hitpoint" + info1);
		hitpoint_tx.text = hitpoint.ToString ();

		hitspeed = PlayerPrefs.GetFloat ("hitspeed" + info1);
		hitspeed_tx.text = hitspeed.ToString ();

		damage = PlayerPrefs.GetInt ("damage" + info1);
		damage_tx.text = damage.ToString ();

		xp = PlayerPrefs.GetInt ("xp" + info1);
		xp_tx.text = xp.ToString() + "/" + maxp.ToString ();

		totaldamage = damage + ganhodamage;
		totalhitpoint = hitpoint + ganhohitpoint;
		totalhitspeed = hitspeed + ganhohitspeed;


	
	}
	IEnumerator parte1 () {
		
		yield return new WaitForSeconds(1.0f);
		info1 = PlayerPrefs.GetInt ("info");
		card.sprite = cards [info1];
		estagio = 1;
		audio1.GetComponent<AudioSource>().Play ();
		
		yield break;
		
	}
	public void fechartela(){
	
		Application.LoadLevel ("menu");
	
	}
	// Update is called once per frame
	void Update () {
		//barra.maxValue = maxp;
		//barra.value = xp;
		xp = PlayerPrefs.GetInt ("xp" + info1);
		xp_tx.text = xp.ToString() + "/" + maxp.ToString ();
		info1 = PlayerPrefs.GetInt ("info");
		card.sprite = cards [info1];
		hitpoint = PlayerPrefs.GetInt ("hitpoint" + info1);
		hitpoint_tx.text = hitpoint.ToString ();
		
		hitspeed = PlayerPrefs.GetFloat ("hitspeed" + info1);
		hitspeed_tx.text = hitspeed.ToString ("#.##");
		
		damage = PlayerPrefs.GetInt ("damage" + info1);
		damage_tx.text = damage.ToString ();
		nivel = PlayerPrefs.GetInt ("nivel" + info1);
		niveltx.text = "Level " + nivel.ToString ();

		if (estagio == 1) {
		
			hitpoint = hitpoint + 2;
			PlayerPrefs.SetInt ("hitpoint" + info1, hitpoint);
			if(hitpoint >= totalhitpoint){

				estagio = 2;
			}
		
		}

		if (estagio == 2) {
			
			damage = damage + 2;
			PlayerPrefs.SetInt ("damage" + info1, damage);
			if(damage >= totaldamage){
			
				estagio = 3;
			}
			
		}

		if (estagio == 3) {
			
			hitspeed = hitspeed + 0.1f;
			PlayerPrefs.SetFloat ("hitspeed" + info1, hitspeed);
			if(hitspeed >= totalhitspeed){

				estagio = 4;
			}
			
		}
		if (estagio == 4) {
			
			nivel = nivel + 1;
			PlayerPrefs.SetInt ("nivel" + info1, nivel);

			PlayerPrefs.SetInt ("xp" + info1, 0);
				
				estagio = 5;
			passoudenivel.gameObject.SetActive(true);
			botaosair.gameObject.SetActive(true);
			audio1.GetComponent<AudioSource>().Stop ();

			
		}
		if(info1 == 1){
			namehero.text = "Archer Elf";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;


		}
		if(info1 == 2){
			namehero.text = "White Angel";
			
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
		}
		if(info1 == 3){
			namehero.text = "Archer Nibus";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 4){
			namehero.text = "Cerberus";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 5){
			namehero.text = "OrcPokus";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 6){
			namehero.text = "Dark Angel";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 7){
			namehero.text = "Mino Thaurus";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 8){
			namehero.text = "Viking Giulia";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 9){
			namehero.text = "Witch Nina";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 10){
			namehero.text = "Arkhina";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 11){
			namehero.text = "FireGirl";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 12){
			namehero.text = "Golem";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 13){
			namehero.text = "Bear Fire";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 14){
			namehero.text = "Knight Kramer";
			
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
		}
		if(info1 == 15){
			namehero.text = "Crunch";
			
			
		}
		if(info1 == 16){
			namehero.text = "Drachus";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 17){
			namehero.text = "HobGreen";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 18){
			namehero.text = "Khalena";
			
			
		}
		if(info1 == 19){
			namehero.text = "Gorpo";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 20){
			namehero.text = "Gemini Elf";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 21){
			namehero.text = "Fire Ball";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 22){
			namehero.text = "Crows";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 23){
			namehero.text = "Thunder";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 24){
			namehero.text = "Green poison";
			
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
		}
		if(info1 == 25){
			namehero.text = "Lantra";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
		}
		if(info1 == 26){
			namehero.text = "Ice Hero";
			ganhodamage = 27;
			ganhohitpoint = 30;
			ganhohitspeed = 0.1f;
			
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

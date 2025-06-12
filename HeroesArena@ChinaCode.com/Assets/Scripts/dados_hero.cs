using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class dados_hero : MonoBehaviour {

	public int hitpoint;
	public int damage;
	public int range;
	public float hitspeed;
	public int regeneration;
	public int count;

	public Image card;
	public Sprite[] cards;
	public int info1;
	public Text hitpoint_tx;
	public Text damage_tx;
	public Text target_tx;
	public Text speed_tx;
	public Text range_tx;
	public Text hitspeed_tx;
	public Text regen_tx;
	public Text count_tx;

	public Text raitytx;
	public Text type_tx;

	public Slider barra;
	public int xp1;
	public Text xp1tx;

	public GameObject[] desc;
	public int maxp;
	public int improve;
	public Text preco1;
	public Text preco2;
	public Text nivelhero;
	public int nivel;
	public GameObject buttonsim;
	public GameObject buttonno;
	public int gold;
	public GameObject telainfo;
	public GameObject nodindi;
	public AudioSource alert;
	// Use this for initialization
	void Start () {
	
	}
	public void evoluir1(){
		if (xp1 >= maxp) {
			if (gold >= improve) {

				StartCoroutine (checar ());
				gold = gold - improve;
				PlayerPrefs.SetInt ("gold", gold);
			} else {
		
				nodindi.gameObject.SetActive (false);
				alert.GetComponent<AudioSource> ().Play ();
		
			}
		}
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.2f);
		Application.LoadLevel ("hero_up");
		yield break;
		
	}

	// Update is called once per frame
	void Update () {

		if (xp1 >= maxp) {
			if(gold >= improve){

				buttonsim.gameObject.SetActive(true);
				buttonno.gameObject.SetActive(false);

			}
		
		}

		if (xp1 < maxp) {

				
				buttonsim.gameObject.SetActive(false);
				buttonno.gameObject.SetActive(true);
				
						
		}

	



			   gold = PlayerPrefs.GetInt("gold");
		info1 = PlayerPrefs.GetInt ("info");
		card.sprite = cards [info1];

		hitpoint = PlayerPrefs.GetInt ("hitpoint" + info1);
		hitpoint_tx.text = hitpoint.ToString ();

		improve = PlayerPrefs.GetInt ("improve" + info1);


		damage = PlayerPrefs.GetInt ("damage" + info1);
		damage_tx.text = damage.ToString ();

		range = PlayerPrefs.GetInt ("range" + info1);
		range_tx.text = range.ToString ();

		hitspeed = PlayerPrefs.GetFloat ("hitspeed" + info1);
		hitspeed_tx.text = hitspeed.ToString ();

		regeneration = PlayerPrefs.GetInt ("regeneration" + info1);
		regen_tx.text = regeneration.ToString ();

		count = PlayerPrefs.GetInt ("count" + info1);
		count_tx.text = count.ToString ();

		xp1 = PlayerPrefs.GetInt ("xp" + info1);
		xp1tx.text = xp1.ToString () + "/" + maxp.ToString ();

		nivel = PlayerPrefs.GetInt ("nivel" + info1);
		improve = 50 * nivel;
		nivelhero.text = "Level " + nivel.ToString();
		preco1.text = improve.ToString ();
		preco2.text = improve.ToString ();
		barra.maxValue = maxp;
		barra.value = xp1;

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

		if (info1 == 1) {
			raitytx.text = "Commom";
			type_tx.text = "Troop";
			target_tx.text = "Ground/Air";
			speed_tx.text = "Medium";

		
		}
		if (info1 == 2) {
			raitytx.text = "Rare";
			type_tx.text = "Troop";
			target_tx.text = "Ground/Air";
			speed_tx.text = "Fast";
			
			
		}
		if (info1 == 3) {
			raitytx.text = "Rare";
			type_tx.text = "Troop";
			target_tx.text = "Ground/Air";
			speed_tx.text = "Fast";
			
			
		}
		if (info1 == 4) {
			raitytx.text = "Epic";
			type_tx.text = "Troop";
			target_tx.text = "Medium";
			
			
		}
		if (info1 == 5) {
			raitytx.text = "Commom";
			type_tx.text = "Troop";
			target_tx.text = "Ground";
			speed_tx.text = "Slow";
			
			
		}
		if (info1 == 6) {
			raitytx.text = "Epic";
			type_tx.text = "Troop";
			target_tx.text = "Ground/Air";
			speed_tx.text = "Very Fast";
			
			
		}
		if (info1 == 7) {
			raitytx.text = "Epic";
			type_tx.text = "Troop";
			target_tx.text = "Ground";
			speed_tx.text = "Medium";
			
			
		}
		if (info1 == 8) {
			raitytx.text = "Commom";
			type_tx.text = "Troop";
			target_tx.text = "Ground";
			speed_tx.text = "Fast";
			
			
		}
		if (info1 == 9) {
			raitytx.text = "Commom";
			type_tx.text = "Troop";
			target_tx.text = "Ground/Air";
			speed_tx.text = "medium";
			
			
		}
		if (info1 == 10) {
			raitytx.text = "Epic";
			type_tx.text = "Troop";
			target_tx.text = "Ground/Air";
			speed_tx.text = "medium";
			
			
		}
		if (info1 == 11) {
			raitytx.text = "Commom";
			type_tx.text = "Troop";
			target_tx.text = "Ground/Air";
			speed_tx.text = "medium";
			
			
		}
		if (info1 == 12) {
			raitytx.text = "Epic";
			type_tx.text = "Troop";
			target_tx.text = "Ground";
			speed_tx.text = "Slow";
			
			
		}
		if (info1 == 13) {
			raitytx.text = "Epic";
			type_tx.text = "Troop";
			target_tx.text = "Ground";
			speed_tx.text = "Fast";
			
			
		}
		if (info1 == 14) {
			raitytx.text = "Commom";
			type_tx.text = "Troop";
			target_tx.text = "Ground";
			speed_tx.text = "medium";
			
			
		}
		if (info1 == 15) {
			raitytx.text = "Commom";
			type_tx.text = "Troop";
			target_tx.text = "Ground";
			speed_tx.text = "Slow";
			
			
		}
		if (info1 == 16) {
			raitytx.text = "Epic";
			type_tx.text = "Troop";
			target_tx.text = "Ground/Air";
			speed_tx.text = "Medium";
			
			
		}
		if (info1 == 17) {
			raitytx.text = "Rare";
			type_tx.text = "Troop";
			target_tx.text = "Ground";
			speed_tx.text = "Very Fast";
			
			
		}
		if (info1 == 18) {
			raitytx.text = "Rare";
			type_tx.text = "Troop";
			target_tx.text = "Ground";
			speed_tx.text = "Medium";
			
			
		}
		if (info1 == 19) {
			raitytx.text = "Commom";
			type_tx.text = "Troop";
			target_tx.text = "Ground/Air";
			speed_tx.text = "medium";
			
			
		}
		if (info1 == 20) {
			raitytx.text = "Rare";
			type_tx.text = "Troop";
			target_tx.text = "Ground/Air";
			speed_tx.text = "Fast";
			
			
		}
		if (info1 == 21) {
			raitytx.text = "Commom";
			type_tx.text = "Spell";
			target_tx.text = "Ground/Air";
			speed_tx.text = "medium";
			
			
		}
		if (info1 == 22) {
			raitytx.text = "Rare";
			type_tx.text = "Spell";
			target_tx.text = "Ground/Air";
			speed_tx.text = "medium";
			
			
		}
		if (info1 == 23) {
			raitytx.text = "Epic";
			type_tx.text = "Spell";
			target_tx.text = "Ground/Air";
			speed_tx.text = "medium";
			
			
		}
		if (info1 == 24) {
			raitytx.text = "Commom";
			type_tx.text = "Spell";
			target_tx.text = "Ground/Air";
			speed_tx.text = "medium";
			
			
		}
		if (info1 == 25) {
			raitytx.text = "Commom";
			type_tx.text = "Spell";
			target_tx.text = "Ground/Air";
			speed_tx.text = "medium";
			
			
		}
		if (info1 == 26) {
			raitytx.text = "Rare";
			type_tx.text = "Spell";
			target_tx.text = "Ground/Air";
			speed_tx.text = "medium";
			
			
		}
	
	}
}

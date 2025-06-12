using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class gerenciar_menu1 : MonoBehaviour {

	public GameObject bau1;
	public GameObject bau2;
	public GameObject bau3;
	public GameObject bau4;
	public GameObject bau5;
	public int slot1;
	public int slot2;
	public int slot3;
	public int slot4;
	public int slot5;
	public Animation geral;
	public int posicao;
	public Image arenas;
	public Sprite[] aren;
	public int selecionada;
	public GameObject button_info1;
	public GameObject luz1;
	public GameObject barraevolu1;
	public Animation mexe;
	public int leveljogo;
	public Text leveltx;
	public GameObject button_info2;
	public GameObject luz2;
	public GameObject barraevolu2;
	public Animation mexe2;
	public float media;
	public GameObject button_info3;
	public GameObject luz3;
	public GameObject barraevolu3;
	public Animation mexe3;
	public GameObject telaequip;
	public GameObject button_info4;
	public GameObject luz4;
	public GameObject barraevolu4;
	public Animation mexe4;
	public float gameTimer;
	public GameObject chestcoroaliberado;
	public GameObject chestfreeliberado;
	//in seconds
	private string remainingTime;
	public int seconds;
	public int minutes;
	public Text horario;
	public GameObject button_info5;
	public GameObject luz5;
	public GameObject barraevolu5;
	public Animation mexe5;
	public Text namearena;
	public GameObject button_info6;
	public GameObject luz6;
	public GameObject barraevolu6;
	public Animation mexe6;

	public GameObject button_info7;
	public GameObject luz7;
	public GameObject barraevolu7;
	public Animation mexe7;

	public GameObject button_info8;
	public GameObject luz8;
	public GameObject barraevolu8;
	public Animation mexe8;

	public GameObject mostrarcarta;

	public int pos1;
	public int pos2;
	public int pos3;
	public int pos4;
	public int pos5;
	public int pos6;
	public int pos7;
	public int pos8;

	public GameObject card1;
	public GameObject card2;
	public GameObject card3;
	public GameObject card4;
	public GameObject card5;
	public GameObject card6;
	public GameObject card7;
	public GameObject card8;
	public GameObject alert_semnet;
	public Image card1a;
	public Image card2a;
	public Image card3a;
	public Image card4a;
	public Image card5a;
	public Image card6a;
	public Image card7a;
	public Image card8a;
	public string valorhero;
	public int myInt;
	public Image cartaselect;
	public Sprite[] cards;

	public static int sok1;
	public static int sok2;
	public static int sok3;
	public static int sok4;
	public static int sok5;
	public static int sok6;
	public static int sok7;
	public static int sok8;

	public int slots;

	public int modo1;
	public int cartaescolhida;

	public ScrollRect teste;
	public int quantdcartas;
	public int xp;
	public int gold;
	public int gema;
	public Text xptx;
	public Text goldtx;
	public Text gematx;
	public int maxp;
	public Slider barraxp;
	public Slider barracoroa;
	public Text coroatx;
	public Text totalcartas;

	public float media1;
	public int contador;

	public int coroas;
	private string remainingTime_ouro;
	private string remainingTime_prata;
	public Text nameusertx;
	public Text vitoriastx;
	public string nameuser;
	public int vitorias;
	public int dy;
	public int mm;
	public int hr;
	public int sc;
	public int year;
	public GameObject telabatle;
	public GameObject teladeck;
	public GameObject telaloja;
	public GameObject arenas_tela;
	public AudioSource click;
	public AudioSource click2;
	public string dia;
	public string dia_conf;
	public string hor;
	public string hor_conf;
	public string hor1;
	public string hor_conf1;

	public int modo_jogo;
	public string dia1;
	public string dia_conf1;
	public int day1;
	public int hour1;
	public int min1;
	public int sec1;
	public int seconds1;
	public int minutes1;
	public int hora1;
	public int seconds2;
	public int minutes2;
	public int hora2;
	//public Text tempoouro;
	//public Text tempoprata;
	public int liberaouro;
	public int liberaprata;

	public void chamartelaarena(){

		arenas_tela.gameObject.SetActive (true);
		telabatle.gameObject.SetActive (false);
		click.GetComponent<AudioSource>().Play ();
	}
	public void modotreino(){
		PlayerPrefs.SetInt ("selectarena", 1);
		Application.LoadLevel ("procurar_user2");
	
		click.GetComponent<AudioSource>().Play ();
	}
	// Use this for initialization
	void Start () {


		nameuser = PlayerPrefs.GetString("player");
		if (nameuser == "") {
		
			PlayerPrefs.SetString ("player", "Player");
		
		}
		hr = System.DateTime.Now.Hour;
		dy = System.DateTime.Now.Day;
		sc = System.DateTime.Now.Second;
		mm = System.DateTime.Now.Minute;
		year = System.DateTime.Now.Year;
		PlayerPrefs.SetInt("net_ano", year);
		PlayerPrefs.SetInt("net_dia", dy);
		PlayerPrefs.SetInt("net_hora", hr);
		PlayerPrefs.SetInt("net_minuto", mm);
		PlayerPrefs.SetInt("net_segundo", sc);
		dia = System.DateTime.Now.Day.ToString ();
		dia1 = System.DateTime.Now.Day.ToString ();
		
		dia_conf = PlayerPrefs.GetString ("dia");
		dia_conf1 = PlayerPrefs.GetString ("dia1");
		
		if (dia1 != dia_conf1) {
			//lifehoras.gameObject.active = true;
			PlayerPrefs.SetString ("dia1", dia1);
			dia1 = System.DateTime.Now.Day.ToString ();
			
		}
	


		selecionada = PlayerPrefs.GetInt("selectarena");
		arenas.sprite = aren[selecionada];
		namearena.text = "Arena " + selecionada.ToString();

		contador = 0;
		posicao = 2;

		pos1 = 0;
		pos2 = 0;
		pos3 = 0;
		pos4 = 0;
		pos5 = 0;
		pos6 = 0;
		pos7 = 0;
		pos8 = 0;
		PlayerPrefs.SetInt ("modo1", 1);
		modo1 = PlayerPrefs.GetInt("modo1");
		cartaescolhida = PlayerPrefs.GetInt("cartaescolhida");
		//PlayerPrefs.SetInt ("codigo_hero16", 1);
		quantdcartas = PlayerPrefs.GetInt ("qtd1") + PlayerPrefs.GetInt ("qtd2") + PlayerPrefs.GetInt ("qtd3") + PlayerPrefs.GetInt ("qtd4") + PlayerPrefs.GetInt ("qtd5") + PlayerPrefs.GetInt ("qtd6") + PlayerPrefs.GetInt ("qtd7") + PlayerPrefs.GetInt ("qtd8") + PlayerPrefs.GetInt ("qtd9") + PlayerPrefs.GetInt ("qtd10") + PlayerPrefs.GetInt ("qtd11") + PlayerPrefs.GetInt ("qtd12") + PlayerPrefs.GetInt ("qtd13") + PlayerPrefs.GetInt ("qtd14") + PlayerPrefs.GetInt ("qtd15") + PlayerPrefs.GetInt ("qtd16") + PlayerPrefs.GetInt ("qtd17") + PlayerPrefs.GetInt ("qtd18") + PlayerPrefs.GetInt ("qtd19") + PlayerPrefs.GetInt ("qtd20") + PlayerPrefs.GetInt ("qtd21") + PlayerPrefs.GetInt ("qtd22") + PlayerPrefs.GetInt ("qtd23") + PlayerPrefs.GetInt ("qtd24") + PlayerPrefs.GetInt ("qtd25") + PlayerPrefs.GetInt ("qtd26");
		day1 = PlayerPrefs.GetInt ("net_dia");
		hour1 = PlayerPrefs.GetInt ("net_hora");
		min1 = PlayerPrefs.GetInt ("net_minuto");
		sec1 = PlayerPrefs.GetInt ("net_segundo");
		
		
		minutes1 = min1;
		minutes2 = min1;
		
		seconds1 = sec1;
		seconds2 = sec1;


		hor = System.DateTime.Now.Hour.ToString ();
		hor1 = System.DateTime.Now.Hour.ToString ();
		hor_conf = PlayerPrefs.GetString ("hor");
		hor_conf1 = PlayerPrefs.GetString ("hor1");
		
		if (hor1 != hor_conf1) {
			chestfreeliberado.gameObject.active = true;
			PlayerPrefs.SetString ("hor1", hor1);
			hor1 = System.DateTime.Now.Hour.ToString ();
			gameTimer = 0;
			PlayerPrefs.SetFloat("tempo", gameTimer);
			
		}
		if (hor1 == hor_conf1) {
			
			gameTimer = 3600 - min1 * 60;
			PlayerPrefs.SetFloat("tempo", gameTimer);
			
		}
		
		
		
		
	
		StartCoroutine (checar ());
		//----------------------------------------------------
		

		
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.2f);
		arenas.sprite = aren[selecionada];


		gameTimer = PlayerPrefs.GetFloat("tempo");
		if (selecionada == 0) {
		
			PlayerPrefs.SetInt("selectarena", 1);
			arenas.sprite = aren[selecionada];
		}

		if (vitorias <= 0) {
		
			PlayerPrefs.SetInt("vitoria", 0);

		
		}	
		if (coroas <= 0) {
			
			PlayerPrefs.SetInt("coroas", 0);
			
			
		}
		
		if (leveljogo == 0) {
			
		
			PlayerPrefs.SetInt("leveljogo", 1);
		}
		if (xp >= maxp) {
			
			xp = 0;
			PlayerPrefs.SetInt("xp", 0);
			leveljogo = leveljogo + 1;
			PlayerPrefs.SetInt("leveljogo", leveljogo);
		}
		
		yield break;
		
	}
	public void menu_battle(){


		telabatle.gameObject.SetActive (true);
		teladeck.gameObject.SetActive (false);
		telaloja.gameObject.SetActive (false);
		arenas_tela.gameObject.SetActive (false);
		click2.GetComponent<AudioSource>().Play ();
	}
	public void menu_store(){

		arenas_tela.gameObject.SetActive (false);
		telabatle.gameObject.SetActive (false);
		teladeck.gameObject.SetActive (false);
		telaloja.gameObject.SetActive (true);
		click2.GetComponent<AudioSource>().Play ();
		
	}
	public void menu_deck(){

		arenas_tela.gameObject.SetActive (false);
		telabatle.gameObject.SetActive (false);
		teladeck.gameObject.SetActive (true);
		telaloja.gameObject.SetActive (false);
		click2.GetComponent<AudioSource>().Play ();
		
	}
	IEnumerator normalize1 () {
		
		yield return new WaitForSeconds(0.2f);
		
		mexe.GetComponent<Animation> ().Play ("normal1");
		mexe2.GetComponent<Animation> ().Play ("normal2");
		mexe3.GetComponent<Animation> ().Play ("normal3");
		mexe4.GetComponent<Animation> ().Play ("normal4");
		mexe5.GetComponent<Animation> ().Play ("normal5");
		mexe6.GetComponent<Animation> ().Play ("normal6");
		mexe7.GetComponent<Animation> ().Play ("normal7");
		mexe8.GetComponent<Animation> ().Play ("normal8");
		PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
		
		PlayerPrefs.SetInt("sok1", cartaescolhida);
		PlayerPrefs.SetInt("modo1", 1);
		
		
		yield break;
		
	}
	IEnumerator normalize2 () {
		
		yield return new WaitForSeconds(0.2f);
		
		mexe.GetComponent<Animation> ().Play ("normal1");
		mexe2.GetComponent<Animation> ().Play ("normal2");
		mexe3.GetComponent<Animation> ().Play ("normal3");
		mexe4.GetComponent<Animation> ().Play ("normal4");
		mexe5.GetComponent<Animation> ().Play ("normal5");
		mexe6.GetComponent<Animation> ().Play ("normal6");
		mexe7.GetComponent<Animation> ().Play ("normal7");
		mexe8.GetComponent<Animation> ().Play ("normal8");
		PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
		
		PlayerPrefs.SetInt("sok2", cartaescolhida);
		PlayerPrefs.SetInt("modo1", 1);
		
		
		yield break;
		
	}
	IEnumerator normalize3 () {
		
		yield return new WaitForSeconds(0.2f);
		
		mexe.GetComponent<Animation> ().Play ("normal1");
		mexe2.GetComponent<Animation> ().Play ("normal2");
		mexe3.GetComponent<Animation> ().Play ("normal3");
		mexe4.GetComponent<Animation> ().Play ("normal4");
		mexe5.GetComponent<Animation> ().Play ("normal5");
		mexe6.GetComponent<Animation> ().Play ("normal6");
		mexe7.GetComponent<Animation> ().Play ("normal7");
		mexe8.GetComponent<Animation> ().Play ("normal8");
		PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
		
		PlayerPrefs.SetInt("sok3", cartaescolhida);
		PlayerPrefs.SetInt("modo1", 1);
		
		
		yield break;
		
	}
	IEnumerator normalize4 () {
		
		yield return new WaitForSeconds(0.2f);
		
		mexe.GetComponent<Animation> ().Play ("normal1");
		mexe2.GetComponent<Animation> ().Play ("normal2");
		mexe3.GetComponent<Animation> ().Play ("normal3");
		mexe4.GetComponent<Animation> ().Play ("normal4");
		mexe5.GetComponent<Animation> ().Play ("normal5");
		mexe6.GetComponent<Animation> ().Play ("normal6");
		mexe7.GetComponent<Animation> ().Play ("normal7");
		mexe8.GetComponent<Animation> ().Play ("normal8");
		PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
		
		PlayerPrefs.SetInt("sok4", cartaescolhida);
		PlayerPrefs.SetInt("modo1", 1);
		
		
		yield break;
		
	}
	IEnumerator normalize5 () {
		
		yield return new WaitForSeconds(0.2f);
		
		mexe.GetComponent<Animation> ().Play ("normal1");
		mexe2.GetComponent<Animation> ().Play ("normal2");
		mexe3.GetComponent<Animation> ().Play ("normal3");
		mexe4.GetComponent<Animation> ().Play ("normal4");
		mexe5.GetComponent<Animation> ().Play ("normal5");
		mexe6.GetComponent<Animation> ().Play ("normal6");
		mexe7.GetComponent<Animation> ().Play ("normal7");
		mexe8.GetComponent<Animation> ().Play ("normal8");
		PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
		
		PlayerPrefs.SetInt("sok5", cartaescolhida);
		PlayerPrefs.SetInt("modo1", 1);
		
		
		yield break;
		
	}
	IEnumerator normalize6 () {
		
		yield return new WaitForSeconds(0.2f);
		
		mexe.GetComponent<Animation> ().Play ("normal1");
		mexe2.GetComponent<Animation> ().Play ("normal2");
		mexe3.GetComponent<Animation> ().Play ("normal3");
		mexe4.GetComponent<Animation> ().Play ("normal4");
		mexe5.GetComponent<Animation> ().Play ("normal5");
		mexe6.GetComponent<Animation> ().Play ("normal6");
		mexe7.GetComponent<Animation> ().Play ("normal7");
		mexe8.GetComponent<Animation> ().Play ("normal8");
		PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
		
		PlayerPrefs.SetInt("sok6", cartaescolhida);
		PlayerPrefs.SetInt("modo1", 1);
		
		
		yield break;
		
	}

	IEnumerator normalize7 () {
		
		yield return new WaitForSeconds(0.2f);
		
		mexe.GetComponent<Animation> ().Play ("normal1");
		mexe2.GetComponent<Animation> ().Play ("normal2");
		mexe3.GetComponent<Animation> ().Play ("normal3");
		mexe4.GetComponent<Animation> ().Play ("normal4");
		mexe5.GetComponent<Animation> ().Play ("normal5");
		mexe6.GetComponent<Animation> ().Play ("normal6");
		mexe7.GetComponent<Animation> ().Play ("normal7");
		mexe8.GetComponent<Animation> ().Play ("normal8");
		PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
		
		PlayerPrefs.SetInt("sok7", cartaescolhida);
		PlayerPrefs.SetInt("modo1", 1);
		
		
		yield break;
		
	}

	IEnumerator normalize8 () {
		
		yield return new WaitForSeconds(0.2f);
		
		mexe.GetComponent<Animation> ().Play ("normal1");
		mexe2.GetComponent<Animation> ().Play ("normal2");
		mexe3.GetComponent<Animation> ().Play ("normal3");
		mexe4.GetComponent<Animation> ().Play ("normal4");
		mexe5.GetComponent<Animation> ().Play ("normal5");
		mexe6.GetComponent<Animation> ().Play ("normal6");
		mexe7.GetComponent<Animation> ().Play ("normal7");
		mexe8.GetComponent<Animation> ().Play ("normal8");
		PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
		
		PlayerPrefs.SetInt("sok8", cartaescolhida);
		PlayerPrefs.SetInt("modo1", 1);
		
		
		yield break;
		
	}
	public void details1(){
	

	
	
	}

	public void socket1_hero(){
		if (modo1 == 2) {

		
			PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
			
			PlayerPrefs.SetInt("sok1", cartaescolhida);
			PlayerPrefs.SetInt("modo1", 1);
			mexe.GetComponent<Animation> ().Play ("normal1");
			StartCoroutine(normalize1());


			
		}
		if (modo1 == 1) {
			mexe.GetComponent<Animation> ().Play ("deatlhes");
			button_info1.gameObject.SetActive (true);
			barraevolu1.gameObject.SetActive (false);
			luz1.gameObject.SetActive (true);
			PlayerPrefs.SetInt("info", sok1);
			pos1 = 2;

			if (pos2 == 2) {
		
				mexe2.GetComponent<Animation> ().Play ("detalhe2a");
				pos2 = 1;
		
			}
			if (pos3 == 2) {
			
				mexe3.GetComponent<Animation> ().Play ("detalhe3a");
				pos3 = 1;
			}
			if (pos4 == 2) {
			
				mexe4.GetComponent<Animation> ().Play ("detalhe4a");
				pos4 = 1;
			}
			if (pos5 == 2) {
			
				mexe5.GetComponent<Animation> ().Play ("detalhe5a");
				pos5 = 1;
			}
			if (pos6 == 2) {
			
				mexe6.GetComponent<Animation> ().Play ("detalhe6a");
				pos6 = 1;
			}
			if (pos7 == 2) {
				pos7 = 1;
				mexe7.GetComponent<Animation> ().Play ("detalhe7a");
			
			}
			if (pos8 == 2) {
				pos8 = 1;
				mexe8.GetComponent<Animation> ().Play ("detalhe8a");
			
			}
		}
		
	}

	public void socket2_hero(){
		if (modo1 == 2) {

		
			PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
			PlayerPrefs.SetInt("sok2", cartaescolhida);
			PlayerPrefs.SetInt("modo1", 1);
			mexe2.GetComponent<Animation> ().Play ("normal2");
			StartCoroutine(normalize2());
		}
		if (modo1 == 1) {
			mexe2.GetComponent<Animation> ().Play ("detalhe2");
			button_info2.gameObject.SetActive (true);
			barraevolu2.gameObject.SetActive (false);
			luz2.gameObject.SetActive (true);
			PlayerPrefs.SetInt("info", sok2);

			pos2 = 2;

			if (pos1 == 2) {
				pos1 = 1;
				mexe.GetComponent<Animation> ().Play ("deatlhes1");
			
			}
			if (pos3 == 2) {
				pos3 = 1;
				mexe3.GetComponent<Animation> ().Play ("detalhe3a");
			
			}
			if (pos4 == 2) {
				pos4 = 1;
				mexe4.GetComponent<Animation> ().Play ("detalhe4a");
			
			}
			if (pos5 == 2) {
				pos5 = 1;
				mexe5.GetComponent<Animation> ().Play ("detalhe5a");
			
			}
			if (pos6 == 2) {
				pos6 = 1;
				mexe6.GetComponent<Animation> ().Play ("detalhe6a");
			
			}
			if (pos7 == 2) {
				pos7 = 1;
				mexe7.GetComponent<Animation> ().Play ("detalhe7a");
			
			}
			if (pos8 == 2) {
				pos8 = 1;
				mexe8.GetComponent<Animation> ().Play ("detalhe8a");
			
			}
		}
		
	}

	public void socket3_hero(){
		if (modo1 == 2) {

			PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
			StartCoroutine(normalize3());
			PlayerPrefs.SetInt("sok3", cartaescolhida);
			PlayerPrefs.SetInt("modo1", 1);
			mexe3.GetComponent<Animation> ().Play ("normal3");
		}

		if (modo1 == 1) {
			mexe3.GetComponent<Animation> ().Play ("detalhe3");
			button_info3.gameObject.SetActive (true);
			barraevolu3.gameObject.SetActive (false);
			luz3.gameObject.SetActive (true);
			PlayerPrefs.SetInt("info", sok3);
			pos3 = 2;

			if (pos1 == 2) {
				pos1 = 1;
				mexe.GetComponent<Animation> ().Play ("deatlhes1");
			
			}
			if (pos2 == 2) {
				pos2 = 1;
				mexe2.GetComponent<Animation> ().Play ("detalhe2a");
			
			}
			if (pos4 == 2) {
				pos4 = 1;
				mexe4.GetComponent<Animation> ().Play ("detalhe4a");
			
			}
			if (pos5 == 2) {
				pos5 = 1;
				mexe5.GetComponent<Animation> ().Play ("detalhe5a");
			
			}
			if (pos6 == 2) {
				pos6 = 1;
				mexe6.GetComponent<Animation> ().Play ("detalhe6a");
			
			}
			if (pos7 == 2) {
			
				mexe7.GetComponent<Animation> ().Play ("detalhe7a");
				pos7 = 1;
			}
			if (pos8 == 2) {
				pos8 = 1;
				mexe8.GetComponent<Animation> ().Play ("detalhe8a");
			
			}
		}
		
	}

	public void socket4_hero(){
		if (modo1 == 2) {

			StartCoroutine(normalize4());
			PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
			PlayerPrefs.SetInt("sok4", cartaescolhida);
			PlayerPrefs.SetInt("modo1", 1);
			mexe4.GetComponent<Animation> ().Play ("normal4");
		}
		if (modo1 == 1) {
			mexe4.GetComponent<Animation> ().Play ("detalhe4");
			button_info4.gameObject.SetActive (true);
			barraevolu4.gameObject.SetActive (false);
			luz4.gameObject.SetActive (true);
			PlayerPrefs.SetInt("info", sok4);
			pos4 = 2;
			if (pos1 == 2) {
				pos1 = 1;
				mexe.GetComponent<Animation> ().Play ("deatlhes1");
			
			}
			if (pos3 == 2) {
				pos3 = 1;
				mexe3.GetComponent<Animation> ().Play ("detalhe3a");
			
			}
			if (pos2 == 2) {
				pos2 = 1;
				mexe2.GetComponent<Animation> ().Play ("detalhe2a");
			
			}
			if (pos5 == 2) {
				pos5 = 1;
				mexe5.GetComponent<Animation> ().Play ("detalhe5a");
			
			}
			if (pos6 == 2) {
				pos6 = 1;
				mexe6.GetComponent<Animation> ().Play ("detalhe6a");
			
			}
			if (pos7 == 2) {
				pos7 = 1;
				mexe7.GetComponent<Animation> ().Play ("detalhe7a");
			
			}
			if (pos8 == 2) {
				pos8 = 1;
				mexe8.GetComponent<Animation> ().Play ("detalhe8a");
			
			}
		}
		
	}

	public void socket5_hero(){
		if (modo1 == 2) {
		
			PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
			StartCoroutine(normalize5());
			PlayerPrefs.SetInt("sok5", cartaescolhida);
			PlayerPrefs.SetInt("modo1", 1);
			mexe5.GetComponent<Animation> ().Play ("normal5");
		}
		if (modo1 == 1) {
			pos5 = 2;
			mexe5.GetComponent<Animation> ().Play ("detalhe5");
			button_info5.gameObject.SetActive (true);
			barraevolu5.gameObject.SetActive (false);
			luz5.gameObject.SetActive (true);
			PlayerPrefs.SetInt("info", sok5);

			if (pos1 == 2) {
				pos1 = 1;
				mexe.GetComponent<Animation> ().Play ("deatlhes1");
			
			}
			if (pos3 == 2) {
				pos3 = 1;
				mexe3.GetComponent<Animation> ().Play ("detalhe3a");
			
			}
			if (pos4 == 2) {
				pos4 = 1;
				mexe4.GetComponent<Animation> ().Play ("detalhe4a");
			
			}
			if (pos2 == 2) {
				pos2 = 1;
				mexe2.GetComponent<Animation> ().Play ("detalhe2a");
			
			}
			if (pos6 == 2) {
				pos6 = 1;
				mexe6.GetComponent<Animation> ().Play ("detalhe6a");
			
			}
			if (pos7 == 2) {
				pos7 = 1;
				mexe7.GetComponent<Animation> ().Play ("detalhe7a");
			
			}
			if (pos8 == 2) {
				pos8 = 1;
				mexe8.GetComponent<Animation> ().Play ("detalhe8a");
			
			}
		}
	}

	public void socket6_hero(){
		if (modo1 == 2) {

			PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
			StartCoroutine(normalize6());
			PlayerPrefs.SetInt("sok6", cartaescolhida);
			PlayerPrefs.SetInt("modo1", 1);
			mexe6.GetComponent<Animation> ().Play ("normal6");
		}
		if (modo1 == 1) {
			mexe6.GetComponent<Animation> ().Play ("detalhe6");
			button_info6.gameObject.SetActive (true);
			barraevolu6.gameObject.SetActive (false);
			luz6.gameObject.SetActive (true);
			pos6 = 2;
			PlayerPrefs.SetInt("info", sok6);
			if (pos1 == 2) {
				pos1 = 1;
				mexe.GetComponent<Animation> ().Play ("deatlhes1");
			
			}
			if (pos3 == 2) {
				pos3 = 1;
				mexe3.GetComponent<Animation> ().Play ("detalhe3a");
			
			}
			if (pos4 == 2) {
				pos4 = 1;
				mexe4.GetComponent<Animation> ().Play ("detalhe4a");
			
			}
			if (pos5 == 2) {
				pos5 = 1;
				mexe5.GetComponent<Animation> ().Play ("detalhe5a");
			
			}
			if (pos2 == 2) {
				pos2 = 1;
				mexe2.GetComponent<Animation> ().Play ("detalhe2a");
			
			}
			if (pos7 == 2) {
				pos7 = 1;
				mexe7.GetComponent<Animation> ().Play ("detalhe7a");
			
			}
			if (pos8 == 2) {
				pos8 = 1;
				mexe8.GetComponent<Animation> ().Play ("detalhe8a");
			
			}
		}
		
	}

	public void socket7_hero(){

		if (modo1 == 2) {
			StartCoroutine(normalize7());

			PlayerPrefs.SetInt("sok7", cartaescolhida);
			PlayerPrefs.SetInt("modo1", 1);
			mexe7.GetComponent<Animation> ().Play ("normal7");
			PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
		}
		if (modo1 == 1) {
			pos7 = 2;
			mexe7.GetComponent<Animation> ().Play ("detalhe7");
			button_info7.gameObject.SetActive (true);
			barraevolu7.gameObject.SetActive (false);
			luz7.gameObject.SetActive (true);
			PlayerPrefs.SetInt("info", sok7);

			if (pos1 == 2) {
				pos1 = 1;
				mexe.GetComponent<Animation> ().Play ("deatlhes1");
			
			}
			if (pos3 == 2) {
				pos3 = 1;
				mexe3.GetComponent<Animation> ().Play ("detalhe3a");
			
			}
			if (pos4 == 2) {
				pos4 = 1;
				mexe4.GetComponent<Animation> ().Play ("detalhe4a");
			
			}
			if (pos5 == 2) {
				pos5 = 1;
				mexe5.GetComponent<Animation> ().Play ("detalhe5a");
			
			}
			if (pos6 == 2) {
				pos6 = 1;
				mexe6.GetComponent<Animation> ().Play ("detalhe6a");
			
			}
			if (pos2 == 2) {
				pos2 = 1;
				mexe2.GetComponent<Animation> ().Play ("detalhe2a");
			
			}
			if (pos8 == 2) {
				pos8 = 1;
				mexe8.GetComponent<Animation> ().Play ("detalhe8a");
			
			}
		}
		
	}

	public void socket8_hero(){
		if (modo1 == 2) {
			StartCoroutine(normalize8());

			PlayerPrefs.SetInt("sok8", cartaescolhida);
			PlayerPrefs.SetInt("codigo_hero" + cartaescolhida, 2);
			PlayerPrefs.SetInt("modo1", 1);
			mexe8.GetComponent<Animation> ().Play ("normal8");
		}

		if (modo1 == 1) {
			mexe8.GetComponent<Animation> ().Play ("detalhe8");
			button_info8.gameObject.SetActive (true);
			barraevolu8.gameObject.SetActive (false);
			luz8.gameObject.SetActive (true);
			PlayerPrefs.SetInt("info", sok8);
			pos8 = 2;
			if (pos1 == 2) {
				pos1 = 1;
				mexe.GetComponent<Animation> ().Play ("deatlhes1");
			
			}
			if (pos3 == 2) {
				pos3 = 1;
				mexe3.GetComponent<Animation> ().Play ("detalhe3a");
			
			}
			if (pos4 == 2) {
				pos4 = 1;
				mexe4.GetComponent<Animation> ().Play ("detalhe4a");
			
			}
			if (pos5 == 2) {
				pos5 = 1;
				mexe5.GetComponent<Animation> ().Play ("detalhe5a");
			
			}
			if (pos6 == 2) {
				pos6 = 1;
				mexe6.GetComponent<Animation> ().Play ("detalhe6a");
			
			}
			if (pos7 == 2) {
				pos7 = 1;
				mexe7.GetComponent<Animation> ().Play ("detalhe7a");
			
			}
			if (pos2 == 2) {
				pos2 = 1;
				mexe2.GetComponent<Animation> ().Play ("detalhe2a");
			
			}
		}
		
	}
	public void chamarequip(){
	
		telaequip.gameObject.SetActive (true);

	}
	public void chestcoroa(){
	
		if (chestcoroaliberado.gameObject.active == true) {
			PlayerPrefs.SetInt ("coroas", 0);
			Application.LoadLevel("bauouro");


		
		
		}

	
	}
	public void chestfree(){
		
		if (chestfreeliberado.gameObject.active == true) {
			
			Application.LoadLevel("baumadeira");
	

			contador = 0;
			
			
			
		}
		
		
	}
	public void chamarbattle(){
		/*
		if (nameuser != "Player") {
			Application.LoadLevel ("procurando_user");
		}
		if (nameuser == "Player") {
			Application.LoadLevel ("procurar_user2");
		
		}*/
		
		if(GooglePlayConnection.state == GPConnectionState.STATE_CONNECTED) {
			Application.LoadLevel ("procurando_user");

			
		} else {
			alert_semnet.gameObject.SetActive(true);

		}



		
	}

	public void modoonline(){
	
		Application.LoadLevel ("load_inicial");
	}

	public void offline(){

		Application.LoadLevel ("procurar_user2");

	}
	public void fecharequip(){
		
		telaequip.gameObject.SetActive (false);
		
	}
	public void rank1(){
		
		Application.LoadLevel ("ranking");
		
	}
	public void fechar(){

		modo1 = 1;
		PlayerPrefs.SetInt ("modo1", modo1);
		mexe.GetComponent<Animation> ().Play ("normal1");
		mexe2.GetComponent<Animation> ().Play ("normal2");
		mexe3.GetComponent<Animation> ().Play ("normal3");
		mexe4.GetComponent<Animation> ().Play ("normal4");
		mexe5.GetComponent<Animation> ().Play ("normal5");
		mexe6.GetComponent<Animation> ().Play ("normal6");
		mexe7.GetComponent<Animation> ().Play ("normal7");
		mexe8.GetComponent<Animation> ().Play ("normal8");

	}
	// Update is called once per frame
	void Update () {
		namearena.text = "Arena " + selecionada.ToString();
		selecionada = PlayerPrefs.GetInt("selectarena");
		arenas.sprite = aren[selecionada];
		slot1 = PlayerPrefs.GetInt ("slot11");
		slot2 = PlayerPrefs.GetInt ("slot22");
		slot3 = PlayerPrefs.GetInt ("slot33");
		slot4 = PlayerPrefs.GetInt ("slot44");
		slot5 = PlayerPrefs.GetInt ("slot55");

		if (slot1 == 1) {
		
			bau1.gameObject.SetActive (true);
		
		} else {
		
			bau1.gameObject.SetActive (false);

		
		}

		if (slot2 == 1) {
			
			bau2.gameObject.SetActive (true);
			
		} else {
			
			bau2.gameObject.SetActive (false);
			
			
		}

		if (slot3 == 1) {
			
			bau3.gameObject.SetActive (true);
			
		} else {
			
			bau3.gameObject.SetActive (false);
			
			
		}

		if (slot4 == 1) {
			
			bau4.gameObject.SetActive (true);
			
		} else {
			
			bau4.gameObject.SetActive (false);
			
			
		}

		if (slot5 == 1) {
			
			bau5.gameObject.SetActive (true);
			
		} else {
			
			bau5.gameObject.SetActive (false);
			
			
		}

		nameuser = PlayerPrefs.GetString("player");
		vitorias = PlayerPrefs.GetInt ("vitoria");
		vitoriastx.text = vitorias.ToString ();
		nameusertx.text = nameuser;
		coroas = PlayerPrefs.GetInt ("coroas");
		if (coroas < 10) {
			coroatx.text = coroas.ToString () + "/10";
		} else {
		
			coroatx.text = "Get";
		
		}
		barracoroa.maxValue = 10;
		barracoroa.value = coroas;
		if (contador == 0) {
			seconds = Mathf.CeilToInt (gameTimer - Time.timeSinceLevelLoad) % 60;
			minutes = Mathf.CeilToInt (gameTimer - Time.timeSinceLevelLoad) / 60; 
		}
		
		if (seconds == 0 && minutes == 0) {
			chestfreeliberado.gameObject.SetActive(true);
			contador = 2;
		}


		if (coroas >= 10) {
		
			chestcoroaliberado.gameObject.SetActive (true);

		
		} else {
		
			chestcoroaliberado.gameObject.SetActive (false);
		
		}
		
		remainingTime = string.Format("{0:00} : {1:00}", minutes, seconds); 
		if (seconds != 0 && minutes != 0) {
			horario.text = remainingTime.ToString ();
		} else {
		
			horario.text = "Get";
		}

		totalcartas.text = quantdcartas.ToString () + "/54";

		barraxp.maxValue = maxp;
		barraxp.value = xp;
		gold = PlayerPrefs.GetInt ("gold");
		xp = PlayerPrefs.GetInt ("xp");
		gema = PlayerPrefs.GetInt ("gema");
		leveljogo = PlayerPrefs.GetInt ("leveljogo");
		goldtx.text = gold.ToString ();
		xptx.text = xp.ToString () + "/" + maxp.ToString ();
		gematx.text = gema.ToString ();
		leveltx.text = leveljogo.ToString ();

		//---------------

		remainingTime_ouro =  string.Format("{0:D2}:{1:D2}:{2:D2}", hora1, minutes1, seconds1);
		remainingTime_prata = string.Format("{0:D2}:{1:D2}:{2:D2}", hora2, minutes2, seconds2);
		
					
				
		
		
		
		if (hora1 <= 0 && seconds1 <= 0 && minutes1 <= 0) {

		
			liberaouro = 2;
			//tempoouro.text = "Get";
		} else {
			


			liberaouro = 1;
			//tempoouro.text = remainingTime_ouro.ToString ();
		}


		//-----------



		if (leveljogo == 1) {
		
			maxp = 10;
		
		}

		if (leveljogo == 2) {
			
			maxp = 30;
			
		}

		if (leveljogo == 3) {
			
			maxp = 60;
			
		}

		if (leveljogo == 4) {
			
			maxp = 90;
			
		}


		if (leveljogo == 5) {
			
			maxp = 150;
			
		}


		if (leveljogo == 6) {
			
			maxp = 220;
			
		}


		if (leveljogo == 7) {
			
			maxp = 380;
			
		}


		if (leveljogo == 8) {
			
			maxp = 630;
			
		}


		if (leveljogo == 9) {
			
			maxp = 800;
			
		}


		if (leveljogo == 10) {
			
			maxp = 1200;
			
		}


		if (leveljogo == 11) {
			
			maxp = 1450;
			
		}


		if (leveljogo == 12) {
			
			maxp = 1800;
			
		}


		if (leveljogo == 13) {
			
			maxp = 2500;
			
		}


		if (leveljogo == 14) {
			
			maxp = 4000;
			
		}


		if (leveljogo == 15) {
			
			maxp = 8000;
			
		}


		if (leveljogo == 16) {
			
			maxp = 15000;
			
		}


		if (leveljogo == 17) {
			
			maxp = 25000;
			
		}


		if (leveljogo == 18) {
			
			maxp = 40000;
			
		}


		if (leveljogo == 19) {
			
			maxp = 70000;
			
		}


		if (leveljogo == 20) {
			
			maxp = 100000;
			
		}


		sok1 = PlayerPrefs.GetInt ("sok1");
		sok2 = PlayerPrefs.GetInt ("sok2");
		sok3 = PlayerPrefs.GetInt ("sok3");
		sok4 = PlayerPrefs.GetInt ("sok4");
		sok5 = PlayerPrefs.GetInt ("sok5");
		sok6 = PlayerPrefs.GetInt ("sok6");
		sok7 = PlayerPrefs.GetInt ("sok7");
		sok8 = PlayerPrefs.GetInt ("sok8");

		if (modo1 == 2) {
		
			mexe.GetComponent<Animation> ().Play ("treme1");
			mexe2.GetComponent<Animation> ().Play ("treme2");
			mexe3.GetComponent<Animation> ().Play ("treme3");
			mexe4.GetComponent<Animation> ().Play ("treme4");
			mexe5.GetComponent<Animation> ().Play ("treme5");
			mexe6.GetComponent<Animation> ().Play ("treme6");
			mexe7.GetComponent<Animation> ().Play ("treme7");
			mexe8.GetComponent<Animation> ().Play ("treme8");
			mostrarcarta.gameObject.SetActive (true);
			teste.verticalNormalizedPosition = 1;
		
		} else {
		
			mostrarcarta.gameObject.SetActive (false);

		}


		card1a.sprite = cards[sok1];
		card2a.sprite = cards[sok2];
		card3a.sprite = cards[sok3];
		card4a.sprite = cards[sok4];
		card5a.sprite = cards[sok5];
		card6a.sprite = cards[sok6];
		card7a.sprite = cards[sok7];
		card8a.sprite = cards[sok8];

		cartaselect.sprite = cards[cartaescolhida];


		cartaescolhida = PlayerPrefs.GetInt("cartaescolhida");
		modo1 = PlayerPrefs.GetInt("modo1");


		if (card1.gameObject.active == true) {
			if(pos1 == 2){

				button_info1.gameObject.SetActive (true);
				barraevolu1.gameObject.SetActive (false);
				luz1.gameObject.SetActive (true);

				}else{

				button_info1.gameObject.SetActive (false);
				barraevolu1.gameObject.SetActive (true);
				luz1.gameObject.SetActive (false);

			}

		
		}
		//----------------------------------------------------
		if (card2.gameObject.active == true) {
			if(pos2 == 2){
				
				button_info2.gameObject.SetActive (true);
				barraevolu2.gameObject.SetActive (false);
				luz2.gameObject.SetActive (true);
				
			}else{
				
				button_info2.gameObject.SetActive (false);
				barraevolu2.gameObject.SetActive (true);
				luz2.gameObject.SetActive (false);
				
			}
			
			
		}
		//----------------------------------------------------
		if (card3.gameObject.active == true) {
			if(pos3 == 2){
				
				button_info3.gameObject.SetActive (true);
				barraevolu3.gameObject.SetActive (false);
				luz3.gameObject.SetActive (true);
				
			}else{
				
				button_info3.gameObject.SetActive (false);
				barraevolu3.gameObject.SetActive (true);
				luz3.gameObject.SetActive (false);
				
			}
			
			
		}
		//----------------------------------------------------
		if (card4.gameObject.active == true) {
			if(pos4 == 2){
				
				button_info4.gameObject.SetActive (true);
				barraevolu4.gameObject.SetActive (false);
				luz4.gameObject.SetActive (true);
				
			}else{
				
				button_info4.gameObject.SetActive (false);
				barraevolu4.gameObject.SetActive (true);
				luz4.gameObject.SetActive (false);
				
			}
			
			
		}
		//----------------------------------------------------
		if (card5.gameObject.active == true) {
			if(pos5 == 2){
				
				button_info5.gameObject.SetActive (true);
				barraevolu5.gameObject.SetActive (false);
				luz5.gameObject.SetActive (true);
				
			}else{
				
				button_info5.gameObject.SetActive (false);
				barraevolu5.gameObject.SetActive (true);
				luz5.gameObject.SetActive (false);
				
			}
			
			
		}
		//----------------------------------------------------
		if (card6.gameObject.active == true) {
			if(pos6 == 2){
				
				button_info6.gameObject.SetActive (true);
				barraevolu6.gameObject.SetActive (false);
				luz6.gameObject.SetActive (true);
				
			}else{
				
				button_info6.gameObject.SetActive (false);
				barraevolu6.gameObject.SetActive (true);
				luz6.gameObject.SetActive (false);
				
			}
			
			
		}
		//----------------------------------------------------
		if (card7.gameObject.active == true) {
			if(pos7 == 2){
				
				button_info7.gameObject.SetActive (true);
				barraevolu7.gameObject.SetActive (false);
				luz7.gameObject.SetActive (true);
				
			}else{
				
				button_info7.gameObject.SetActive (false);
				barraevolu7.gameObject.SetActive (true);
				luz7.gameObject.SetActive (false);
				
			}
			
			
		}
		//----------------------------------------------------
		if (card8.gameObject.active == true) {
			if(pos8 == 2){
				
				button_info8.gameObject.SetActive (true);
				barraevolu8.gameObject.SetActive (false);
				luz8.gameObject.SetActive (true);
				
			}else{
				
				button_info8.gameObject.SetActive (false);
				barraevolu8.gameObject.SetActive (true);
				luz8.gameObject.SetActive (false);
				
			}
			
			
		}

	}
}

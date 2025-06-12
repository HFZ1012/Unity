using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class gerenciar_jogo1 : MonoBehaviour {
	public static float gameTimer;
	public static float gameTimer2;
	//in seconds
	private string remainingTime;
	public int seconds;
	public int minutes;
	public float seconds2;
	public int minutes2;
	public Text horario;
	public static float elixir;
	public Animation camera1;
	public float regenerador;
	public float temporizador;
	public Slider energia;
	public Text valorelixir;
	public int score_laranja;
	public int score_verde;
	public Text valorlaranja;
	public Text valorverde;
	public Image card1;
	public Image card2;
	public Image card3;
	public Image card4;
	public GameObject aviso60;
	public GameObject aviso30;
	public int tutorial;
	public GameObject cotador;
	public GameObject recompensa;
	public Image cardnext;
	public int perdeuvitoria;
	public int ganhouvitoria;
	public int starter;

	public Sprite[] cards2;
	public int card_int1;
	public int card_int2;
	public int card_int3;
	public int card_int4;

	public int slot1;
	public int slot2;
	public int slot3;
	public int slot4;
	public int slot5;
	public int ouro;
	public int ouro2;
	public int vitoria1;
	public int valorbau;
	public Sprite[] baus1;
	public Image chest1;
	public Animation b1;
	public Animation b2;
	public Animation b3;
	public Animation b4;

	public Text noelixir;
	public static int fimdejogo1;
	public int position_card1;
	public int position_card2;
	public int position_card3;
	public int position_card4;
	public int soket0;
	public int soket1;
	public int soket2;
	public int soket3;
	public int soket4;
	public int soket5;
	public int soket6;
	public int soket7;
	public int soket8;
	public Slider ca1;
	public Slider ca2;
	public Slider ca3;
	public Slider ca4;

	public int nextcard;
	public int socket;
	public int estagio;
	public int socketnext;
	public AudioSource boom;
	public GameObject nomearena;
	public Animation placa_ai;
	public Animation placa_pl;
	public Animation infouser;
	public Animation telascore;
	public Animation telacartas;
	public GameObject telanegra;
	public GameObject fight;

	public string name_ai;
	public string name_player;
	public Text name_aitx;
	public Text name_aitx2;
	public Text name_playertx;
	public GameObject bonus_1;
	public GameObject elixir2x;
	public int extra;
	public GameObject fimdejogo;
	public float subita;
	public int localcard;
	public int nextsoket;

	public GameObject music1;
	public GameObject music2;


	public GameObject dest1a;
	public GameObject dest1b;
	public GameObject dest1rei;

	public GameObject dest2a;
	public GameObject dest2b;
	public GameObject dest2rei;
	public GameObject coroa1ve;
	public GameObject coroa2ve;
	public GameObject coroa3ve;
	public GameObject coroa1la;
	public GameObject coroa2la;
	public GameObject coroa3la;
	public int block1a;
	public int block1b;
	public int block1rei;

	public int block2a;
	public int block2b;
	public int block2rei;
	public static int pode;
	public string valor1;
	public int vitoria;
	public Text ganhovitoria;
	public int coroa;
	public GameObject coroalaranja;
	public GameObject coroaverde;
	public GameObject todaarea;

	public GameObject areacompleta;
	public GameObject areaesq;
	public GameObject areadir;
	public GameObject semnada;

	public GameObject areacompleta1;
	public GameObject areaesq1;
	public GameObject areadir1;
	public GameObject semnada1;

	public GameObject music3;
	public Animation trofeu;
	public Text userverde;
	public Text userlaranja;
	public AudioSource comemora;
	public GameObject bonubonus;
	public AudioSource perdeu;
	public GameObject moretime;
	public GameObject mobs;
	public GameObject veio;
	//Game Status
	public static UIController instance;
	public string comparanet;
	public string compara1;
	public string compara2;
	public string compara3;
	public string compara4;
	public int tipojogo;
	public static float gameTime; //Main game timer (in seconds). Always fixed.
	// Use this for initialization
	void Start () {


		slot1 = PlayerPrefs.GetInt ("slot11");
		slot2 = PlayerPrefs.GetInt ("slot22");
		slot3 = PlayerPrefs.GetInt ("slot33");
		slot4 = PlayerPrefs.GetInt ("slot44");
		slot5 = PlayerPrefs.GetInt ("slot55");
		ganhouvitoria = Random.Range (16, 40);
		perdeuvitoria = Random.Range (5, 12);

		tutorial = PlayerPrefs.GetInt ("tutor");
		
		if (tutorial == 1) {
			veio.gameObject.SetActive (true);
			PlayerPrefs.SetInt ("tutor", 2);


		} else {
		
			veio.gameObject.SetActive (false);
		}


		fimdejogo1 = 1;
		//areacompleta.gameObject.SetActive (false);
		pode = 1;

		block1a = 1;
		block1b = 1;
		block1rei = 1;

		block2a = 1;
		block2b = 1;
		block2rei = 1;

		StartCoroutine(selecionarproxcarta());
		//StartCoroutine(nextcard1());
		nextcard = Random.Range (1, 9);
		extra = 0;
		seconds2 = 60;
		name_ai = PlayerPrefs.GetString ("usuario");
		name_player = PlayerPrefs.GetString ("player");
		gameTimer2 = 60;
		starter = 0;
		gameTimer = 180;
		elixir = 5;
	

		position_card1 = 1;
		position_card2 = 1;
		position_card3 = 1;
		position_card4 = 1;
		regenerador = 1;
		temporizador = 4;

		soket1 = PlayerPrefs.GetInt ("sok1");
		soket2 = PlayerPrefs.GetInt ("sok2");
		soket3 = PlayerPrefs.GetInt ("sok3");
		soket4 = PlayerPrefs.GetInt ("sok4");
		soket5 = PlayerPrefs.GetInt ("sok5");
		soket6 = PlayerPrefs.GetInt ("sok6");
		soket7 = PlayerPrefs.GetInt ("sok7");
		soket8 = PlayerPrefs.GetInt ("sok8");




		card_int1 = soket1;
		card_int2 = soket2;
		card_int3 = soket3;
		card_int4 = soket4;

	
	

		StartCoroutine (parte1 ());

	}

	IEnumerator selecionarproxcarta () {
		
		yield return new WaitForSeconds(1f);
		//--------------------------------------------
		if (card_int1 == 0) {


			card_int1 = nextsoket;
				

		}
		if (card_int2 == 0) {
			
			
			card_int2 = nextsoket;
			
			
		}
		if (card_int3 == 0) {
			
			
			card_int3 = nextsoket;
			
			
		}
		if (card_int4 == 0) {
			
			
			card_int4 = nextsoket;
			
			
		}

		yield break;
		
	}
	/*IEnumerator nextcard1 () {
		
		yield return new WaitForSeconds(0.3f);
		//--------------------------------------------
	
		nextcard = Random.Range (1,8);
		if (nextsoket == card_int1) {
		
			StartCoroutine(nextcard1());
		}
		if (nextsoket == card_int2) {
			
			StartCoroutine(nextcard1());
		}
		if (nextsoket == card_int3) {
			
			StartCoroutine(nextcard1());
		}
		if (nextsoket == card_int4) {
			
			StartCoroutine(nextcard1());
		}
		
		if (valor1 == card1.sprite.texture.name) {
			
			StartCoroutine(nextcard1());
		}
		if (valor1 == card2.sprite.texture.name) {
			
			StartCoroutine(nextcard1());
		}
		if (valor1 == card3.sprite.texture.name) {
			
			StartCoroutine(nextcard1());
		}
		if (valor1 == card4.sprite.texture.name) {
			
			StartCoroutine(nextcard1());
		}

		yield break;
		
	}*/

	IEnumerator finalgame () {
		
		yield return new WaitForSeconds(2.0f);
		
		fimdejogo.gameObject.SetActive (true);
		mobs.gameObject.SetActive (false);
		StartCoroutine (confere1 ());
		telanegra.gameObject.SetActive (true);
		music3.gameObject.SetActive(false);
		camera1.GetComponent<Animation>().Play ("camera_out");
		fimdejogo1 = 2;
		StartCoroutine (placar1a ());
		StartCoroutine (placar1b ());
		yield break;
		
	}
	IEnumerator placar1a () {
		
		yield return new WaitForSeconds(1.9f);
		if (score_laranja == 1) {
		
			coroa1la.gameObject.SetActive(true);

		}
		if (score_laranja == 2) {
			
			coroa1la.gameObject.SetActive(true);
			StartCoroutine (placar2a ());
			
		}
		if (score_laranja == 3) {
			
			coroa1la.gameObject.SetActive(true);
			StartCoroutine (placar2a ());
			
		}


		yield break;
		
	}
	IEnumerator placar2a () {
		
		yield return new WaitForSeconds(0.5f);
	
		if (score_laranja == 2) {
			
			coroa2la.gameObject.SetActive(true);

			
		}
		if (score_laranja == 3) {
			
			coroa2la.gameObject.SetActive(true);
			StartCoroutine (placar3a ());
			
		}
		
		
		yield break;
		
	}
	IEnumerator placar3a () {
		
		yield return new WaitForSeconds(0.5f);

		if (score_laranja == 3) {
			
			coroa3la.gameObject.SetActive(true);

			
		}
		
		
		yield break;
		
	}
	IEnumerator placar1b () {
		
		yield return new WaitForSeconds(3f);
		if (score_verde == 1) {
			
			coroa1ve.gameObject.SetActive(true);
			
		}
		if (score_verde == 2) {
			
			coroa1ve.gameObject.SetActive(true);
			StartCoroutine (placar2b ());
			
		}
		if (score_verde == 3) {
			
			coroa1ve.gameObject.SetActive(true);
			StartCoroutine (placar2b ());
			
		}
		
		
		yield break;
		
	}
	IEnumerator placar2b () {
		
		yield return new WaitForSeconds(0.5f);
		
		if (score_verde == 2) {
			
			coroa2ve.gameObject.SetActive(true);
			
			
		}
		if (score_verde == 3) {
			
			coroa2ve.gameObject.SetActive(true);
			StartCoroutine (placar3b ());
			
		}
		
		
		yield break;
		
	}
	IEnumerator placar3b () {
		
		yield return new WaitForSeconds(0.5f);
		
		if (score_verde == 3) {
			
			coroa3ve.gameObject.SetActive(true);
			
			
		}
		
		
		yield break;
		
	}
	IEnumerator confere1 () {
		
		yield return new WaitForSeconds(2.0f);
		
		if (score_verde > score_laranja) {
		
			trofeu.GetComponent<Animation>().Play("venceverde1");
			comemora.GetComponent<AudioSource>().Play();
			bonubonus.gameObject.SetActive(true);
			PlayerPrefs.SetInt ("evoluirxp", 2);
			//------------------------------------------
			if(slot1 == 0){
				
				if(slot2 == 0){
					if(slot3 == 0){
						if(slot4 == 0){
							
							PlayerPrefs.SetInt("slot11",1);
							valorbau = 1;
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 1){
				
				if(slot2 == 0){
					if(slot3 == 0){
						if(slot4 == 0){
							valorbau = 2;
							PlayerPrefs.SetInt("slot22",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 1){
				
				if(slot2 == 1){
					if(slot3 == 0){
						if(slot4 == 0){
							valorbau = 3;
							PlayerPrefs.SetInt("slot33",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 1){
				
				if(slot2 == 1){
					if(slot3 == 1){
						if(slot4 == 0){
							valorbau = 4;
							PlayerPrefs.SetInt("slot44",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 1){
				
				if(slot2 == 1){
					if(slot3 == 1){
						if(slot4 == 1){
							if(slot5 == 1){
							valorbau = 0;
						}
					}
					}}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 0){
				
				if(slot2 == 1){
					if(slot3 == 1){
						if(slot4 == 1){
							valorbau = 1;
							PlayerPrefs.SetInt("slot11",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 0){
				
				if(slot2 == 0){
					if(slot3 == 1){
						if(slot4 == 1){
							valorbau = 1;
							PlayerPrefs.SetInt("slot11",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 1){
				
				if(slot2 == 0){
					if(slot3 == 1){
						if(slot4 == 1){
							valorbau = 2;
							PlayerPrefs.SetInt("slot22",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 1){
				
				if(slot2 == 1){
					if(slot3 == 0){
						if(slot4 == 1){
							valorbau = 3;
							PlayerPrefs.SetInt("slot33",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 0){
				
				if(slot2 == 1){
					if(slot3 == 0){
						if(slot4 == 1){
							valorbau = 1;
							PlayerPrefs.SetInt("slot11",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 0){
				
				if(slot2 == 0){
					if(slot3 == 0){
						if(slot4 == 1){
							valorbau = 1;
							PlayerPrefs.SetInt("slot11",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 1){
				
				if(slot2 == 0){
					if(slot3 == 0){
						if(slot4 == 1){
							valorbau = 2;
							PlayerPrefs.SetInt("slot22",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 1){
				
				if(slot2 == 0){
					if(slot3 == 1){
						if(slot4 == 0){
							valorbau = 2;
							PlayerPrefs.SetInt("slot22",1);
						}
					}
				}
				
			}
			//----------------------------------------
			//------------------------------------------
			if(slot1 == 1){
				
				if(slot2 == 1){
					if(slot3 == 1){
						if(slot4 == 1){
							valorbau = 5;
							PlayerPrefs.SetInt("slot55",1);
						}
					}
				}
				
			}
			//----------------------------------------
		
		}

		if (score_laranja > score_verde) {
			
			trofeu.GetComponent<Animation>().Play("vencelaranja1");
			perdeu.GetComponent<AudioSource>().Play();
		}
		
		yield break;
		
	}
	IEnumerator avisotempo() {
		
		yield return new WaitForSeconds(2.0f);
		bonus_1.gameObject.SetActive (false);
		elixir2x.gameObject.SetActive (true);
	//	extra = 2;
		
		moretime.gameObject.SetActive (false);
		yield break;
		
	}
	IEnumerator parte1 () {
		
		yield return new WaitForSeconds(2.0f);
		areacompleta.gameObject.SetActive (false);
		StartCoroutine (parte2 ());
		nomearena.gameObject.SetActive (false);
		placa_ai.GetComponent<Animation>().Play ("entra_1");
		placa_pl.GetComponent<Animation>().Play ("entra_2");
		fight.gameObject.SetActive (true);
		boom.GetComponent<AudioSource>().Play ();
		veio.gameObject.SetActive(false);

		yield break;
		
	}
	IEnumerator parte3 () {
		
		yield return new WaitForSeconds(0.5f);
		starter = 2;

		b1.GetComponent<Animation>().Play ("ca");
		b2.GetComponent<Animation>().Play ("ce");
		b3.GetComponent<Animation>().Play ("ci");
		b4.GetComponent<Animation>().Play ("co");
		fight.gameObject.SetActive (false);
		
		yield break;
		
	}
	IEnumerator soma_enemy () {
		
		yield return new WaitForSeconds(0.1f);
		score_laranja = score_laranja + 1;

		coroalaranja.gameObject.SetActive (true);
		StartCoroutine (desavisar ());
		yield break;
		
	}
	IEnumerator soma_enemy_rei () {
		
		yield return new WaitForSeconds(0.1f);
		score_laranja = score_laranja + 1;
		extra = 3;
		StartCoroutine(finalgame());
		vitoria = vitoria - perdeuvitoria;
		PlayerPrefs.SetInt ("vitoria", vitoria);
		coroalaranja.gameObject.SetActive (true);
		StartCoroutine (desavisar ());
		ganhovitoria.text = "- 8";
		yield break;
		
	}
	IEnumerator soma_player () {
		
		yield return new WaitForSeconds(0.1f);
		score_verde = score_verde + 1;
		if (slot4 == 1) {
			ouro = ouro + 1;
			PlayerPrefs.SetInt ("ouro", ouro);
		}
		if (slot5 == 1) {
			ouro2 = ouro2 + 1;
			PlayerPrefs.SetInt ("ouro2", ouro2);
		}
		coroa = coroa + 1;
		coroaverde.gameObject.SetActive (true);
		PlayerPrefs.SetInt ("coroas", coroa);
		StartCoroutine (desavisar ());
		
		yield break;
		
	}
	IEnumerator soma_player_rei () {
		
		yield return new WaitForSeconds(0.1f);
		score_verde = score_verde + 1;
		extra = 3;
		StartCoroutine(finalgame());
		vitoria = vitoria + ganhouvitoria;
		PlayerPrefs.SetInt ("vitoria", vitoria);
		vitoria1 = vitoria1 + ganhouvitoria;
		PlayerPrefs.SetInt ("vitoria1", vitoria1);
		coroa = coroa + 1;
		coroaverde.gameObject.SetActive (true);
		PlayerPrefs.SetInt ("coroas", coroa);
		if (slot4 == 1) {
			ouro = ouro + 1;
			PlayerPrefs.SetInt ("ouro", ouro);
		}
		if (slot5 == 1) {
			ouro2 = ouro2 + 1;
			PlayerPrefs.SetInt ("ouro2", ouro2);
		}
		recompensa.gameObject.SetActive (true);
		ganhovitoria.text = "+ 30";
		StartCoroutine (desavisar ());
		
		yield break;
		
	}
	IEnumerator parte2 () {
		
		yield return new WaitForSeconds(2.0f);
		
		StartCoroutine (parte3 ());

		placa_ai.GetComponent<Animation>().Play ("entra1a");
		placa_pl.GetComponent<Animation>().Play ("entra_2a");
		telanegra.gameObject.SetActive (false);
		infouser.GetComponent<Animation>().Play ("pessoal");
		telascore.GetComponent<Animation>().Play ("infolado");
		telacartas.gameObject.SetActive (true);
		telacartas.GetComponent<Animation>().Play ("entracartas");
		
		yield break;
		
	}
	IEnumerator desavisar () {
		
		yield return new WaitForSeconds(2.0f);
		aviso30.gameObject.SetActive (false);
		aviso60.gameObject.SetActive (false);
		coroalaranja.gameObject.SetActive (false);
		coroaverde.gameObject.SetActive (false);
		
		yield break;
		
	}
	void manageGameStatus (){
		if (extra == 0) {
			seconds = Mathf.CeilToInt (gameTimer - Time.timeSinceLevelLoad) % 60;
			minutes = Mathf.CeilToInt (gameTimer - Time.timeSinceLevelLoad) / 60; 
			remainingTime = string.Format("{0:00} : {1:00}", minutes, seconds); 
			horario.text = remainingTime.ToString();
		}
		if (extra == 1) {
			pode = 2;
			seconds2 -= Time.deltaTime;
			minutes2 = 0;
			remainingTime = string.Format("{0:00} : {1:00}", minutes2, seconds2); 
			horario.text = remainingTime.ToString();
		}
		if (seconds == 0 && minutes == 1) {
		
			elixir2x.gameObject.SetActive (true);
			aviso60.gameObject.SetActive(true);
			StartCoroutine(desavisar());
			music1.gameObject.SetActive(false);
			music2.gameObject.SetActive(true);
			music3.gameObject.SetActive(false);
		}
		if (seconds == 30 && minutes == 0) {
			StartCoroutine(desavisar());
			aviso30.gameObject.SetActive(true);
			music1.gameObject.SetActive(false);
			music2.gameObject.SetActive(false);
			music3.gameObject.SetActive(true);
		}
		if (seconds == 11 && minutes == 0) {
			cotador.gameObject.SetActive(true);

		}

			if (seconds2 == 0 && minutes2 == 0) {
			
				extra = 2;
			}



		if (seconds == 0 && minutes == 0) {
			if(extra == 0){
				if(score_verde == score_laranja){
				gameTimer2 = 60;
				//music1.gameObject.SetActive(false);
				//music2.gameObject.SetActive(true);
				extra = 1;
				bonus_1.gameObject.SetActive(true);
				StartCoroutine(avisotempo());
				elixir2x.gameObject.SetActive (false);
					moretime.gameObject.SetActive (true);
				}
				else{
					extra = 3;
					StartCoroutine(finalgame());
				}
			
			}
			if(extra == 2){
			
				extra = 3;
				StartCoroutine(finalgame());

			}
		}


		//elixir normal
	


	}
	// Update is called once per frame
	void Update () {

	

		chest1.sprite = baus1 [valorbau];
		comparanet = nextsoket.ToString () + "a";


		if (card_int1 == 0) {

			card_int1 = nextsoket;
					
					
		}
		if (card_int2 == 0) {
			
			card_int2 = nextsoket;
			
			
		}
		if (card_int3 == 0) {
			
			card_int3 = nextsoket;
			
			
		}
		if (card_int4 == 0) {
			
			card_int4 = nextsoket;
			
			
		}

		if (nextsoket == card_int1) {
		
			nextcard = Random.Range (1, 9);
		
		}
		if (nextsoket == card_int2) {
			
			nextcard = Random.Range (1, 9);
			
		}
		if (nextsoket == card_int3) {
			
			nextcard = Random.Range (1, 9);
			
		}
		if (nextsoket == card_int4) {
			
			nextcard = Random.Range (1, 9);
			
		}

		if (comparanet == card1.sprite.texture.name) {
			
			nextcard = Random.Range (1, 9);
			
		}
		if (comparanet == card2.sprite.texture.name) {
			
			nextcard = Random.Range (1, 9);
			
		}
		if (comparanet == card3.sprite.texture.name) {
			
			nextcard = Random.Range (1, 9);
			
		}
		if (comparanet == card4.sprite.texture.name) {
			
			nextcard = Random.Range (1, 9);
			
		}




		ouro2 = PlayerPrefs.GetInt ("ouro2");
		ouro = PlayerPrefs.GetInt ("ouro");
		coroa = PlayerPrefs.GetInt ("coroas");
		vitoria = PlayerPrefs.GetInt ("vitoria");
		vitoria1 = PlayerPrefs.GetInt ("vitoria1");

		userverde.text = name_player;
		userlaranja.text = name_ai;

		temporizador -= Time.deltaTime;
		regenerador -= Time.deltaTime;
		if (elixir < 10) {
			if (minutes >= 1) {
				if (regenerador < 0) {
					pode = 1;
					elixir = elixir + 0.2f;
					regenerador = 0.4f;
					
				}
			}
			// elixir 2x
			if (minutes < 1) {
				if (minutes > 30) {
					if (regenerador < 0) {
						pode = 2;
						//music1.gameObject.SetActive(false);
						//music2.gameObject.SetActive(true);
						elixir = elixir + 0.2f;
						regenerador = 0.3f;
					}
				}
			}


			if (minutes <= 30) {
				if (regenerador < 0) {
					pode = 2;
					//music2.gameObject.SetActive(false);
					//music3.gameObject.SetActive(true);
					elixir = elixir + 0.2f;
					regenerador = 0.2f;
				}

			}
			
		}
	
		if (dest2a.gameObject.active == false) {
			if (dest2b.gameObject.active == false) {
				
				areacompleta.gameObject.SetActive (true);
				areadir.gameObject.SetActive (false);
				areaesq.gameObject.SetActive (false);
				semnada.gameObject.SetActive (false);

				areacompleta1.gameObject.SetActive (true);
				areadir1.gameObject.SetActive (false);
				areaesq1.gameObject.SetActive (false);
				semnada1.gameObject.SetActive (false);
				
				
			}
			
			
			
		}

		if (dest2a.gameObject.active == true) {
			if (dest2b.gameObject.active == true) {
				
				areacompleta.gameObject.SetActive (false);
				areadir.gameObject.SetActive (false);
				areaesq.gameObject.SetActive (false);
				semnada.gameObject.SetActive (true);
				
				areacompleta1.gameObject.SetActive (false);
				areadir1.gameObject.SetActive (false);
				areaesq1.gameObject.SetActive (false);
				semnada1.gameObject.SetActive (true);
			}
			
			
			
		}


		if (dest2a.gameObject.active == true) {
			if (dest2b.gameObject.active == false) {

				areacompleta.gameObject.SetActive (false);
				areadir.gameObject.SetActive (true);
				areaesq.gameObject.SetActive (false);
				semnada.gameObject.SetActive (false);

				
				areacompleta1.gameObject.SetActive (false);
				areadir1.gameObject.SetActive (true);
				areaesq1.gameObject.SetActive (false);
				semnada1.gameObject.SetActive (false);


			}
		
		

		}
		if (dest2a.gameObject.active == false) {
			if (dest2b.gameObject.active == true) {
				
				areacompleta.gameObject.SetActive (false);
				areadir.gameObject.SetActive (false);
				areaesq.gameObject.SetActive (true);
				semnada.gameObject.SetActive (false);

				areacompleta1.gameObject.SetActive (false);
				areadir1.gameObject.SetActive (false);
				areaesq1.gameObject.SetActive (true);
				semnada1.gameObject.SetActive (false);
				
				
			}
			
			
			
		}


		if (score_verde >= 3) {
		
			ganhovitoria.text = "+ " + ganhouvitoria;
		
		}
		if (score_laranja >= 3) {
			
			ganhovitoria.text = "- " + perdeuvitoria;
				
		}
	
		if (block1a == 1) {
		
			if (dest1a.gameObject.active == true) {
				block1a = 2;

				StartCoroutine (soma_enemy ());
					

			}
		
		}



		if (block1b == 1) {
			
			if (dest1b.gameObject.active == true) {
				block1b = 2;
				
				StartCoroutine (soma_enemy ());
					
				
			}
			
		}


		if (block1rei == 1) {
			
			if (dest1rei.gameObject.active == true) {
				block1rei = 2;
				
				StartCoroutine (soma_enemy_rei ());

				
			}
			
		}

		if (block2a == 1) {
			
			if (dest2a.gameObject.active == true) {
				block2a = 2;
				
				StartCoroutine (soma_player ());
				

			}
			

		}
	
		if (block2b == 1) {
			
			if (dest2b.gameObject.active == true) {
				block2b = 2;
				
				StartCoroutine (soma_player ());
				
				

			
			}
		}

		if (block2rei == 1) {
			
			if (dest2rei.gameObject.active == true) {
				block2rei = 2;
				
				StartCoroutine (soma_player_rei ());
				
				
			}
			

		}

		valor1 = cardnext.sprite.texture.name + "a";

	
	

		/*
		if (valor1 == card1.sprite.texture.name) {
			
			StartCoroutine(nextcard1());
		}
		if (valor1 == card2.sprite.texture.name) {
			
			StartCoroutine(nextcard1());
		}
		if (valor1 == card3.sprite.texture.name) {
			
			StartCoroutine(nextcard1());
		}
		if (valor1 == card4.sprite.texture.name) {
			
			StartCoroutine(nextcard1());
		}*/

		cardnext.sprite = cards2 [nextsoket];
		/*
		if (nextsoket == card_int1) {
		
			StartCoroutine(nextcard1());
		}
		if (nextsoket == card_int2) {
			
			StartCoroutine(nextcard1());
		}
		if (nextsoket == card_int3) {
			
			StartCoroutine(nextcard1());
		}
		if (nextsoket == card_int4) {
			
			StartCoroutine(nextcard1());
		}
		if (card_int1 == 0) {

			StartCoroutine(selecionarproxcarta());
		}
		if (card_int2 == 0) {

			StartCoroutine(selecionarproxcarta());
		}
		if (card_int3 == 0) {
		
			StartCoroutine(selecionarproxcarta());
		}
		if (card_int4 == 0) {

			StartCoroutine(selecionarproxcarta());
		}
		*/
	
		if (nextcard == 1) {
			nextsoket = soket1;
		
		}
		if (nextcard == 2) {
			nextsoket = soket2;
			
		}
		if (nextcard == 3) {
			nextsoket = soket3;
			
		}
		if (nextcard == 4) {
			nextsoket = soket4;
			
		}
		if (nextcard == 5) {
			nextsoket = soket5;
			
		}
		if (nextcard == 6) {
			nextsoket = soket6;
			
		}
		if (nextcard == 7) {
			nextsoket = soket7;
			
		}
		if (nextcard == 8) {
			nextsoket = soket8;
			
		}
		if (nextcard == 9) {
			nextsoket = soket8;
			
		}

		manageGameStatus ();

		name_aitx.text = name_ai;
		name_aitx2.text = name_ai;
		name_playertx.text = name_player;
		energia.value = elixir;
		valorelixir.text = elixir.ToString ("#");

		valorverde.text = score_verde.ToString ();
		valorlaranja.text = score_laranja.ToString ();
		
		card1.sprite = cards2 [card_int1];

		card2.sprite = cards2 [card_int2];
		card3.sprite = cards2 [card_int3];
		card4.sprite = cards2 [card_int4];






		//-----------------------------------------------
		if (card1.sprite.texture.name == "1") {
			ca1.maxValue = 3;

			if (elixir < 3) {


				card_int1 = 27;
			}
				
		}
		if (card1.sprite.texture.name == "1a") {
			if (elixir >= 3) {
				

				card_int1 = 1;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "1") {
			ca2.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int2 = 27;
			}
			
		}
		if (card2.sprite.texture.name == "1a") {
			if (elixir >= 3) {
				
				
				card_int2 = 1;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "1") {
			ca3.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int3 = 27;
			}
			
		}
		if (card3.sprite.texture.name == "1a") {
			if (elixir >= 3) {
				
				
				card_int3 = 1;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "1") {
			ca4.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int4 = 27;
			}
			
		}
		if (card4.sprite.texture.name == "1a") {
			if (elixir >= 3) {
				
				
				card_int4 = 1;
			}
		}
		//-----------------------------------------------------
		//card2

		//-----------------------------------------------
		if (card1.sprite.texture.name == "2") {
			ca1.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int1 = 28;
			}
			
		}
		if (card1.sprite.texture.name == "2a") {
			if (elixir >= 4) {
				
				
				card_int1 = 2;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "2") {
			ca2.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int2 = 28;
			}
			
		}
		if (card2.sprite.texture.name == "2a") {
			if (elixir >= 4) {
				
				
				card_int2 = 2;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "2") {
			ca3.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int3 = 28;
			}
			
		}
		if (card3.sprite.texture.name == "2a") {
			if (elixir >= 4) {
				
				
				card_int3 = 2;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "2") {
			ca4.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int4 = 28;
			}
			
		}
		if (card4.sprite.texture.name == "2a") {
			if (elixir >= 4) {
				
				
				card_int4 = 2;
			}
		}
		//-----------------------------------------------------
		//card3
		//-----------------------------------------------
		if (card1.sprite.texture.name == "3") {
			ca1.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int1 = 29;
			}
			
		}
		if (card1.sprite.texture.name == "3a") {
			if (elixir >= 5) {
				
				
				card_int1 = 3;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "3") {
			ca2.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int2 = 29;
			}
			
		}
		if (card2.sprite.texture.name == "3a") {
			if (elixir >= 5) {
				
				
				card_int2 = 3;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "3") {
			ca3.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int3 = 29;
			}
			
		}
		if (card3.sprite.texture.name == "3a") {
			if (elixir >= 5) {
				
				
				card_int3 = 3;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "3") {
			ca4.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int4 = 29;
			}
			
		}
		if (card4.sprite.texture.name == "3a") {
			if (elixir >= 5) {
				
				
				card_int4 = 3;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "4") {
			ca1.maxValue = 4;
			if (elixir < 6) {
				
				
				card_int1 = 30;
			}
			
		}
		if (card1.sprite.texture.name == "4a") {
			if (elixir >= 6) {
				
				
				card_int1 = 4;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "4") {
			ca2.maxValue = 4;
			if (elixir < 6) {
				
				
				card_int2 = 30;
			}
			
		}
		if (card2.sprite.texture.name == "4a") {

			if (elixir >= 6) {
				
				
				card_int2 = 4;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "4") {
			ca3.maxValue = 4;
			if (elixir < 6) {
				
				
				card_int3 = 30;
			}
			
		}
		if (card3.sprite.texture.name == "4a") {
			if (elixir >= 6) {
				
				
				card_int3 = 4;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "4") {
			ca4.maxValue = 4;
			if (elixir < 6) {
				
				
				card_int4 = 30;
			}
			
		}
		if (card4.sprite.texture.name == "4a") {
			if (elixir >= 6) {
				
				
				card_int4 = 4;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "5") {
			ca1.maxValue = 5;
			if (elixir < 4) {
				
				
				card_int1 = 31;
			}
			
		}
		if (card1.sprite.texture.name == "5a") {
			if (elixir >= 4) {
				
				
				card_int1 = 5;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "5") {
			ca2.maxValue = 5;
			if (elixir < 4) {
				
				
				card_int2 = 31;
			}
			
		}
		if (card2.sprite.texture.name == "5a") {
			if (elixir >= 4) {
				
				
				card_int2 = 5;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "5") {
			ca3.maxValue = 5;
			if (elixir < 4) {
				
				
				card_int3 = 31;
			}
			
		}
		if (card3.sprite.texture.name == "5a") {
			if (elixir >= 4) {
				
				
				card_int3 = 5;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "5") {
			ca4.maxValue = 5;
			if (elixir < 4) {
				
				
				card_int4 = 31;
			}
			
		}
		if (card4.sprite.texture.name == "5a") {
			if (elixir >= 4) {
				
				
				card_int4 = 5;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "6") {
			ca1.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int1 = 32;
			}
			
		}
		if (card1.sprite.texture.name == "6a") {
			if (elixir >= 6) {
				
				
				card_int1 = 6;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "6") {
			ca2.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int2 = 32;
			}
			
		}
		if (card2.sprite.texture.name == "6a") {
			if (elixir >= 6) {
				
				
				card_int2 = 6;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "6") {
			ca3.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int3 = 32;
			}
			
		}
		if (card3.sprite.texture.name == "6a") {
			if (elixir >= 6) {
				
				
				card_int3 = 6;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "6") {
			ca4.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int4 = 32;
			}
			
		}
		if (card4.sprite.texture.name == "6a") {
			if (elixir >= 6) {
				
				
				card_int4 = 6;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "7") {
			ca1.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int1 = 33;
			}
			
		}
		if (card1.sprite.texture.name == "7a") {
			if (elixir >= 6) {
				
				
				card_int1 = 7;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "7") {
			ca2.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int2 = 33;
			}
			
		}
		if (card2.sprite.texture.name == "7a") {
			if (elixir >= 6) {
				
				
				card_int2 = 7;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "7") {
			ca3.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int3 = 33;
			}
			
		}
		if (card3.sprite.texture.name == "7a") {
			if (elixir >= 6) {
				
				
				card_int3 = 7;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "7") {
			ca4.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int4 = 33;
			}
			
		}
		if (card4.sprite.texture.name == "7a") {
			if (elixir >= 6) {
				
				
				card_int4 = 7;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "9") {
			ca1.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int1 = 35;
			}
			
		}
		if (card1.sprite.texture.name == "9a") {
			if (elixir >= 4) {
				
				
				card_int1 = 9;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "9") {
			ca2.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int2 = 35;
			}
			
		}
		if (card2.sprite.texture.name == "9a") {
			if (elixir >= 4) {
				
				
				card_int2 = 9;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "9") {
			ca3.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int3 = 35;
			}
			
		}
		if (card3.sprite.texture.name == "9a") {
			if (elixir >= 4) {
				
				
				card_int3 = 9;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "9") {
			ca4.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int4 = 35;
			}
			
		}
		if (card4.sprite.texture.name == "9a") {
			if (elixir >= 4) {
				
				
				card_int4 = 9;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "10") {
			ca1.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int1 = 36;
			}
			
		}
		if (card1.sprite.texture.name == "10a") {
			if (elixir >= 6) {
				
				
				card_int1 = 10;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "10") {
			ca2.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int2 = 36;
			}
			
		}
		if (card2.sprite.texture.name == "10a") {
			if (elixir >= 6) {
				
				
				card_int2 = 10;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "10") {
			ca3.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int3 = 36;
			}
			
		}
		if (card3.sprite.texture.name == "10a") {
			if (elixir >= 6) {
				
				
				card_int3 = 10;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "10") {
			ca4.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int4 = 36;
			}
			
		}
		if (card4.sprite.texture.name == "10a") {
			if (elixir >= 6) {
				
				
				card_int4 = 10;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "11") {
			ca1.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int1 = 37;
			}
			
		}
		if (card1.sprite.texture.name == "11a") {
			if (elixir >= 3) {
				
				
				card_int1 = 11;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "11") {
			ca2.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int2 = 37;
			}
			
		}
		if (card2.sprite.texture.name == "11a") {
			if (elixir >= 3) {
				
				
				card_int2 = 11;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "11") {
			ca3.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int3 = 37;
			}
			
		}
		if (card3.sprite.texture.name == "11a") {
			if (elixir >= 3) {
				
				
				card_int3 = 11;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "11") {
			ca4.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int4 = 37;
			}
			
		}
		if (card4.sprite.texture.name == "11a") {
			if (elixir >= 3) {
				
				
				card_int4 = 11;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "12") {
			ca1.maxValue = 8;
			if (elixir < 8) {
				
				
				card_int1 = 38;
			}
			
		}
		if (card1.sprite.texture.name == "12a") {
			if (elixir >= 8) {
				
				
				card_int1 = 12;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "12") {
			ca2.maxValue = 8;
			if (elixir < 8) {
				
				
				card_int2 = 38;
			}
			
		}
		if (card2.sprite.texture.name == "12a") {
			if (elixir >= 8) {
				
				
				card_int2 = 12;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "12") {
			ca3.maxValue = 8;
			if (elixir < 8) {
				
				
				card_int3 = 38;
			}
			
		}
		if (card3.sprite.texture.name == "12a") {
			if (elixir >= 8) {
				
				
				card_int3 = 12;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "12") {
			ca4.maxValue = 8;
			if (elixir < 8) {
				
				
				card_int4 = 38;
			}
			
		}
		if (card4.sprite.texture.name == "12a") {
			if (elixir >= 8) {
				
				
				card_int4 = 12;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "13") {
			ca1.maxValue = 7;
			if (elixir < 7) {
				
				
				card_int1 = 39;
			}
			
		}
		if (card1.sprite.texture.name == "13a") {
			if (elixir >= 7) {
				
				
				card_int1 = 13;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "13") {
			ca2.maxValue = 7;
			if (elixir < 7) {
				
				
				card_int2 = 39;
			}
			
		}
		if (card2.sprite.texture.name == "13a") {
			if (elixir >= 7) {
				
				
				card_int2 = 13;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "13") {
			ca3.maxValue = 7;
			if (elixir < 7) {
				
				
				card_int3 = 39;
			}
			
		}
		if (card3.sprite.texture.name == "13a") {
			if (elixir >= 7) {
				
				
				card_int3 = 13;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "13") {
			ca4.maxValue = 7;
			if (elixir < 7) {
				
				
				card_int4 = 39;
			}
			
		}
		if (card4.sprite.texture.name == "13a") {
			if (elixir >= 7) {
				
				
				card_int4 = 13;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "14") {
			ca1.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int1 = 51;
			}
			
		}
		if (card1.sprite.texture.name == "14a") {
			if (elixir >= 5) {
				
				
				card_int1 = 14;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "14") {
			ca2.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int2 = 51;
			}
			
		}
		if (card2.sprite.texture.name == "14a") {
			if (elixir >= 5) {
				
				
				card_int2 = 14;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "14") {
			ca3.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int3 = 51;
			}
			
		}
		if (card3.sprite.texture.name == "14a") {
			if (elixir >= 5) {
				
				
				card_int3 = 14;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "14") {
			ca4.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int4 = 51;
			}
			
		}
		if (card4.sprite.texture.name == "14a") {
			if (elixir >= 5) {
				
				
				card_int4 = 14;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "15") {
			ca1.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int1 = 52;
			}
			
		}
		if (card1.sprite.texture.name == "15a") {
			if (elixir >= 5) {
				
				
				card_int1 = 15;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "15") {
			ca2.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int2 = 52;
			}
			
		}
		if (card2.sprite.texture.name == "15a") {
			if (elixir >= 5) {
				
				
				card_int2 = 15;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "15") {
			ca3.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int3 = 52;
			}
			
		}
		if (card3.sprite.texture.name == "15a") {
			if (elixir >= 5) {
				
				
				card_int3 = 15;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "15") {
			ca4.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int4 = 52;
			}
			
		}
		if (card4.sprite.texture.name == "15a") {
			if (elixir >= 5) {
				
				
				card_int4 = 15;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "16") {
			ca1.maxValue = 9;
			if (elixir < 9) {
				
				
				card_int1 = 53;
			}
			
		}
		if (card1.sprite.texture.name == "16a") {
			if (elixir >= 9) {
				
				
				card_int1 = 16;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "16") {
			ca2.maxValue = 9;
			if (elixir < 9) {
				
				
				card_int2 = 53;
			}
			
		}
		if (card2.sprite.texture.name == "16a") {
			if (elixir >= 9) {
				
				
				card_int2 = 16;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "16") {
			ca3.maxValue = 9;
			if (elixir < 9) {
				
				
				card_int3 = 53;
			}
			
		}
		if (card3.sprite.texture.name == "16a") {
			if (elixir >= 9) {
				
				
				card_int3 = 16;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "16") {
			ca4.maxValue = 9;
			if (elixir < 9) {
				
				
				card_int4 = 53;
			}
			
		}
		if (card4.sprite.texture.name == "16a") {
			if (elixir >= 9) {
				
				
				card_int4 = 16;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "17") {
			ca1.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int1 = 54;
			}
			
		}
		if (card1.sprite.texture.name == "17a") {
			if (elixir >= 3) {
				
				
				card_int1 = 17;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "17") {
			ca2.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int2 = 54;
			}
			
		}
		if (card2.sprite.texture.name == "17a") {
			if (elixir >= 3) {
				
				
				card_int2 = 17;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "17") {
			ca3.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int3 = 54;
			}
			
		}
		if (card3.sprite.texture.name == "17a") {
			if (elixir >= 3) {
				
				
				card_int3 = 17;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "17") {
			ca4.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int4 = 54;
			}
			
		}
		if (card4.sprite.texture.name == "17a") {
			if (elixir >= 3) {
				
				
				card_int4 = 17;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "18") {
			ca1.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int1 = 55;
			}
			
		}
		if (card1.sprite.texture.name == "18a") {
			if (elixir >= 6) {
				
				
				card_int1 = 18;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "18") {
			ca2.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int2 = 55;
			}
			
		}
		if (card2.sprite.texture.name == "18a") {
			if (elixir >= 6) {
				
				
				card_int2 = 18;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "18") {
			ca3.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int3 = 55;
			}
			
		}
		if (card3.sprite.texture.name == "18a") {
			if (elixir >= 6) {
				
				
				card_int3 = 18;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "18") {
			ca4.maxValue = 6;
			if (elixir < 6) {
				
				
				card_int4 = 55;
			}
			
		}
		if (card4.sprite.texture.name == "18a") {
			if (elixir >= 6) {
				
				
				card_int4 = 18;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "19") {
			ca1.maxValue = 2;
			if (elixir < 2) {
				
				
				card_int1 = 56;
			}
			
		}
		if (card1.sprite.texture.name == "19a") {
			if (elixir >= 2) {
				
				
				card_int1 = 19;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "19") {
			ca2.maxValue = 2;
			if (elixir < 2) {
				
				
				card_int2 = 56;
			}
			
		}
		if (card2.sprite.texture.name == "19a") {
			if (elixir >= 2) {
				
				
				card_int2 = 19;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "19") {
			ca3.maxValue = 2;
			if (elixir < 2) {
				
				
				card_int3 = 56;
			}
			
		}
		if (card3.sprite.texture.name == "19a") {
			if (elixir >= 2) {
				
				
				card_int3 = 19;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "19") {
			ca4.maxValue = 2;
			if (elixir < 2) {
				
				
				card_int4 = 56;
			}
			
		}
		if (card4.sprite.texture.name == "19a") {
			if (elixir >= 2) {
				
				
				card_int4 = 19;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "20") {
			ca1.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int1 = 57;
			}
			
		}
		if (card1.sprite.texture.name == "20a") {
			if (elixir >= 5) {
				
				
				card_int1 = 20;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "20") {
			ca2.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int2 = 57;
			}
			
		}
		if (card2.sprite.texture.name == "20a") {
			if (elixir >= 5) {
				
				
				card_int2 = 20;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "20") {
			ca3.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int3 = 57;
			}
			
		}
		if (card3.sprite.texture.name == "20a") {
			if (elixir >= 5) {
				
				
				card_int3 = 20;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "20") {
			ca4.maxValue = 5;
			if (elixir < 5) {
				
				
				card_int4 = 57;
			}
			
		}
		if (card4.sprite.texture.name == "20a") {
			if (elixir >= 5) {
				
				
				card_int4 = 20;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "21") {
			ca1.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int1 = 58;
			}
			
		}
		if (card1.sprite.texture.name == "21a") {
			if (elixir >= 4) {
				
				
				card_int1 = 21;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "21") {
			ca2.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int2 = 58;
			}
			
		}
		if (card2.sprite.texture.name == "21a") {
			if (elixir >= 4) {
				
				
				card_int2 = 21;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "21") {
			ca3.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int3 = 58;
			}
			
		}
		if (card3.sprite.texture.name == "21a") {
			if (elixir >= 4) {
				
				
				card_int3 = 21;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "21") {
			ca4.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int4 = 58;
			}
			
		}
		if (card4.sprite.texture.name == "21a") {
			if (elixir >= 4) {
				
				
				card_int4 = 21;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "22") {
			ca1.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int1 = 59;
			}
			
		}
		if (card1.sprite.texture.name == "22a") {
			if (elixir >= 4) {
				
				
				card_int1 = 22;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "22") {
			ca2.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int2 = 59;;
			}
			
		}
		if (card2.sprite.texture.name == "22a") {
			if (elixir >= 4) {
				
				
				card_int2 = 22;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "22") {
			ca3.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int3 = 59;
			}
			
		}
		if (card3.sprite.texture.name == "22a") {
			if (elixir >= 4) {
				
				
				card_int3 = 22;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "22") {
			ca4.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int4 = 59;
			}
			
		}
		if (card4.sprite.texture.name == "22a") {
			if (elixir >= 4) {
				
				
				card_int4 = 22;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "23") {
			ca1.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int1 = 60;
			}
			
		}
		if (card1.sprite.texture.name == "23a") {
			if (elixir >= 4) {
				
				
				card_int1 = 23;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "23") {
			ca2.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int2 = 60;
			}
			
		}
		if (card2.sprite.texture.name == "23a") {
			if (elixir >= 4) {
				
				
				card_int2 = 23;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "23") {
			ca3.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int3 = 60;
			}
			
		}
		if (card3.sprite.texture.name == "23a") {
			if (elixir >= 4) {
				
				
				card_int3 = 23;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "23") {
			ca4.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int4 = 60;
			}
			
		}
		if (card4.sprite.texture.name == "23a") {
			if (elixir >= 4) {
				
				
				card_int4 = 23;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "24") {
			ca1.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int1 = 61;
			}
			
		}
		if (card1.sprite.texture.name == "24a") {
			if (elixir >= 4) {
				
				
				card_int1 = 24;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "24") {
			ca2.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int2 = 61;
			}
			
		}
		if (card2.sprite.texture.name == "24a") {
			if (elixir >= 4) {
				
				
				card_int2 = 24;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "24") {
			ca3.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int3 = 61;
			}
			
		}
		if (card3.sprite.texture.name == "24a") {
			if (elixir >= 4) {
				
				
				card_int3 = 24;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "24") {
			ca4.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int4 = 61;
			}
			
		}
		if (card4.sprite.texture.name == "24a") {
			if (elixir >= 4) {
				
				
				card_int4 = 24;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "25") {
			ca1.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int1 = 62;
			}
			
		}
		if (card1.sprite.texture.name == "25a") {
			if (elixir >= 4) {
				
				
				card_int1 = 25;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "25") {
			ca2.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int2 = 62;
			}
			
		}
		if (card2.sprite.texture.name == "25a") {
			if (elixir >= 4) {
				
				
				card_int2 = 25;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "25") {
			ca3.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int3 = 62;
			}
			
		}
		if (card3.sprite.texture.name == "25a") {
			if (elixir >= 4) {
				
				
				card_int3 = 25;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "25") {
			ca4.maxValue = 4;
			if (elixir < 4) {
				
				
				card_int4 = 62;
			}
			
		}
		if (card4.sprite.texture.name == "25a") {
			if (elixir >= 4) {
				
				
				card_int4 = 25;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "26") {
			ca1.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int1 = 63;
			}
			
		}
		if (card1.sprite.texture.name == "26a") {
			if (elixir >= 3) {
				
				
				card_int1 = 26;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "26") {
			ca2.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int2 = 63;
			}
			
		}
		if (card2.sprite.texture.name == "26a") {
			if (elixir >= 3) {
				
				
				card_int2 = 26;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "26") {
			ca3.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int3 = 63;
			}
			
		}
		if (card3.sprite.texture.name == "26a") {
			if (elixir >= 3) {
				
				
				card_int3 = 26;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "26") {
			ca4.maxValue = 3;
			if (elixir < 3) {
				
				
				card_int4 = 63;
			}
			
		}
		if (card4.sprite.texture.name == "26a") {
			if (elixir >= 3) {
				
				
				card_int4 = 26;
			}
		}
		//-----------------------------------------------------

		//-----------------------------------------------
		if (card1.sprite.texture.name == "8") {
			if (elixir < 3) {
				
				
				card_int1 = 34;
			}
			
		}
		if (card1.sprite.texture.name == "8a") {
			if (elixir >= 3) {
				
				
				card_int1 = 8;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "8") {
			if (elixir < 3) {
				
				
				card_int2 = 34;
			}
			
		}
		if (card2.sprite.texture.name == "8a") {
			if (elixir >= 3) {
				
				
				card_int2 = 8;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "8") {
			if (elixir < 3) {
				
				
				card_int3 = 34;
			}
			
		}
		if (card3.sprite.texture.name == "8a") {
			if (elixir >= 3) {
				
				
				card_int3 = 8;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "8") {
			if (elixir < 3) {
				
				
				card_int4 = 34;
			}
			
		}
		if (card4.sprite.texture.name == "8a") {
			if (elixir >= 3) {
				
				
				card_int4 = 8;
			}
		}
		//-----------------------------------------------------
		
		//cards2 legendary
		//-----------------------------------------------
		if (card1.sprite.texture.name == "40") {
			if (elixir < 6) {
				
				
				card_int1 = 65;
			}
			
		}
		if (card1.sprite.texture.name == "40a") {
			if (elixir >= 6) {
				
				
				card_int1 = 40;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "40") {
			if (elixir < 6) {
				
				
				card_int2 = 65;
			}
			
		}
		if (card2.sprite.texture.name == "40a") {
			if (elixir >= 6) {
				
				
				card_int2 = 40;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "40") {
			if (elixir < 6) {
				
				
				card_int3 = 65;
			}
			
		}
		if (card3.sprite.texture.name == "40a") {
			if (elixir >= 6) {
				
				
				card_int3 = 40;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "40") {
			if (elixir < 6) {
				
				
				card_int4 = 65;
			}
			
		}
		if (card4.sprite.texture.name == "40a") {
			if (elixir >= 6) {
				
				
				card_int4 = 40;
			}
		}
		//cards2 legendary2
		//-----------------------------------------------
		if (card1.sprite.texture.name == "41") {
			if (elixir < 6) {
				
				
				card_int1 = 66;
			}
			
		}
		if (card1.sprite.texture.name == "41a") {
			if (elixir >= 6) {
				
				
				card_int1 = 41;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "41") {
			if (elixir < 6) {
				
				
				card_int2 = 66;
			}
			
		}
		if (card2.sprite.texture.name == "41a") {
			if (elixir >= 6) {
				
				
				card_int2 = 41;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "41") {
			if (elixir < 6) {
				
				
				card_int3 = 66;
			}
			
		}
		if (card3.sprite.texture.name == "41a") {
			if (elixir >= 6) {
				
				
				card_int3 = 41;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "41") {
			if (elixir < 6) {
				
				
				card_int4 = 66;
			}
			
		}
		if (card4.sprite.texture.name == "41a") {
			if (elixir >= 6) {
				
				
				card_int4 = 41;
			}
		}
		//cards2 legendary
		//-----------------------------------------------
		if (card1.sprite.texture.name == "42") {
			if (elixir < 8) {
				
				
				card_int1 = 67;
			}
			
		}
		if (card1.sprite.texture.name == "42a") {
			if (elixir >= 8) {
				
				
				card_int1 = 42;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "42") {
			if (elixir < 8) {
				
				
				card_int2 = 67;
			}
			
		}
		if (card2.sprite.texture.name == "42a") {
			if (elixir >= 8) {
				
				
				card_int2 = 42;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "42") {
			if (elixir < 8) {
				
				
				card_int3 = 67;
			}
			
		}
		if (card3.sprite.texture.name == "42a") {
			if (elixir >= 8) {
				
				
				card_int3 = 42;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "42") {
			if (elixir < 8) {
				
				
				card_int4 = 67;
			}
			
		}
		if (card4.sprite.texture.name == "42a") {
			if (elixir >= 8) {
				
				
				card_int4 = 42;
			}
		}
		//cards2 legendary
		//-----------------------------------------------
		if (card1.sprite.texture.name == "46") {
			if (elixir < 9) {
				
				
				card_int1 = 70;
			}
			
		}
		if (card1.sprite.texture.name == "46a") {
			if (elixir >= 9) {
				
				
				card_int1 = 46;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "46") {
			if (elixir < 9) {
				
				
				card_int2 = 70;
			}
			
		}
		if (card2.sprite.texture.name == "46a") {
			if (elixir >= 9) {
				
				
				card_int2 = 46;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "46") {
			if (elixir < 9) {
				
				
				card_int3 = 70;
			}
			
		}
		if (card3.sprite.texture.name == "46a") {
			if (elixir >= 9) {
				
				
				card_int3 = 46;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "46") {
			if (elixir < 9) {
				
				
				card_int4 = 70;;
			}
			
		}
		if (card4.sprite.texture.name == "46a") {
			if (elixir >= 9) {
				
				
				card_int4 = 46;
			}
		}
		//cards2 legendary
		//-----------------------------------------------
		if (card1.sprite.texture.name == "44") {
			if (elixir < 3) {
				
				
				card_int1 = 44;
			}
			
		}
		if (card1.sprite.texture.name == "44a") {
			if (elixir >= 3) {
				
				
				card_int1 = 62;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "44") {
			if (elixir < 3) {
				
				
				card_int2 = 44;
			}
			
		}
		if (card2.sprite.texture.name == "44a") {
			if (elixir >= 3) {
				
				
				card_int2 = 62;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "44") {
			if (elixir < 3) {
				
				
				card_int3 = 68;
			}
			
		}
		if (card3.sprite.texture.name == "44a") {
			if (elixir >= 3) {
				
				
				card_int3 = 44;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "44") {
			if (elixir < 3) {
				
				
				card_int4 = 68;
			}
			
		}
		if (card4.sprite.texture.name == "44a") {
			if (elixir >= 3) {
				
				
				card_int4 = 44;
			}
		}
		//cards2 legendary
		//-----------------------------------------------
		if (card1.sprite.texture.name == "45") {
			if (elixir < 5) {
				
				
				card_int1 = 69;
			}
			
		}
		if (card1.sprite.texture.name == "45a") {
			if (elixir >= 5) {
				
				
				card_int1 = 45;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "45") {
			if (elixir < 5) {
				
				
				card_int2 = 69;
			}
			
		}
		if (card2.sprite.texture.name == "45a") {
			if (elixir >= 5) {
				
				
				card_int2 = 45;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "45") {
			if (elixir < 5) {
				
				
				card_int3 = 69;
			}
			
		}
		if (card3.sprite.texture.name == "45a") {
			if (elixir >= 5) {
				
				
				card_int3 = 45;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "45") {
			if (elixir < 5) {
				
				
				card_int4 = 69;
			}
			
		}
		if (card4.sprite.texture.name == "45a") {
			if (elixir >= 5) {
				
				
				card_int4 = 45;
			}
		}
		//cards2 legendary
		//-----------------------------------------------
		if (card1.sprite.texture.name == "47") {
			if (elixir < 5) {
				
				
				card_int1 = 71;
			}
			
		}
		if (card1.sprite.texture.name == "47a") {
			if (elixir >= 5) {
				
				
				card_int1 = 47;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "47") {
			if (elixir < 5) {
				
				
				card_int2 = 71;
			}
			
		}
		if (card2.sprite.texture.name == "47a") {
			if (elixir >= 5) {
				
				
				card_int2 = 47;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "47") {
			if (elixir < 5) {
				
				
				card_int3 = 71;
			}
			
		}
		if (card3.sprite.texture.name == "47a") {
			if (elixir >= 5) {
				
				
				card_int3 = 47;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "47") {
			if (elixir < 5) {
				
				
				card_int4 = 71;
			}
			
		}
		if (card4.sprite.texture.name == "47a") {
			if (elixir >= 5) {
				
				
				card_int4 = 47;
			}
		}
		//cards2 legendary
		//-----------------------------------------------
		if (card1.sprite.texture.name == "48") {
			if (elixir < 5) {
				
				
				card_int1 = 72;
			}
			
		}
		if (card1.sprite.texture.name == "48a") {
			if (elixir >= 5) {
				
				
				card_int1 = 48;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "48") {
			if (elixir < 5) {
				
				
				card_int2 = 72;
			}
			
		}
		if (card2.sprite.texture.name == "48a") {
			if (elixir >= 5) {
				
				
				card_int2 = 48;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "48") {
			if (elixir < 5) {
				
				
				card_int3 = 72;
			}
			
		}
		if (card3.sprite.texture.name == "48a") {
			if (elixir >= 5) {
				
				
				card_int3 = 48;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "48") {
			if (elixir < 5) {
				
				
				card_int4 = 72;
			}
			
		}
		if (card4.sprite.texture.name == "48a") {
			if (elixir >= 5) {
				
				
				card_int4 = 48;
			}
		}
		//cards2 legendary
		//-----------------------------------------------
		if (card1.sprite.texture.name == "49") {
			if (elixir < 5) {
				
				
				card_int1 = 73;
			}
			
		}
		if (card1.sprite.texture.name == "49a") {
			if (elixir >= 5) {
				
				
				card_int1 = 49;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "49") {
			if (elixir < 5) {
				
				
				card_int2 = 73;
			}
			
		}
		if (card2.sprite.texture.name == "49a") {
			if (elixir >= 5) {
				
				
				card_int2 = 49;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "49") {
			if (elixir < 5) {
				
				
				card_int3 = 73;
			}
			
		}
		if (card3.sprite.texture.name == "49a") {
			if (elixir >= 5) {
				
				
				card_int3 = 49;
			}
		}
		//-----------------------------------------------------
		if (card4.sprite.texture.name == "49") {
			if (elixir < 5) {
				
				
				card_int4 = 73;
			}
			
		}
		if (card4.sprite.texture.name == "49a") {
			if (elixir >= 5) {
				
				
				card_int4 = 49;
			}
		}
		//cards2 legendary
		//-----------------------------------------------
		if (card1.sprite.texture.name == "50") {
			if (elixir < 5) {
				
				
				card_int1 = 74;
			}
			
		}
		if (card1.sprite.texture.name == "50a") {
			if (elixir >= 5) {
				
				
				card_int1 = 50;
			}
		}
		//-----------------------------------------------------
		if (card2.sprite.texture.name == "50") {
			if (elixir < 5) {
				
				
				card_int2 = 74;
			}
			
		}
		if (card2.sprite.texture.name == "50a") {
			if (elixir >= 5) {
				
				
				card_int2 = 50;
			}
		}
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "50") {
			if (elixir < 5) {
				
				
				card_int3 = 74;
			}
			
		}
		if (card3.sprite.texture.name == "50a") {
			if (elixir >= 5) {
				
				
				card_int3 = 50;
			}
		}
		//-----------------------------------------------------
		//-----------------------------------------------------
		if (card3.sprite.texture.name == "50") {
			if (elixir < 5) {
				
				
				card_int3 = 74;
			}
			
		}
		if (card3.sprite.texture.name == "50a") {
			if (elixir >= 5) {
				
				
				card_int3 = 50;
			}
		}
		//-----------------------------------------------------

	}
	//CONTROLE DE HEROES

	public void select1(){
		position_card1 = 1;
		position_card2 = 2;
		position_card3 = 2;
		position_card4 = 2;
		if (position_card1 == 1) {
			b1.GetComponent<Animation>().Play ("c1");
		}
		if (position_card2 == 2) {
			
			b2.GetComponent<Animation>().Play ("c2a");
			
		}
		if (position_card3 == 2) {
			
			b3.GetComponent<Animation>().Play ("c3a");
			
		}
		if (position_card4 == 2) {
			
			b4.GetComponent<Animation>().Play ("c4a");
			
		}
	
	}


	
	public void carta1 () 
	{

		todaarea.gameObject.SetActive (true);
		if (card1.sprite.texture.name == "1") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card1.sprite = cards2 [card_int1];

				card_int1 = 0;
			
				MainController.instance.SpawnBuilding ("p1_hero1");
			}else{

				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());


			}
		}
		if (card1.sprite.texture.name == "2") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero2");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "3") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero3");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "4") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero4");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "5") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero5");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "6") {
			if(elixir >= 7){
				elixir = elixir - 7;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero6");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "7") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero7");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "8") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero8");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "9") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero9");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "10") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero10");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "11") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero11");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "12") {
			if(elixir >= 8){
				elixir = elixir - 8;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero12");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "13") {
			if(elixir >= 7){
				elixir = elixir - 7;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero13");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "14") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero14");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card1.sprite.texture.name == "15") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero15");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "16") {
			if(elixir >= 9){
				elixir = elixir - 9;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero16");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "17") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero17");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "18") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero18");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "19") {
			if(elixir >= 2){
				elixir = elixir - 2;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero19");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "20") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero20");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "21") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero21");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "22") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero22");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card1.sprite.texture.name == "23") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero23");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "24") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero24");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "25") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero25");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		if (card1.sprite.texture.name == "26") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero26");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card1.sprite.texture.name == "30") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero30");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		if (card1.sprite.texture.name == "40") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero40");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card1.sprite.texture.name == "41") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero41");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card1.sprite.texture.name == "42") {
			if(elixir >= 8){
				elixir = elixir - 8;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero42");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card1.sprite.texture.name == "44") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero44");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card1.sprite.texture.name == "45") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero45");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card1.sprite.texture.name == "46") {
			if(elixir >= 9){
				elixir = elixir - 9;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero46");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card1.sprite.texture.name == "47") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero47");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card1.sprite.texture.name == "48") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero48");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card1.sprite.texture.name == "49") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero49");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card1.sprite.texture.name == "50") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card1.sprite = cards2 [card_int1];
				
				card_int1 = 0;
				MainController.instance.SpawnBuilding ("p1_hero50");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------

	
		//DisableScrollUI();
	}
	public void carta2 () 
	{
		todaarea.gameObject.SetActive (true);
	
		if (card2.sprite.texture.name == "1") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero1");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card2.sprite.texture.name == "2") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero2");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "3") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero3");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "4") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero4");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "5") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero5");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "6") {
			if(elixir >= 7){
				elixir = elixir - 7;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero6");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "7") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero7");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "8") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero8");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "9") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero9");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "10") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero10");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "11") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero11");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "12") {
			if(elixir >= 8){
				elixir = elixir - 8;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero12");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "13") {
			if(elixir >= 7){
				elixir = elixir - 7;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero13");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "14") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero14");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card2.sprite.texture.name == "15") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero15");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "16") {
			if(elixir >= 9){
				elixir = elixir - 9;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero16");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "17") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero17");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "18") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero18");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "19") {
			if(elixir >= 2){
				elixir = elixir - 2;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero19");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "20") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero20");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "21") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero21");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "22") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero22");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card2.sprite.texture.name == "23") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero23");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "24") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero24");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "25") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero25");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "26") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero26");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card2.sprite.texture.name == "30") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero30");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		//-------------------------------------------------
		if (card2.sprite.texture.name == "40") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero40");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card2.sprite.texture.name == "41") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero41");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card2.sprite.texture.name == "42") {
			if(elixir >= 8){
				elixir = elixir - 8;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero42");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card2.sprite.texture.name == "44") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero44");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card2.sprite.texture.name == "45") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero45");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card2.sprite.texture.name == "46") {
			if(elixir >= 9){
				elixir = elixir - 9;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero46");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card2.sprite.texture.name == "47") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero47");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card2.sprite.texture.name == "48") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero48");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card2.sprite.texture.name == "49") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero49");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card2.sprite.texture.name == "50") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card2.sprite = cards2 [card_int2];
				
				card_int2 = 0;
				MainController.instance.SpawnBuilding ("p1_hero50");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		
		//DisableScrollUI();
	}
	public void carta3 () 
	{

		todaarea.gameObject.SetActive (true);
		if (card3.sprite.texture.name == "1") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero1");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card3.sprite.texture.name == "2") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero2");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "3") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero3");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "4") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero4");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "5") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero5");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "6") {
			if(elixir >= 7){
				elixir = elixir - 7;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero6");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "7") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero7");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "8") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero8");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "9") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero9");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "10") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero10");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "11") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero11");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "12") {
			if(elixir >= 8){
				elixir = elixir - 8;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero12");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "13") {
			if(elixir >= 7){
				elixir = elixir - 7;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero13");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "14") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero14");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card3.sprite.texture.name == "15") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero15");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "16") {
			if(elixir >= 9){
				elixir = elixir - 9;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero16");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "17") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero17");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "18") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero18");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "19") {
			if(elixir >= 2){
				elixir = elixir - 2;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero19");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "20") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero20");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "21") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero21");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "22") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero22");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card3.sprite.texture.name == "23") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero23");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "24") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero24");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "25") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero25");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card3.sprite.texture.name == "26") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero26");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card3.sprite.texture.name == "30") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero30");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}


		//-------------------------------------------------
		if (card3.sprite.texture.name == "40") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero40");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card3.sprite.texture.name == "41") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero41");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card3.sprite.texture.name == "42") {
			if(elixir >= 8){
				elixir = elixir - 8;
				card1.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero42");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card3.sprite.texture.name == "44") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero44");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card3.sprite.texture.name == "45") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero45");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card3.sprite.texture.name == "46") {
			if(elixir >= 9){
				elixir = elixir - 9;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero46");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card3.sprite.texture.name == "47") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero47");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card3.sprite.texture.name == "48") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero48");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card3.sprite.texture.name == "49") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero49");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card3.sprite.texture.name == "50") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card3.sprite = cards2 [card_int3];
				
				card_int3 = 0;
				MainController.instance.SpawnBuilding ("p1_hero50");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		
		
		//DisableScrollUI();
	}
	public void carta4 () 
	{
		todaarea.gameObject.SetActive (true);

		if (card4.sprite.texture.name == "1") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero1");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card4.sprite.texture.name == "2") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero2");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "3") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero3");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "4") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero4");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "5") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero5");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "6") {
			if(elixir >= 7){
				elixir = elixir - 7;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero6");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "7") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero7");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "8") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero8");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "9") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero9");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "10") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero10");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "11") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero11");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "12") {
			if(elixir >= 8){
				elixir = elixir - 8;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero12");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "13") {
			if(elixir >= 7){
				elixir = elixir - 7;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero13");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "14") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero14");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card4.sprite.texture.name == "15") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero15");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "16") {
			if(elixir >= 9){
				elixir = elixir - 9;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero16");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "17") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero17");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "18") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero18");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "19") {
			if(elixir >= 2){
				elixir = elixir - 2;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero19");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "20") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero20");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "21") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero21");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "22") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero22");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		if (card4.sprite.texture.name == "23") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero23");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "24") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero24");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "25") {
			if(elixir >= 4){
				elixir = elixir - 4;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero25");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "26") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero26");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		
		if (card4.sprite.texture.name == "30") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero30");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}

		//-------------------------------------------------
		if (card4.sprite.texture.name == "40") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero40");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card4.sprite.texture.name == "41") {
			if(elixir >= 6){
				elixir = elixir - 6;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero41");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card4.sprite.texture.name == "42") {
			if(elixir >= 8){
				elixir = elixir - 8;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero42");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card4.sprite.texture.name == "44") {
			if(elixir >= 3){
				elixir = elixir - 3;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero44");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card4.sprite.texture.name == "45") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero45");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card4.sprite.texture.name == "46") {
			if(elixir >= 9){
				elixir = elixir - 9;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero46");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card4.sprite.texture.name == "47") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero47");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card4.sprite.texture.name == "48") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero48");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card4.sprite.texture.name == "49") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero49");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//-------------------------------------------------
		if (card4.sprite.texture.name == "50") {
			if(elixir >= 5){
				elixir = elixir - 5;
				card4.sprite = cards2 [card_int4];
				
				card_int4 = 0;
				MainController.instance.SpawnBuilding ("p1_hero50");
			}else{
				
				noelixir.gameObject.SetActive(true);
				StartCoroutine(desliga());
				
				
			}
		}
		//-------------------------------------------------
		//DisableScrollUI();
	}
	IEnumerator desliga () {
		
		yield return new WaitForSeconds(1.9f);
		noelixir.gameObject.SetActive(false);


		yield break;
		
	}
	public void nadaarea(){
	
		todaarea.gameObject.SetActive (false);
	
	}


	public void select2 () 
	{
		position_card1 = 2;
		position_card2 = 1;
		position_card3 = 2;
		position_card4 = 2;
		if (position_card2 == 1) {
			b2.GetComponent<Animation>().Play ("c2");
		}
		if (position_card1 == 2) {
			
			b1.GetComponent<Animation>().Play ("c1a");
			
		}
		if (position_card3 == 2) {
			
			b3.GetComponent<Animation>().Play ("c3a");
			
		}
		if (position_card4 == 2) {
			
			b4.GetComponent<Animation>().Play ("c4a");
			
		}

		//MainController.instance.SpawnBuilding(hero2);
		//DisableScrollUI();
	}
	
	public void select3 () 
	{
		position_card1 = 2;
		position_card2 = 2;
		position_card3 = 1;
		position_card4 = 2;
		if (position_card3 == 1) {
			b3.GetComponent<Animation>().Play ("c3");
		}
		if (position_card2 == 2) {
			
			b2.GetComponent<Animation>().Play ("c2a");
			
		}
		if (position_card1 == 2) {
			
			b1.GetComponent<Animation>().Play ("c1a");
			
		}
		if (position_card4 == 2) {
			
			b4.GetComponent<Animation>().Play ("c4a");
			
		}
		//MainController.instance.SpawnBuilding(hero3);
		//DisableScrollUI();
	}
	
	public void select4 () 
	{
		position_card1 = 2;
		position_card2 = 2;
		position_card3 = 2;
		position_card4 = 1;
		if (position_card4 == 1) {
			b4.GetComponent<Animation>().Play ("c4");
		}
		if (position_card2 == 2) {
			
			b2.GetComponent<Animation>().Play ("c2a");
			
		}
		if (position_card3 == 2) {
			
			b3.GetComponent<Animation>().Play ("c3a");
			
		}
		if (position_card1 == 2) {
			
			b1.GetComponent<Animation>().Play ("c1a");
			
		}

	//	MainController.instance.SpawnBuilding(hero4);
		//DisableScrollUI();
	}
	

	
	
	public void menu1(){
	
		Application.LoadLevel ("load_menu");
	
	
	}
	public void EnableScrollUI()
	{
		MainController.instance.DestroyCurrentBuilding();
		// ScrollUI.SetActive(true);
		//CancelBtn.SetActive(false);
	}
	
	public void DisableScrollUI()
	{
		if(PlayerPrefs.GetInt("FirstTime") == 1)
		{
			
			StartCoroutine("TurnOffTutorial");
		}
		// ScrollUI.SetActive(false);
		//CancelBtn.SetActive(true);
	}
	
	private IEnumerator TurnOffTutorial ()
	{
		yield return new WaitForSeconds(3);
		
		// TutorialBlock.SetActive(false);
	}
}

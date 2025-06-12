using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class gerenciar_mobs : MonoBehaviour {
	public static UIController instance;
	public static int elixir2;
	public int soket0;
	public int soket1;
	public int soket2;
	public int soket3;
	public int soket4;
	public int soket5;
	public int soket6;
	public int soket7;
	public int soket8;
	public GameObject[] enemy;
	public int select;
	public float tempo;
	public int mob;
	private GameObject building;
	public GameObject[] spawn1;
	public GameObject[] spawn2;
	public GameObject[] spawn3;
	public GameObject[] spawn4;
	public int local1;
	public GameObject torre1;
	public GameObject torre2;
	public int pode;
	public int estrategia;
	public int vitoric;
	public Text vitor;
	public int select1;
	// Use this for initialization
	void Start () {
		select1 = PlayerPrefs.GetInt ("selectarena");
		vitoric = PlayerPrefs.GetInt ("victory");
		estrategia = Random.Range (1, 40);
		tempo = Random.Range (5, 14);
		select = Random.Range (1, 9);
		local1 = Random.Range (1, 7);
		/*
		soket1 = PlayerPrefs.GetInt ("sok1a");
		soket2 = PlayerPrefs.GetInt ("sok2a");
		soket3 = PlayerPrefs.GetInt ("sok3a");
		soket4 = PlayerPrefs.GetInt ("sok4a");
		soket5 = PlayerPrefs.GetInt ("sok5a");
		soket6 = PlayerPrefs.GetInt ("sok6a");
		soket7 = PlayerPrefs.GetInt ("sok7a");
		soket8 = PlayerPrefs.GetInt ("sok8a");
		*/


		StartCoroutine (parte1 ());
		StartCoroutine (checar ());


	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.2f);

		if (select1 == 1) {
		
			if (estrategia == 1) {
				soket1 = 19;
				soket2 = 3;
				soket3 = 0;
				soket4 = 8;
				soket5 = 11;
				soket6 = 1;
				soket7 = 17;
				soket8 = 21;
			}
			if (estrategia == 2) {
				soket1 = 19;
				soket2 = 3;
				soket3 = 14;
				soket4 = 10;
				soket5 = 11;
				soket6 = 1;
				soket7 = 2;
				soket8 = 9;
			}
			if (estrategia == 3) {
				soket1 = 11;
				soket2 = 3;
				soket3 = 15;
				soket4 = 0;
				soket5 = 19;
				soket6 = 2;
				soket7 = 8;
				soket8 = 9;
			}
			if (estrategia == 4) {
				soket1 = 11;
				soket2 = 3;
				soket3 = 15;
				soket4 = 6;
				soket5 = 17;
				soket6 = 1;
				soket7 = 8;
				soket8 = 14;
			}
			if (estrategia == 5) {
				soket1 = 11;
				soket2 = 14;
				soket3 = 15;
				soket4 = 17;
				soket5 = 7;
				soket6 = 1;
				soket7 = 8;
				soket8 = 3;
			}
			if (estrategia == 6) {
				soket1 = 10;
				soket2 = 5;
				soket3 = 15;
				soket4 = 17;
				soket5 = 2;
				soket6 = 1;
				soket7 = 14;
				soket8 = 3;
			}
			if (estrategia == 7) {
				soket1 = 0;
				soket2 = 5;
				soket3 = 18;
				soket4 = 13;
				soket5 = 6;
				soket6 = 17;
				soket7 = 14;
				soket8 = 3;
			}
			if (estrategia == 8) {
				soket1 = 14;
				soket2 = 5;
				soket3 = 10;
				soket4 = 15;
				soket5 = 7;
				soket6 = 19;
				soket7 = 18;
				soket8 = 11;
			}
			if (estrategia == 9) {
				soket1 = 14;
				soket2 = 5;
				soket3 = 1;
				soket4 = 17;
				soket5 = 7;
				soket6 = 19;
				soket7 = 13;
				soket8 = 11;
			}
			if (estrategia == 10) {
				soket1 = 2;
				soket2 = 5;
				soket3 = 0;
				soket4 = 17;
				soket5 = 7;
				soket6 = 3;
				soket7 = 8;
				soket8 = 11;
			}
			if (estrategia == 11) {
				soket1 = 11;
				soket2 = 5;
				soket3 = 15;
				soket4 = 21;
				soket5 = 7;
				soket6 = 17;
				soket7 = 8;
				soket8 = 3;
			}
	
			if (estrategia == 12) {
				soket1 = 10;
				soket2 = 1;
				soket3 = 14;
				soket4 = 9;
				soket5 = 18;
				soket6 = 0;
				soket7 = 13;
				soket8 = 2;
			}
			if (estrategia == 13) {
				soket1 = 10;
				soket2 = 1;
				soket3 = 9;
				soket4 = 5;
				soket5 = 15;
				soket6 = 11;
				soket7 = 8;
				soket8 = 2;
			}
			if (estrategia == 14) {
				soket1 = 1;
				soket2 = 0;
				soket3 = 3;
				soket4 = 5;
				soket5 = 19;
				soket6 = 11;
				soket7 = 13;
				soket8 = 14;
			}
		
			if (estrategia == 15) {
				soket1 = 1;
				soket2 = 3;
				soket3 = 4;
				soket4 = 15;
				soket5 = 20;
				soket6 = 18;
				soket7 = 17;
				soket8 = 2;
			}
			if (estrategia == 16) {
				soket1 = 1;
				soket2 = 0;
				soket3 = 4;
				soket4 = 15;
				soket5 = 11;
				soket6 = 18;
				soket7 = 17;
				soket8 = 2;
			}
			if (estrategia == 17) {
				soket1 = 19;
				soket2 = 3;
				soket3 = 0;
				soket4 = 8;
				soket5 = 21;
				soket6 = 1;
				soket7 = 17;
				soket8 = 9;
			}
			if (estrategia == 18) {
				soket1 = 19;
				soket2 = 3;
				soket3 = 14;
				soket4 = 10;
				soket5 = 1;
				soket6 = 21;
				soket7 = 2;
				soket8 = 9;
			}
			if (estrategia == 19) {
				soket1 = 11;
				soket2 = 0;
				soket3 = 15;
				soket4 = 18;
				soket5 = 19;
				soket6 = 2;
				soket7 = 8;
				soket8 = 9;
			}
			if (estrategia == 20) {
				soket1 = 11;
				soket2 = 0;
				soket3 = 15;
				soket4 = 6;
				soket5 = 7;
				soket6 = 1;
				soket7 = 8;
				soket8 = 9;
			}

			if (estrategia == 21) {
				soket1 = 19;
				soket2 = 3;
				soket3 = 14;
				soket4 = 8;
				soket5 = 16;
				soket6 = 1;
				soket7 = 17;
				soket8 = 9;
			}
			if (estrategia == 22) {
				soket1 = 19;
				soket2 = 3;
				soket3 = 16;
				soket4 = 44;
				soket5 = 11;
				soket6 = 7;
				soket7 = 2;
				soket8 = 9;
			}
			if (estrategia == 23) {
				soket1 = 11;
				soket2 = 3;
				soket3 = 15;
				soket4 = 18;
				soket5 = 47;
				soket6 = 2;
				soket7 = 8;
				soket8 = 9;
			}
			if (estrategia == 24) {
				soket1 = 19;
				soket2 = 3;
				soket3 = 15;
				soket4 = 18;
				soket5 = 0;
				soket6 = 1;
				soket7 = 8;
				soket8 = 9;
			}
			if (estrategia == 25) {
				soket1 = 11;
				soket2 = 14;
				soket3 = 15;
				soket4 = 17;
				soket5 = 8;
				soket6 = 1;
				soket7 = 41;
				soket8 = 3;
			}
			if (estrategia == 26) {
				soket1 = 45;
				soket2 = 8;
				soket3 = 15;
				soket4 = 17;
				soket5 = 2;
				soket6 = 49;
				soket7 = 14;
				soket8 = 3;
			}
			if (estrategia == 27) {
				soket1 = 10;
				soket2 = 5;
				soket3 = 18;
				soket4 = 47;
				soket5 = 6;
				soket6 = 17;
				soket7 = 41;
				soket8 = 3;
			}
			if (estrategia == 28) {
				soket1 = 14;
				soket2 = 5;
				soket3 = 44;
				soket4 = 15;
				soket5 = 7;
				soket6 = 20;
				soket7 = 18;
				soket8 = 8;
			}
			if (estrategia == 29) {
				soket1 = 6;
				soket2 = 5;
				soket3 = 16;
				soket4 = 41;
				soket5 = 7;
				soket6 = 19;
				soket7 = 13;
				soket8 = 11;
			}
			if (estrategia == 30) {
				soket1 = 44;
				soket2 = 5;
				soket3 = 0;
				soket4 = 17;
				soket5 = 7;
				soket6 = 42;
				soket7 = 8;
				soket8 = 11;
			}
			if (estrategia == 31) {
				soket1 = 11;
				soket2 = 5;
				soket3 = 15;
				soket4 = 21;
				soket5 = 49;
				soket6 = 16;
				soket7 = 8;
				soket8 = 3;
			}
			
			if (estrategia == 32) {
				soket1 = 5;
				soket2 = 48;
				soket3 = 16;
				soket4 = 9;
				soket5 = 18;
				soket6 = 49;
				soket7 = 13;
				soket8 = 2;
			}
			if (estrategia == 33) {
				soket1 = 10;
				soket2 = 44;
				soket3 = 4;
				soket4 = 5;
				soket5 = 48;
				soket6 = 11;
				soket7 = 13;
				soket8 = 2;
			}
			
			if (estrategia == 34) {
				soket1 = 1;
				soket2 = 18;
				soket3 = 15;
				soket4 = 8;
				soket5 = 11;
				soket6 = 7;
				soket7 = 47;
				soket8 = 3;
			}
			if (estrategia == 35) {
				soket1 = 0;
				soket2 = 47;
				soket3 = 4;
				soket4 = 15;
				soket5 = 20;
				soket6 = 18;
				soket7 = 17;
				soket8 = 2;
			}
			if (estrategia == 36) {
				soket1 = 11;
				soket2 = 0;
				soket3 = 4;
				soket4 = 15;
				soket5 = 5;
				soket6 = 47;
				soket7 = 17;
				soket8 = 2;
			}
			if (estrategia == 37) {
				soket1 = 49;
				soket2 = 3;
				soket3 = 45;
				soket4 = 8;
				soket5 = 21;
				soket6 = 1;
				soket7 = 17;
				soket8 = 9;
			}
			if (estrategia == 38) {
				soket1 = 44;
				soket2 = 3;
				soket3 = 14;
				soket4 = 41;
				soket5 = 20;
				soket6 = 21;
				soket7 = 2;
				soket8 = 9;
			}
			if (estrategia == 39) {
				soket1 = 45;
				soket2 = 16;
				soket3 = 15;
				soket4 = 18;
				soket5 = 19;
				soket6 = 5;
				soket7 = 8;
				soket8 = 9;
			}
			if (estrategia == 40) {
				soket1 = 44;
				soket2 = 0;
				soket3 = 15;
				soket4 = 5;
				soket5 = 45;
				soket6 = 1;
				soket7 = 8;
				soket8 = 9;
			}

		
		}

		if (select1 != 1) {
		
			if (vitoric <= 300) {
			
				if (estrategia == 1) {
					soket1 = 19;
					soket2 = 3;
					soket3 = 14;
					soket4 = 8;
					soket5 = 11;
					soket6 = 1;
					soket7 = 17;
					soket8 = 21;
				}
				if (estrategia == 2) {
					soket1 = 19;
					soket2 = 3;
					soket3 = 14;
					soket4 = 0;
					soket5 = 11;
					soket6 = 1;
					soket7 = 2;
					soket8 = 9;
				}
				if (estrategia == 3) {
					soket1 = 11;
					soket2 = 3;
					soket3 = 15;
					soket4 = 1;
					soket5 = 19;
					soket6 = 2;
					soket7 = 8;
					soket8 = 9;
				}
				if (estrategia == 4) {
					soket1 = 11;
					soket2 = 3;
					soket3 = 15;
					soket4 = 6;
					soket5 = 17;
					soket6 = 0;
					soket7 = 8;
					soket8 = 14;
				}
				if (estrategia == 5) {
					soket1 = 11;
					soket2 = 14;
					soket3 = 15;
					soket4 = 17;
					soket5 = 7;
					soket6 = 1;
					soket7 = 8;
					soket8 = 3;
				}
				if (estrategia == 6) {
					soket1 = 0;
					soket2 = 5;
					soket3 = 15;
					soket4 = 17;
					soket5 = 2;
					soket6 = 1;
					soket7 = 14;
					soket8 = 3;
				}
				if (estrategia == 7) {
					soket1 = 0;
					soket2 = 5;
					soket3 = 18;
					soket4 = 13;
					soket5 = 6;
					soket6 = 17;
					soket7 = 14;
					soket8 = 3;
				}
				if (estrategia == 8) {
					soket1 = 14;
					soket2 = 5;
					soket3 = 10;
					soket4 = 15;
					soket5 = 7;
					soket6 = 19;
					soket7 = 18;
					soket8 = 11;
				}
				if (estrategia == 9) {
					soket1 = 14;
					soket2 = 5;
					soket3 = 1;
					soket4 = 17;
					soket5 = 7;
					soket6 = 19;
					soket7 = 13;
					soket8 = 11;
				}
				if (estrategia == 10) {
					soket1 = 2;
					soket2 = 5;
					soket3 = 1;
					soket4 = 17;
					soket5 = 7;
					soket6 = 3;
					soket7 = 8;
					soket8 = 11;
				}
				if (estrategia == 11) {
					soket1 = 11;
					soket2 = 5;
					soket3 = 15;
					soket4 = 21;
					soket5 = 7;
					soket6 = 17;
					soket7 = 8;
					soket8 = 3;
				}

				if (estrategia == 12) {
					soket1 = 10;
					soket2 = 1;
					soket3 = 14;
					soket4 = 9;
					soket5 = 18;
					soket6 = 0;
					soket7 = 13;
					soket8 = 2;
				}
				if (estrategia == 13) {
					soket1 = 0;
					soket2 = 1;
					soket3 = 9;
					soket4 = 5;
					soket5 = 15;
					soket6 = 11;
					soket7 = 8;
					soket8 = 2;
				}

				if (estrategia == 14) {
					soket1 = 1;
					soket2 = 14;
					soket3 = 15;
					soket4 = 8;
					soket5 = 11;
					soket6 = 7;
					soket7 = 19;
					soket8 = 3;
				}
				if (estrategia == 15) {
					soket1 = 1;
					soket2 = 3;
					soket3 = 4;
					soket4 = 15;
					soket5 = 20;
					soket6 = 18;
					soket7 = 17;
					soket8 = 0;
				}
				if (estrategia == 16) {
					soket1 = 1;
					soket2 = 0;
					soket3 = 4;
					soket4 = 15;
					soket5 = 11;
					soket6 = 18;
					soket7 = 17;
					soket8 = 2;
				}
				if (estrategia == 17) {
					soket1 = 19;
					soket2 = 3;
					soket3 = 20;
					soket4 = 8;
					soket5 = 21;
					soket6 = 1;
					soket7 = 17;
					soket8 = 9;
				}
				if (estrategia == 18) {
					soket1 = 0;
					soket2 = 3;
					soket3 = 14;
					soket4 = 10;
					soket5 = 1;
					soket6 = 21;
					soket7 = 2;
					soket8 = 9;
				}
				if (estrategia == 19) {
					soket1 = 11;
					soket2 = 20;
					soket3 = 15;
					soket4 = 18;
					soket5 = 19;
					soket6 = 2;
					soket7 = 8;
					soket8 = 9;
				}
				if (estrategia == 20) {
					soket1 = 11;
					soket2 = 0;
					soket3 = 15;
					soket4 = 6;
					soket5 = 7;
					soket6 = 1;
					soket7 = 8;
					soket8 = 9;
				}

				if (estrategia == 21) {
					soket1 = 19;
					soket2 = 3;
					soket3 = 14;
					soket4 = 8;
					soket5 = 16;
					soket6 = 1;
					soket7 = 17;
					soket8 = 9;
				}
				if (estrategia == 22) {
					soket1 = 19;
					soket2 = 3;
					soket3 = 16;
					soket4 = 44;
					soket5 = 45;
					soket6 = 40;
					soket7 = 2;
					soket8 = 9;
				}
				if (estrategia == 23) {
					soket1 = 11;
					soket2 = 3;
					soket3 = 15;
					soket4 = 18;
					soket5 = 47;
					soket6 = 2;
					soket7 = 48;
					soket8 = 9;
				}
				if (estrategia == 24) {
					soket1 = 19;
					soket2 = 3;
					soket3 = 15;
					soket4 = 18;
					soket5 = 0;
					soket6 = 1;
					soket7 = 8;
					soket8 = 9;
				}
				if (estrategia == 25) {
					soket1 = 11;
					soket2 = 14;
					soket3 = 15;
					soket4 = 17;
					soket5 = 50;
					soket6 = 1;
					soket7 = 41;
					soket8 = 3;
				}
				if (estrategia == 26) {
					soket1 = 45;
					soket2 = 48;
					soket3 = 15;
					soket4 = 17;
					soket5 = 2;
					soket6 = 49;
					soket7 = 14;
					soket8 = 3;
				}
				if (estrategia == 27) {
					soket1 = 10;
					soket2 = 5;
					soket3 = 18;
					soket4 = 47;
					soket5 = 6;
					soket6 = 17;
					soket7 = 41;
					soket8 = 3;
				}
				if (estrategia == 28) {
					soket1 = 14;
					soket2 = 5;
					soket3 = 44;
					soket4 = 15;
					soket5 = 7;
					soket6 = 20;
					soket7 = 18;
					soket8 = 45;
				}
				if (estrategia == 29) {
					soket1 = 40;
					soket2 = 5;
					soket3 = 16;
					soket4 = 41;
					soket5 = 7;
					soket6 = 19;
					soket7 = 13;
					soket8 = 11;
				}
				if (estrategia == 30) {
					soket1 = 44;
					soket2 = 5;
					soket3 = 0;
					soket4 = 17;
					soket5 = 7;
					soket6 = 45;
					soket7 = 8;
					soket8 = 11;
				}
				if (estrategia == 31) {
					soket1 = 48;
					soket2 = 5;
					soket3 = 15;
					soket4 = 21;
					soket5 = 44;
					soket6 = 16;
					soket7 = 8;
					soket8 = 3;
				}
				
				if (estrategia == 32) {
					soket1 = 5;
					soket2 = 48;
					soket3 = 16;
					soket4 = 9;
					soket5 = 18;
					soket6 = 49;
					soket7 = 13;
					soket8 = 2;
				}
				if (estrategia == 33) {
					soket1 = 10;
					soket2 = 44;
					soket3 = 4;
					soket4 = 5;
					soket5 = 48;
					soket6 = 11;
					soket7 = 13;
					soket8 = 2;
				}
				
				if (estrategia == 34) {
					soket1 = 1;
					soket2 = 41;
					soket3 = 15;
					soket4 = 8;
					soket5 = 11;
					soket6 = 7;
					soket7 = 47;
					soket8 = 3;
				}
				if (estrategia == 35) {
					soket1 = 40;
					soket2 = 47;
					soket3 = 4;
					soket4 = 15;
					soket5 = 20;
					soket6 = 18;
					soket7 = 17;
					soket8 = 2;
				}
				if (estrategia == 36) {
					soket1 = 40;
					soket2 = 0;
					soket3 = 4;
					soket4 = 15;
					soket5 = 5;
					soket6 = 44;
					soket7 = 17;
					soket8 = 2;
				}
				if (estrategia == 37) {
					soket1 = 49;
					soket2 = 3;
					soket3 = 45;
					soket4 = 8;
					soket5 = 21;
					soket6 = 1;
					soket7 = 17;
					soket8 = 9;
				}
				if (estrategia == 38) {
					soket1 = 44;
					soket2 = 3;
					soket3 = 14;
					soket4 = 41;
					soket5 = 20;
					soket6 = 21;
					soket7 = 2;
					soket8 = 9;
				}
				if (estrategia == 39) {
					soket1 = 45;
					soket2 = 16;
					soket3 = 15;
					soket4 = 18;
					soket5 = 19;
					soket6 = 44;
					soket7 = 8;
					soket8 = 9;
				}
				if (estrategia == 40) {
					soket1 = 17;
					soket2 = 0;
					soket3 = 15;
					soket4 = 5;
					soket5 = 46;
					soket6 = 1;
					soket7 = 8;
					soket8 = 9;
				}
			}
			if (vitoric <= 700) {
				if (vitoric > 300) {
				
					if (estrategia == 1) {
						soket1 = 19;
						soket2 = 0;
						soket3 = 14;
						soket4 = 8;
						soket5 = 11;
						soket6 = 1;
						soket7 = 17;
						soket8 = 9;
					}
					if (estrategia == 2) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 14;
						soket4 = 10;
						soket5 = 11;
						soket6 = 1;
						soket7 = 2;
						soket8 = 9;
					}
					if (estrategia == 3) {
						soket1 = 11;
						soket2 = 0;
						soket3 = 15;
						soket4 = 18;
						soket5 = 19;
						soket6 = 2;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 4) {
						soket1 = 11;
						soket2 = 3;
						soket3 = 15;
						soket4 = 6;
						soket5 = 7;
						soket6 = 1;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 5) {
						soket1 = 11;
						soket2 = 14;
						soket3 = 15;
						soket4 = 17;
						soket5 = 7;
						soket6 = 1;
						soket7 = 8;
						soket8 = 3;
					}
					if (estrategia == 6) {
						soket1 = 10;
						soket2 = 5;
						soket3 = 15;
						soket4 = 17;
						soket5 = 2;
						soket6 = 1;
						soket7 = 14;
						soket8 = 3;
					}
					if (estrategia == 7) {
						soket1 = 10;
						soket2 = 5;
						soket3 = 18;
						soket4 = 13;
						soket5 = 6;
						soket6 = 17;
						soket7 = 14;
						soket8 = 3;
					}
					if (estrategia == 8) {
						soket1 = 14;
						soket2 = 5;
						soket3 = 18;
						soket4 = 15;
						soket5 = 7;
						soket6 = 20;
						soket7 = 18;
						soket8 = 11;
					}
					if (estrategia == 9) {
						soket1 = 14;
						soket2 = 5;
						soket3 = 0;
						soket4 = 17;
						soket5 = 7;
						soket6 = 19;
						soket7 = 13;
						soket8 = 11;
					}
					if (estrategia == 10) {
						soket1 = 2;
						soket2 = 5;
						soket3 = 1;
						soket4 = 17;
						soket5 = 7;
						soket6 = 11;
						soket7 = 8;
						soket8 = 11;
					}
			
					if (estrategia == 11) {
						soket1 = 0;
						soket2 = 12;
						soket3 = 8;
						soket4 = 19;
						soket5 = 1;
						soket6 = 11;
						soket7 = 13;
						soket8 = 3;
					}
					if (estrategia == 12) {
						soket1 = 10;
						soket2 = 12;
						soket3 = 11;
						soket4 = 9;
						soket5 = 18;
						soket6 = 0;
						soket7 = 13;
						soket8 = 2;
					}
					if (estrategia == 13) {
						soket1 = 10;
						soket2 = 12;
						soket3 = 4;
						soket4 = 5;
						soket5 = 15;
						soket6 = 11;
						soket7 = 13;
						soket8 = 2;
					}
					if (estrategia == 14) {
						soket1 = 1;
						soket2 = 2;
						soket3 = 3;
						soket4 = 5;
						soket5 = 19;
						soket6 = 11;
						soket7 = 13;
						soket8 = 14;
					}
				
					if (estrategia == 15) {
						soket1 = 0;
						soket2 = 3;
						soket3 = 4;
						soket4 = 15;
						soket5 = 20;
						soket6 = 18;
						soket7 = 17;
						soket8 = 2;
					}
					if (estrategia == 16) {
						soket1 = 0;
						soket2 = 0;
						soket3 = 4;
						soket4 = 15;
						soket5 = 11;
						soket6 = 18;
						soket7 = 17;
						soket8 = 2;
					}
					if (estrategia == 17) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 20;
						soket4 = 8;
						soket5 = 21;
						soket6 = 1;
						soket7 = 17;
						soket8 = 9;
					}
					if (estrategia == 18) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 14;
						soket4 = 10;
						soket5 = 20;
						soket6 = 21;
						soket7 = 2;
						soket8 = 9;
					}
					if (estrategia == 19) {
						soket1 = 11;
						soket2 = 20;
						soket3 = 15;
						soket4 = 18;
						soket5 = 19;
						soket6 = 2;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 20) {
						soket1 = 11;
						soket2 = 0;
						soket3 = 15;
						soket4 = 6;
						soket5 = 7;
						soket6 = 1;
						soket7 = 8;
						soket8 = 9;
					}

					if (estrategia == 21) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 14;
						soket4 = 8;
						soket5 = 16;
						soket6 = 1;
						soket7 = 17;
						soket8 = 9;
					}
					if (estrategia == 22) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 16;
						soket4 = 44;
						soket5 = 45;
						soket6 = 40;
						soket7 = 2;
						soket8 = 9;
					}
					if (estrategia == 23) {
						soket1 = 11;
						soket2 = 3;
						soket3 = 15;
						soket4 = 18;
						soket5 = 47;
						soket6 = 2;
						soket7 = 48;
						soket8 = 9;
					}
					if (estrategia == 24) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 15;
						soket4 = 18;
						soket5 = 0;
						soket6 = 1;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 25) {
						soket1 = 11;
						soket2 = 14;
						soket3 = 15;
						soket4 = 17;
						soket5 = 50;
						soket6 = 1;
						soket7 = 41;
						soket8 = 3;
					}
					if (estrategia == 26) {
						soket1 = 45;
						soket2 = 48;
						soket3 = 15;
						soket4 = 17;
						soket5 = 2;
						soket6 = 49;
						soket7 = 14;
						soket8 = 3;
					}
					if (estrategia == 27) {
						soket1 = 10;
						soket2 = 5;
						soket3 = 18;
						soket4 = 47;
						soket5 = 6;
						soket6 = 17;
						soket7 = 41;
						soket8 = 3;
					}
					if (estrategia == 28) {
						soket1 = 14;
						soket2 = 5;
						soket3 = 44;
						soket4 = 15;
						soket5 = 7;
						soket6 = 20;
						soket7 = 18;
						soket8 = 45;
					}
					if (estrategia == 29) {
						soket1 = 40;
						soket2 = 5;
						soket3 = 16;
						soket4 = 41;
						soket5 = 7;
						soket6 = 19;
						soket7 = 13;
						soket8 = 11;
					}
					if (estrategia == 30) {
						soket1 = 44;
						soket2 = 5;
						soket3 = 0;
						soket4 = 17;
						soket5 = 7;
						soket6 = 42;
						soket7 = 8;
						soket8 = 11;
					}
					if (estrategia == 31) {
						soket1 = 48;
						soket2 = 5;
						soket3 = 15;
						soket4 = 21;
						soket5 = 44;
						soket6 = 16;
						soket7 = 8;
						soket8 = 3;
					}
					
					if (estrategia == 32) {
						soket1 = 5;
						soket2 = 48;
						soket3 = 16;
						soket4 = 9;
						soket5 = 18;
						soket6 = 49;
						soket7 = 13;
						soket8 = 2;
					}
					if (estrategia == 33) {
						soket1 = 10;
						soket2 = 44;
						soket3 = 4;
						soket4 = 5;
						soket5 = 48;
						soket6 = 11;
						soket7 = 13;
						soket8 = 2;
					}
					
					if (estrategia == 34) {
						soket1 = 1;
						soket2 = 41;
						soket3 = 15;
						soket4 = 8;
						soket5 = 11;
						soket6 = 7;
						soket7 = 47;
						soket8 = 3;
					}
					if (estrategia == 35) {
						soket1 = 40;
						soket2 = 47;
						soket3 = 4;
						soket4 = 15;
						soket5 = 20;
						soket6 = 18;
						soket7 = 17;
						soket8 = 2;
					}
					if (estrategia == 36) {
						soket1 = 40;
						soket2 = 0;
						soket3 = 4;
						soket4 = 15;
						soket5 = 5;
						soket6 = 41;
						soket7 = 17;
						soket8 = 2;
					}
					if (estrategia == 37) {
						soket1 = 49;
						soket2 = 3;
						soket3 = 45;
						soket4 = 8;
						soket5 = 21;
						soket6 = 1;
						soket7 = 17;
						soket8 = 9;
					}
					if (estrategia == 38) {
						soket1 = 44;
						soket2 = 3;
						soket3 = 14;
						soket4 = 41;
						soket5 = 20;
						soket6 = 21;
						soket7 = 2;
						soket8 = 9;
					}
					if (estrategia == 39) {
						soket1 = 45;
						soket2 = 16;
						soket3 = 15;
						soket4 = 18;
						soket5 = 19;
						soket6 = 42;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 40) {
						soket1 = 44;
						soket2 = 48;
						soket3 = 15;
						soket4 = 5;
						soket5 = 50;
						soket6 = 1;
						soket7 = 8;
						soket8 = 9;
					}
				}
			}
			if (vitoric <= 1500) {
				if (vitoric > 700) {
				
					if (estrategia == 1) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 14;
						soket4 = 8;
						soket5 = 16;
						soket6 = 1;
						soket7 = 17;
						soket8 = 9;
					}
					if (estrategia == 2) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 14;
						soket4 = 10;
						soket5 = 11;
						soket6 = 1;
						soket7 = 2;
						soket8 = 9;
					}
					if (estrategia == 3) {
						soket1 = 11;
						soket2 = 3;
						soket3 = 15;
						soket4 = 18;
						soket5 = 19;
						soket6 = 2;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 4) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 15;
						soket4 = 18;
						soket5 = 0;
						soket6 = 1;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 5) {
						soket1 = 11;
						soket2 = 14;
						soket3 = 15;
						soket4 = 17;
						soket5 = 7;
						soket6 = 1;
						soket7 = 8;
						soket8 = 3;
					}
					if (estrategia == 6) {
						soket1 = 10;
						soket2 = 5;
						soket3 = 15;
						soket4 = 17;
						soket5 = 2;
						soket6 = 1;
						soket7 = 14;
						soket8 = 3;
					}
					if (estrategia == 7) {
						soket1 = 10;
						soket2 = 5;
						soket3 = 18;
						soket4 = 13;
						soket5 = 6;
						soket6 = 17;
						soket7 = 14;
						soket8 = 3;
					}
					if (estrategia == 8) {
						soket1 = 14;
						soket2 = 5;
						soket3 = 18;
						soket4 = 15;
						soket5 = 7;
						soket6 = 20;
						soket7 = 18;
						soket8 = 11;
					}
					if (estrategia == 9) {
						soket1 = 14;
						soket2 = 5;
						soket3 = 16;
						soket4 = 17;
						soket5 = 7;
						soket6 = 19;
						soket7 = 13;
						soket8 = 11;
					}
					if (estrategia == 10) {
						soket1 = 2;
						soket2 = 5;
						soket3 = 0;
						soket4 = 17;
						soket5 = 7;
						soket6 = 16;
						soket7 = 8;
						soket8 = 11;
					}
					if (estrategia == 11) {
						soket1 = 4;
						soket2 = 5;
						soket3 = 15;
						soket4 = 21;
						soket5 = 7;
						soket6 = 16;
						soket7 = 8;
						soket8 = 3;
					}

					if (estrategia == 12) {
						soket1 = 5;
						soket2 = 12;
						soket3 = 16;
						soket4 = 9;
						soket5 = 18;
						soket6 = 0;
						soket7 = 13;
						soket8 = 2;
					}
					if (estrategia == 13) {
						soket1 = 10;
						soket2 = 12;
						soket3 = 4;
						soket4 = 5;
						soket5 = 15;
						soket6 = 11;
						soket7 = 13;
						soket8 = 2;
					}

					if (estrategia == 14) {
						soket1 = 1;
						soket2 = 14;
						soket3 = 15;
						soket4 = 8;
						soket5 = 11;
						soket6 = 7;
						soket7 = 19;
						soket8 = 3;
					}
					if (estrategia == 15) {
						soket1 = 1;
						soket2 = 3;
						soket3 = 4;
						soket4 = 15;
						soket5 = 20;
						soket6 = 18;
						soket7 = 17;
						soket8 = 2;
					}
					if (estrategia == 16) {
						soket1 = 1;
						soket2 = 0;
						soket3 = 4;
						soket4 = 15;
						soket5 = 5;
						soket6 = 18;
						soket7 = 17;
						soket8 = 2;
					}
					if (estrategia == 17) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 0;
						soket4 = 8;
						soket5 = 21;
						soket6 = 1;
						soket7 = 17;
						soket8 = 9;
					}
					if (estrategia == 18) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 14;
						soket4 = 10;
						soket5 = 20;
						soket6 = 21;
						soket7 = 2;
						soket8 = 9;
					}
					if (estrategia == 19) {
						soket1 = 11;
						soket2 = 16;
						soket3 = 15;
						soket4 = 18;
						soket5 = 19;
						soket6 = 2;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 20) {
						soket1 = 40;
						soket2 = 45;
						soket3 = 48;
						soket4 = 47;
						soket5 = 7;
						soket6 = 1;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 21) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 14;
						soket4 = 8;
						soket5 = 16;
						soket6 = 1;
						soket7 = 17;
						soket8 = 9;
					}
					if (estrategia == 22) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 16;
						soket4 = 44;
						soket5 = 45;
						soket6 = 40;
						soket7 = 2;
						soket8 = 9;
					}
					if (estrategia == 23) {
						soket1 = 11;
						soket2 = 3;
						soket3 = 15;
						soket4 = 18;
						soket5 = 47;
						soket6 = 2;
						soket7 = 48;
						soket8 = 9;
					}
					if (estrategia == 24) {
						soket1 = 19;
						soket2 = 3;
						soket3 = 15;
						soket4 = 18;
						soket5 = 0;
						soket6 = 1;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 25) {
						soket1 = 11;
						soket2 = 14;
						soket3 = 15;
						soket4 = 17;
						soket5 = 50;
						soket6 = 1;
						soket7 = 41;
						soket8 = 3;
					}
					if (estrategia == 26) {
						soket1 = 45;
						soket2 = 48;
						soket3 = 15;
						soket4 = 17;
						soket5 = 2;
						soket6 = 49;
						soket7 = 14;
						soket8 = 3;
					}
					if (estrategia == 27) {
						soket1 = 10;
						soket2 = 5;
						soket3 = 18;
						soket4 = 47;
						soket5 = 6;
						soket6 = 17;
						soket7 = 41;
						soket8 = 3;
					}
					if (estrategia == 28) {
						soket1 = 14;
						soket2 = 5;
						soket3 = 44;
						soket4 = 15;
						soket5 = 7;
						soket6 = 20;
						soket7 = 18;
						soket8 = 45;
					}
					if (estrategia == 29) {
						soket1 = 40;
						soket2 = 5;
						soket3 = 16;
						soket4 = 41;
						soket5 = 7;
						soket6 = 19;
						soket7 = 13;
						soket8 = 11;
					}
					if (estrategia == 30) {
						soket1 = 44;
						soket2 = 5;
						soket3 = 0;
						soket4 = 17;
						soket5 = 7;
						soket6 = 42;
						soket7 = 8;
						soket8 = 11;
					}
					if (estrategia == 31) {
						soket1 = 48;
						soket2 = 5;
						soket3 = 15;
						soket4 = 21;
						soket5 = 44;
						soket6 = 16;
						soket7 = 8;
						soket8 = 3;
					}
					
					if (estrategia == 32) {
						soket1 = 5;
						soket2 = 48;
						soket3 = 16;
						soket4 = 9;
						soket5 = 18;
						soket6 = 49;
						soket7 = 13;
						soket8 = 2;
					}
					if (estrategia == 33) {
						soket1 = 10;
						soket2 = 44;
						soket3 = 4;
						soket4 = 5;
						soket5 = 48;
						soket6 = 11;
						soket7 = 13;
						soket8 = 2;
					}
					
					if (estrategia == 34) {
						soket1 = 1;
						soket2 = 41;
						soket3 = 15;
						soket4 = 8;
						soket5 = 11;
						soket6 = 7;
						soket7 = 47;
						soket8 = 3;
					}
					if (estrategia == 35) {
						soket1 = 40;
						soket2 = 47;
						soket3 = 4;
						soket4 = 15;
						soket5 = 20;
						soket6 = 18;
						soket7 = 17;
						soket8 = 2;
					}
					if (estrategia == 36) {
						soket1 = 40;
						soket2 = 0;
						soket3 = 4;
						soket4 = 15;
						soket5 = 5;
						soket6 = 46;
						soket7 = 17;
						soket8 = 2;
					}
					if (estrategia == 37) {
						soket1 = 49;
						soket2 = 3;
						soket3 = 45;
						soket4 = 8;
						soket5 = 21;
						soket6 = 1;
						soket7 = 17;
						soket8 = 9;
					}
					if (estrategia == 38) {
						soket1 = 44;
						soket2 = 3;
						soket3 = 14;
						soket4 = 41;
						soket5 = 20;
						soket6 = 21;
						soket7 = 2;
						soket8 = 9;
					}
					if (estrategia == 39) {
						soket1 = 45;
						soket2 = 16;
						soket3 = 15;
						soket4 = 18;
						soket5 = 19;
						soket6 = 42;
						soket7 = 8;
						soket8 = 9;
					}
					if (estrategia == 40) {
						soket1 = 44;
						soket2 = 0;
						soket3 = 15;
						soket4 = 5;
						soket5 = 50;
						soket6 = 1;
						soket7 = 8;
						soket8 = 9;
					}
				}
			}
		}
		
		
		yield break;
		
	}

	IEnumerator parte1 () {

		yield return new WaitForSeconds(tempo);

		tempo = Random.Range (5, 14);
		
		select = Random.Range (1, 9);
		local1 = Random.Range (0, 7);
	
		StartCoroutine(parte1());	
	if (torre2.gameObject.active == false) {
			if (torre1.gameObject.active == true) {
				Instantiate (enemy [mob], new Vector3 (spawn1 [local1].transform.localPosition.x, spawn1 [local1].transform.localPosition.y, spawn1 [local1].transform.localPosition.z), Quaternion.identity);
			}
		}

		if (torre1.gameObject.active == false) {
			if (torre2.gameObject.active == true) {
				Instantiate (enemy [mob], new Vector3 (spawn2 [local1].transform.localPosition.x, spawn2 [local1].transform.localPosition.y, spawn2 [local1].transform.localPosition.z), Quaternion.identity);
			}
		}
		if (torre1.gameObject.active == true) {
			if (torre2.gameObject.active == true) {
				Instantiate (enemy [mob], new Vector3 (spawn3 [local1].transform.localPosition.x, spawn3 [local1].transform.localPosition.y, spawn3 [local1].transform.localPosition.z), Quaternion.identity);
			}
		}

		if (torre1.gameObject.active == false) {
			if (torre2.gameObject.active == false) {
				Instantiate (enemy [mob], new Vector3 (spawn4 [local1].transform.localPosition.x, spawn4 [local1].transform.localPosition.y, spawn4 [local1].transform.localPosition.z), Quaternion.identity);
			}
		}
		yield break;
		
	}
	// Update is called once per frame
	void Update () {
		vitor.text = vitoric.ToString ();
		pode = gerenciar_jogo1.pode;

		if (select == 1) {
			mob = soket1;
		
		}
		if (select == 2) {
			mob = soket2;
			
		}
		if (select == 3) {
			mob = soket3;
			
		}
		if (select == 4) {
			mob = soket4;
			
		}
		if (select == 5) {
			mob = soket5;
			
		}
		if (select == 6) {
			mob = soket6;
			
		}
		if (select == 7) {
			mob = soket7;
			
		}
		if (select == 8) {
			mob = soket8;
			
		}
		if (select == 9) {
			mob = soket8;
			
		}
		

	}
}

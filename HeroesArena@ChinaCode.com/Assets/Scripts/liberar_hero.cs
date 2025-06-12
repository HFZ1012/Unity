using UnityEngine;
using System.Collections;

public class liberar_hero : MonoBehaviour {

	public int codigo_hero;
	public int vitorias;
	public int primeiravez;
	public int evoluirhero1;
	public GameObject estrela1;

	public int receptor;
	// Use this for initialization
	void Start () {

		StartCoroutine (checar5 ());
		evoluirhero1 = PlayerPrefs.GetInt ("evoluirxp");
		vitorias = PlayerPrefs.GetInt ("ouro");
		primeiravez = PlayerPrefs.GetInt ("primeira1");

	
	
	
	}
	IEnumerator checar5 () {
		
		yield return new WaitForSeconds(0.2f);
		if (evoluirhero1 == 2) {
		
			estrela1.gameObject.SetActive(true);
			PlayerPrefs.SetInt ("evoluirxp", 1);
		
		}

		yield break;
		
	}
	IEnumerator checarpremio () {
		
		yield return new WaitForSeconds(0.2f);

		Application.LoadLevel ("hero");
		
		yield break;
		
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.2f);
		StartCoroutine (checarpremio ());
		if (primeiravez == 0) {
			
			PlayerPrefs.SetInt ("codigo_hero7", 2);

		
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint7", 800);
			PlayerPrefs.SetInt ("damage7", 80);
			
			//-------------------------------------
			
		
			
			
		}
		if (primeiravez == 1) {

				PlayerPrefs.SetInt ("codigo_hero7", 2);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint7", 800);
			PlayerPrefs.SetInt ("damage7", 80);
			
			//-------------------------------------
						
		}
		if (primeiravez == 2) {
					
			PlayerPrefs.SetInt ("codigo_hero2", 2);
			//-------------------------------------
			PlayerPrefs.SetInt ("hitpoint2", 190);
			PlayerPrefs.SetInt ("damage2", 50);
	
			//-------------------------------------
			
		}
		if (primeiravez == 3) {
			

			PlayerPrefs.SetInt ("codigo_hero26", 2);
			
			PlayerPrefs.SetInt ("hitpoint26", 30);
			PlayerPrefs.SetInt ("damage26", 15);

		}
		if (primeiravez == 4) {
			
					
			PlayerPrefs.SetInt ("codigo_hero10", 2);
			
			PlayerPrefs.SetInt ("hitpoint10", 300);
			PlayerPrefs.SetInt ("damage10", 50);
			
		}
		if (primeiravez == 5) {
			
		
			PlayerPrefs.SetInt ("codigo_hero23", 2);

			
		}
		if (primeiravez == 6) {
			
			

			PlayerPrefs.SetInt ("codigo_hero5", 2);
			
			PlayerPrefs.SetInt ("hitpoint5", 990);
			PlayerPrefs.SetInt ("damage5", 90);
			
		}


		if (primeiravez == 7) {
			
			PlayerPrefs.SetInt ("codigo_hero20", 2);
			PlayerPrefs.SetInt ("hitpoint20", 130);
			PlayerPrefs.SetInt ("damage20", 35);
		
			
		}
		if (primeiravez == 8) {
			

			PlayerPrefs.SetInt ("codigo_hero6", 2);
			
			PlayerPrefs.SetInt ("hitpoint6", 250);
			PlayerPrefs.SetInt ("damage6", 65);
			
		}
		if (primeiravez == 9) {
			

			PlayerPrefs.SetInt ("codigo_hero18", 2);
			PlayerPrefs.SetInt ("hitpoint18", 300);
			PlayerPrefs.SetInt ("damage18", 60);

			
		}
		if (primeiravez == 10) {
			
			

			PlayerPrefs.SetInt ("codigo_hero17", 2);
			PlayerPrefs.SetInt ("hitpoint17", 130);
			PlayerPrefs.SetInt ("damage17", 35);
			
		}
		if (primeiravez == 11) {
			

			PlayerPrefs.SetInt ("codigo_hero13", 2);
			PlayerPrefs.SetInt ("hitpoint13", 1500);
			PlayerPrefs.SetInt ("damage13", 100);
			
			
		}
		if (primeiravez == 12) {
			
		
			PlayerPrefs.SetInt ("codigo_hero24", 2);
			
			
		}


		if (primeiravez == 13) {
			

			PlayerPrefs.SetInt ("codigo_hero9", 2);
		
			PlayerPrefs.SetInt ("hitpoint9", 185);
			PlayerPrefs.SetInt ("damage9", 40);
			
		}
		if (primeiravez == 14) {
			
			
		
			PlayerPrefs.SetInt ("codigo_hero4", 2);
			PlayerPrefs.SetInt ("hitpoint4", 850);
			PlayerPrefs.SetInt ("damage4", 75);
		
			
			
		}
		if (primeiravez == 15) {
			
			

			
			PlayerPrefs.SetInt ("codigo_hero22", 2);
			
			
		}
		if (primeiravez == 16) {
			
			PlayerPrefs.SetInt ("codigo_hero12", 2);

			PlayerPrefs.SetInt ("hitpoint12", 2600);
			PlayerPrefs.SetInt ("damage12", 150);
			
			
		}
		if (primeiravez == 17) {
			
		PlayerPrefs.SetInt ("hitpoint16", 3000);
			PlayerPrefs.SetInt ("damage16", 200);
			
			PlayerPrefs.SetInt ("codigo_hero16", 2);
			
			
			
		}
		yield break;
		
	}
	// Update is called once per frame
	void Update () {

		evoluirhero1 = PlayerPrefs.GetInt ("evoluirxp");
	
		primeiravez = PlayerPrefs.GetInt ("primeira1");
		receptor = PlayerPrefs.GetInt ("receptor");
		vitorias = PlayerPrefs.GetInt ("ouro");
		if (receptor == 2) {
			if (vitorias >= 100) {
			
				primeiravez = primeiravez + 1;
				PlayerPrefs.SetInt ("primeira1", primeiravez);
				PlayerPrefs.SetInt ("ouro", 0);
				StartCoroutine (checar ());

				PlayerPrefs.SetInt("receptor", 1);
			
			}
		}
	
	}
}

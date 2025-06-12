using UnityEngine;
using System.Collections;

public class lodageral : MonoBehaviour {
	public int tutorial;
	public int tutorial2;
	// Use this for initialization
	void Start () {

		tutorial = PlayerPrefs.GetInt ("tutor");
		tutorial2 = PlayerPrefs.GetInt ("tutor2");
		StartCoroutine (checar ());


		//--------------------------------------------------
	
		PlayerPrefs.SetInt ("hitpoint_p40", 3000);
		PlayerPrefs.SetInt ("damage_p40", 190);
		//-------------------------------------
		//--------------------------------------------------

		
		PlayerPrefs.SetInt ("hitpoint_p41", 1500);
		PlayerPrefs.SetInt ("damage_p41", 130);
		//-------------------------------------
		//--------------------------------------------------

		
		PlayerPrefs.SetInt ("hitpoint_p42", 3500);
		PlayerPrefs.SetInt ("damage_p42", 250);
		//-------------------------------------
		//--------------------------------------------------

		
		PlayerPrefs.SetInt ("hitpoint_p44", 130);
		PlayerPrefs.SetInt ("damage_p44", 35);
		//-------------------------------------
		//--------------------------------------------------
	
		
		PlayerPrefs.SetInt ("hitpoint_p45", 750);
		PlayerPrefs.SetInt ("damage_p45", 85);
		//-------------------------------------
		//--------------------------------------------------
	
		
		PlayerPrefs.SetInt ("hitpoint_p46", 2500);
		PlayerPrefs.SetInt ("damage_p46", 130);
		//-------------------------------------
		//--------------------------------------------------
	
		
		PlayerPrefs.SetInt ("hitpoint_p47", 990);
		PlayerPrefs.SetInt ("damage_p47", 90);
		//-------------------------------------
		//--------------------------------------------------

		
		PlayerPrefs.SetInt ("hitpoint_p48", 1100);
		PlayerPrefs.SetInt ("damage_p48", 90);
		//-------------------------------------
		//--------------------------------------------------

		//--------------------------------------------------
		PlayerPrefs.SetInt ("hitpoint_p49", 190);
		PlayerPrefs.SetInt ("damage_p49", 70);
		//-------------------------------------
		
		PlayerPrefs.SetInt ("hitpoint_p50", 1500);
		PlayerPrefs.SetInt ("damage_p50", 100);
		//-------------------------------------

		//-----------------------------------------------------------------
	
	
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.5f);

		if (tutorial == 0) {
			
			PlayerPrefs.SetInt ("tutor", 1);
			
		}
		if (tutorial2 == 0) {
			
			PlayerPrefs.SetInt ("tutor2", 1);

		}
		StartCoroutine (checar2 ());

		yield break;
		
	}
	IEnumerator checar2 () {
		
		yield return new WaitForSeconds(6f);
		
	
	
	
		if (tutorial == 1) {

			PlayerPrefs.SetString ("usuario", "Fox");
			PlayerPrefs.SetString ("player", "You");
			StartCoroutine (checar3 ());
		}
		
		if (tutorial != 1) {
			
			Application.LoadLevel("menu");
			
		}
		yield break;
		
	}
	IEnumerator checar3 () {
		
		yield return new WaitForSeconds(1f);

		
		Application.LoadLevel("gameplay1");
		yield break;
		
	}
	// Update is called once per frame
	void Update () {
		tutorial = PlayerPrefs.GetInt ("tutor");
		tutorial2 = PlayerPrefs.GetInt ("tutor2");
		if (tutorial2 == 1) {
			
						
			PlayerPrefs.SetInt ("codigo_hero40", 3);//
			PlayerPrefs.SetInt ("codigo_hero41", 3);//
			PlayerPrefs.SetInt ("codigo_hero42", 3);//
			PlayerPrefs.SetInt ("codigo_hero44", 3);//
			PlayerPrefs.SetInt ("codigo_hero45", 3);//
			PlayerPrefs.SetInt ("codigo_hero46", 3);//
			PlayerPrefs.SetInt ("codigo_hero47", 3);//
			PlayerPrefs.SetInt ("codigo_hero48", 3);//
			PlayerPrefs.SetInt ("codigo_hero49", 3);//
			PlayerPrefs.SetInt ("codigo_hero50", 3);//
			

			
			PlayerPrefs.SetInt ("hitpoint26", 30);
			PlayerPrefs.SetInt ("damage26", 15);
			
			PlayerPrefs.SetInt ("hitpoint_p26", 30);
			PlayerPrefs.SetInt ("damage_p26", 15);
			//----------------------------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint40", 3000);
			PlayerPrefs.SetInt ("damage40", 190);
			
			PlayerPrefs.SetInt ("hitpoint_p40", 3000);
			PlayerPrefs.SetInt ("damage_p40", 190);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint41", 1500);
			PlayerPrefs.SetInt ("damage41", 130);
			
			PlayerPrefs.SetInt ("hitpoint_p41", 1500);
			PlayerPrefs.SetInt ("damage_p41", 130);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint42", 3500);
			PlayerPrefs.SetInt ("damage42", 250);
			
			PlayerPrefs.SetInt ("hitpoint_p42", 3500);
			PlayerPrefs.SetInt ("damage_p42", 250);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint44", 130);
			PlayerPrefs.SetInt ("damage44", 35);
			
			PlayerPrefs.SetInt ("hitpoint_p44", 130);
			PlayerPrefs.SetInt ("damage_p44", 35);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint45", 750);
			PlayerPrefs.SetInt ("damage45", 85);
			
			PlayerPrefs.SetInt ("hitpoint_p45", 750);
			PlayerPrefs.SetInt ("damage_p45", 85);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint46", 2500);
			PlayerPrefs.SetInt ("damage46", 130);
			
			PlayerPrefs.SetInt ("hitpoint_p46", 2500);
			PlayerPrefs.SetInt ("damage_p46", 130);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint47", 990);
			PlayerPrefs.SetInt ("damage47", 90);
			
			PlayerPrefs.SetInt ("hitpoint_p47", 990);
			PlayerPrefs.SetInt ("damage_p47", 90);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint48", 1100);
			PlayerPrefs.SetInt ("damage48", 90);
			
			PlayerPrefs.SetInt ("hitpoint_p48", 1100);
			PlayerPrefs.SetInt ("damage_p48", 90);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint49", 190);
			PlayerPrefs.SetInt ("damage49", 70);
			
			PlayerPrefs.SetInt ("hitpoint_p49", 190);
			PlayerPrefs.SetInt ("damage_p49", 70);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint50", 1500);
			PlayerPrefs.SetInt ("damage50", 100);
			
			PlayerPrefs.SetInt ("hitpoint_p50", 1500);
			PlayerPrefs.SetInt ("damage_p50", 100);
			//-------------------------------------
			
			
			
			
		}
		if (tutorial == 1) {
			
			PlayerPrefs.SetInt ("codigo_hero1", 2);//
			PlayerPrefs.SetInt ("codigo_hero2", 3);
			PlayerPrefs.SetInt ("codigo_hero3", 2);//
			PlayerPrefs.SetInt ("codigo_hero4", 3);
			PlayerPrefs.SetInt ("codigo_hero5", 3);
			PlayerPrefs.SetInt ("codigo_hero6", 3);
			PlayerPrefs.SetInt ("codigo_hero7", 3);
			PlayerPrefs.SetInt ("codigo_hero8", 2);//
			PlayerPrefs.SetInt ("codigo_hero9", 3);
			PlayerPrefs.SetInt ("codigo_hero10", 3);
			PlayerPrefs.SetInt ("codigo_hero11", 2);//
			PlayerPrefs.SetInt ("codigo_hero12", 3);
			PlayerPrefs.SetInt ("codigo_hero13", 3);
			PlayerPrefs.SetInt ("codigo_hero14", 2);//
			PlayerPrefs.SetInt ("codigo_hero15", 2);//
			PlayerPrefs.SetInt ("codigo_hero16", 3);
			PlayerPrefs.SetInt ("codigo_hero17", 3);
			PlayerPrefs.SetInt ("codigo_hero18", 3);
			PlayerPrefs.SetInt ("codigo_hero19", 2);//
			PlayerPrefs.SetInt ("codigo_hero20", 3);
			PlayerPrefs.SetInt ("codigo_hero21", 2);//
			PlayerPrefs.SetInt ("codigo_hero22", 3);
			PlayerPrefs.SetInt ("codigo_hero23", 3);
			PlayerPrefs.SetInt ("codigo_hero24", 3);
			PlayerPrefs.SetInt ("codigo_hero25", 3);
			PlayerPrefs.SetInt ("codigo_hero26", 3);

			PlayerPrefs.SetInt ("codigo_hero40", 3);//
			PlayerPrefs.SetInt ("codigo_hero41", 3);//
			PlayerPrefs.SetInt ("codigo_hero42", 3);//
			PlayerPrefs.SetInt ("codigo_hero44", 3);//
			PlayerPrefs.SetInt ("codigo_hero45", 3);//
			PlayerPrefs.SetInt ("codigo_hero46", 3);//
			PlayerPrefs.SetInt ("codigo_hero47", 3);//
			PlayerPrefs.SetInt ("codigo_hero48", 3);//
			PlayerPrefs.SetInt ("codigo_hero49", 3);//
			PlayerPrefs.SetInt ("codigo_hero50", 3);//

			PlayerPrefs.SetInt ("sok1", 1);
			PlayerPrefs.SetInt ("sok2", 3);
			PlayerPrefs.SetInt ("sok3", 14);
			PlayerPrefs.SetInt ("sok4", 8);
			PlayerPrefs.SetInt ("sok5", 11);
			PlayerPrefs.SetInt ("sok6", 15);
			PlayerPrefs.SetInt ("sok7", 19);
			PlayerPrefs.SetInt ("sok8", 21);

			
			PlayerPrefs.SetInt ("hitpoint1", 130);
			PlayerPrefs.SetInt ("damage1", 35);
			
			PlayerPrefs.SetInt ("hitpoint_p1", 130);
			PlayerPrefs.SetInt ("damage_p1", 35);
			//-------------------------------------
			PlayerPrefs.SetInt ("hitpoint2", 190);
			PlayerPrefs.SetInt ("damage2", 50);
			
			PlayerPrefs.SetInt ("hitpoint_p2", 190);
			PlayerPrefs.SetInt ("damage_p2", 50);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint3", 180);
			PlayerPrefs.SetInt ("damage3", 40);
			
			PlayerPrefs.SetInt ("hitpoint_p3", 180);
			PlayerPrefs.SetInt ("damage_p3", 40);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint4", 850);
			PlayerPrefs.SetInt ("damage4", 75);
			
			PlayerPrefs.SetInt ("hitpoint_p4", 850);
			PlayerPrefs.SetInt ("damage_p4", 75);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint5", 990);
			PlayerPrefs.SetInt ("damage5", 90);
			
			PlayerPrefs.SetInt ("hitpoint_p5", 990);
			PlayerPrefs.SetInt ("damage_p5", 90);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint6", 250);
			PlayerPrefs.SetInt ("damage6", 65);
			
			PlayerPrefs.SetInt ("hitpoint_p6", 250);
			PlayerPrefs.SetInt ("damage_p6", 65);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint7", 800);
			PlayerPrefs.SetInt ("damage7", 80);
			
			PlayerPrefs.SetInt ("hitpoint_p7", 800);
			PlayerPrefs.SetInt ("damage_p7", 80);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint8", 130);
			PlayerPrefs.SetInt ("damage8", 30);
			
			PlayerPrefs.SetInt ("hitpoint_p8", 130);
			PlayerPrefs.SetInt ("damage_p8", 30);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint9", 185);
			PlayerPrefs.SetInt ("damage9", 40);
			
			PlayerPrefs.SetInt ("hitpoint_p9", 185);
			PlayerPrefs.SetInt ("damage_p9", 40);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint10", 300);
			PlayerPrefs.SetInt ("damage10", 50);
			
			PlayerPrefs.SetInt ("hitpoint_p10", 300);
			PlayerPrefs.SetInt ("damage_p10", 50);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint11", 150);
			PlayerPrefs.SetInt ("damage11", 35);
			
			PlayerPrefs.SetInt ("hitpoint_p11", 150);
			PlayerPrefs.SetInt ("damage_p11", 35);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint12", 2600);
			PlayerPrefs.SetInt ("damage12", 150);
			
			PlayerPrefs.SetInt ("hitpoint_p12", 2600);
			PlayerPrefs.SetInt ("damage_p12", 150);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint13", 1500);
			PlayerPrefs.SetInt ("damage13", 100);
			
			PlayerPrefs.SetInt ("hitpoint_p13", 1500);
			PlayerPrefs.SetInt ("damage_p13", 100);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint14", 350);
			PlayerPrefs.SetInt ("damage14", 50);
			
			PlayerPrefs.SetInt ("hitpoint_p14", 350);
			PlayerPrefs.SetInt ("damage_p14", 50);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint15", 1700);
			PlayerPrefs.SetInt ("damage15", 110);
			
			PlayerPrefs.SetInt ("hitpoint_p15", 1700);
			PlayerPrefs.SetInt ("damage_p15", 110);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint16", 3000);
			PlayerPrefs.SetInt ("damage16", 200);
			
			PlayerPrefs.SetInt ("hitpoint_p16", 3000);
			PlayerPrefs.SetInt ("damage_p16", 200);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint17", 130);
			PlayerPrefs.SetInt ("damage17", 35);
			
			PlayerPrefs.SetInt ("hitpoint_p17", 130);
			PlayerPrefs.SetInt ("damage_p17", 35);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint18", 300);
			PlayerPrefs.SetInt ("damage18", 60);
			
			PlayerPrefs.SetInt ("hitpoint_p18", 300);
			PlayerPrefs.SetInt ("damage_p18", 60);
			//-------------------------------------
			
			PlayerPrefs.SetInt ("hitpoint19", 120);
			PlayerPrefs.SetInt ("damage19", 35);
			
			PlayerPrefs.SetInt ("hitpoint_p19", 120);
			PlayerPrefs.SetInt ("damage_p19", 35);

			PlayerPrefs.SetInt ("hitpoint_p19", 120);
			PlayerPrefs.SetInt ("damage_p19", 35);
//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint20", 130);
			PlayerPrefs.SetInt ("damage20", 35);
			
			PlayerPrefs.SetInt ("hitpoint_p20", 130);
			PlayerPrefs.SetInt ("damage_p20", 35);
			//-------------------------------------

			PlayerPrefs.SetInt ("hitpoint_p21", 1);
			PlayerPrefs.SetInt ("damage_p21", 200);

			PlayerPrefs.SetInt ("hitpoint26", 30);
			PlayerPrefs.SetInt ("damage26", 15);

			PlayerPrefs.SetInt ("hitpoint_p26", 30);
			PlayerPrefs.SetInt ("damage_p26", 15);
//----------------------------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint40", 3000);
			PlayerPrefs.SetInt ("damage40", 190);
			
			PlayerPrefs.SetInt ("hitpoint_p40", 3000);
			PlayerPrefs.SetInt ("damage_p40", 190);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint41", 1500);
			PlayerPrefs.SetInt ("damage41", 130);
			
			PlayerPrefs.SetInt ("hitpoint_p41", 1500);
			PlayerPrefs.SetInt ("damage_p41", 130);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint42", 3500);
			PlayerPrefs.SetInt ("damage42", 250);
			
			PlayerPrefs.SetInt ("hitpoint_p42", 3500);
			PlayerPrefs.SetInt ("damage_p42", 250);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint44", 130);
			PlayerPrefs.SetInt ("damage44", 35);
			
			PlayerPrefs.SetInt ("hitpoint_p44", 130);
			PlayerPrefs.SetInt ("damage_p44", 35);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint45", 750);
			PlayerPrefs.SetInt ("damage45", 85);
			
			PlayerPrefs.SetInt ("hitpoint_p45", 750);
			PlayerPrefs.SetInt ("damage_p45", 85);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint46", 2500);
			PlayerPrefs.SetInt ("damage46", 130);
			
			PlayerPrefs.SetInt ("hitpoint_p46", 2500);
			PlayerPrefs.SetInt ("damage_p46", 130);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint47", 990);
			PlayerPrefs.SetInt ("damage47", 90);
			
			PlayerPrefs.SetInt ("hitpoint_p47", 990);
			PlayerPrefs.SetInt ("damage_p47", 90);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint48", 1100);
			PlayerPrefs.SetInt ("damage48", 90);
			
			PlayerPrefs.SetInt ("hitpoint_p48", 1100);
			PlayerPrefs.SetInt ("damage_p48", 90);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint49", 190);
			PlayerPrefs.SetInt ("damage49", 70);
			
			PlayerPrefs.SetInt ("hitpoint_p49", 190);
			PlayerPrefs.SetInt ("damage_p49", 70);
			//-------------------------------------
			//--------------------------------------------------
			PlayerPrefs.SetInt ("hitpoint50", 1500);
			PlayerPrefs.SetInt ("damage50", 100);
			
			PlayerPrefs.SetInt ("hitpoint_p50", 1500);
			PlayerPrefs.SetInt ("damage_p50", 100);
			//-------------------------------------
		

			
			
		}
			
			
			

	
	}
}

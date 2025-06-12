using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

    public static UIController instance;
    //public GameObject ScrollUI;
   // public GameObject CancelBtn;
   // public GameObject TutorialBlock;



	void Update(){



	}
    void Awake()
    {
        //PlayerPrefs.DeleteAll();      //Tutorial for every Launch
        if(!PlayerPrefs.HasKey ("FirstTime"))
        {
            PlayerPrefs.SetInt("FirstTime", 1);
           
        }
        instance = this;
    }

	public void p1_hero1 () 
    {
		MainController.instance.SpawnBuilding("p1_hero1");
        //DisableScrollUI();
    }

	public void p1_hero2 () 
	{
		MainController.instance.SpawnBuilding("p1_hero2");
		//DisableScrollUI();
	}

	public void p1_hero3 () 
	{
		MainController.instance.SpawnBuilding("p1_hero3");
		//DisableScrollUI();
	}

	public void p1_hero4 () 
	{
		MainController.instance.SpawnBuilding("p1_hero4");
		//DisableScrollUI();
	}

	public void p1_hero5 () 
	{
		MainController.instance.SpawnBuilding("p1_hero5");
		//DisableScrollUI();
	}

	public void p1_hero6 () 
	{
		MainController.instance.SpawnBuilding("p1_hero6");
		//DisableScrollUI();
	}

	public void p1_hero7 () 
	{
		MainController.instance.SpawnBuilding("p1_hero7");
		//DisableScrollUI();
	}

	public void p1_hero8 () 
	{
		MainController.instance.SpawnBuilding("p1_hero8");
		//DisableScrollUI();
	}

	public void p1_hero9 () 
	{
		MainController.instance.SpawnBuilding("p1_hero9");
		//DisableScrollUI();
	}

	public void p1_hero10 () 
	{
		MainController.instance.SpawnBuilding("p1_hero10");
		//DisableScrollUI();
	}

	public void p1_hero11 () 
	{
		MainController.instance.SpawnBuilding("p1_hero11");
		//DisableScrollUI();
	}

	public void p1_hero12 () 
	{
		MainController.instance.SpawnBuilding("p1_hero12");
		//DisableScrollUI();
	}

	public void p1_hero13 () 
	{
		MainController.instance.SpawnBuilding("p1_hero13");
		//DisableScrollUI();
	}

	public void p1_hero14 () 
	{
		MainController.instance.SpawnBuilding("p1_hero14");
		//DisableScrollUI();
	}
	public void p1_hero15 () 
	{
		MainController.instance.SpawnBuilding("p1_hero15");
		//DisableScrollUI();
	}
	public void p1_hero16 () 
	{
		MainController.instance.SpawnBuilding("p1_hero16");
		//DisableScrollUI();
	}
	public void p1_hero17 () 
	{
		MainController.instance.SpawnBuilding("p1_hero17");
		//DisableScrollUI();
	}
	public void p1_hero18 () 
	{
		MainController.instance.SpawnBuilding("p1_hero18");
		//DisableScrollUI();
	}
	public void p1_hero19 () 
	{
		MainController.instance.SpawnBuilding("p1_hero19");
		//DisableScrollUI();
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

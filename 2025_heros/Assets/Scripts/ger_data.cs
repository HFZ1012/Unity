using UnityEngine;
using System.Collections;

public class ger_data : MonoBehaviour {
	
	public int dy;
	public int mm;
	public int hr;
	public int sc;
	public int year;
	// Use this for initialization
	void Start () {
		
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
		StartCoroutine (checar ());
		
	}
	IEnumerator checar () {
		
		yield return new WaitForSeconds(0.4f);
		PlayerPrefs.SetInt("net_dia", dy);
		PlayerPrefs.SetInt("net_hora", hr);
		PlayerPrefs.SetInt("net_minuto", mm);
		PlayerPrefs.SetInt("net_segundo", sc);
		PlayerPrefs.SetInt("net_ano", year);
		yield break;
		
	}
	// Update is called once per frame
	void Update () {
		
	
		
		
		
	}
}

﻿using UnityEngine;

public class checarnet : MonoBehaviour
{
	private const bool allowCarrierDataNetwork = false;
	private const string pingAddress = "8.8.8.8"; // Google Public DNS server
	private const float waitingTime = 2.0f;
	
	private Ping ping;
	private float pingStartTime;
	public GameObject aviso1;
	public void Start()
	{
		bool internetPossiblyAvailable;
		switch (Application.internetReachability)
		{
		case NetworkReachability.ReachableViaLocalAreaNetwork:
			internetPossiblyAvailable = true;
			break;
		case NetworkReachability.ReachableViaCarrierDataNetwork:
			internetPossiblyAvailable = allowCarrierDataNetwork;
			break;
		default:
			internetPossiblyAvailable = false;
			break;
		}
		if (!internetPossiblyAvailable)
		{
			InternetIsNotAvailable();
			return;
		}
		ping = new Ping(pingAddress);
		pingStartTime = Time.time;
	}
	
	public void Update()
	{
		if (ping != null)
		{
			bool stopCheck = true;
			if (ping.isDone)
			{
				if (ping.time >= 0)
					InternetAvailable();
				else
					InternetIsNotAvailable();
			}
			else if (Time.time - pingStartTime < waitingTime)
				stopCheck = false;
			else
				InternetIsNotAvailable();
			if (stopCheck)
				ping = null;
		}
	}
	
	private void InternetIsNotAvailable()
	{
		aviso1.gameObject.SetActive (true);
	}
	public void reconec(){
	
		Application.LoadLevel ("load_inicial");
	
	}
	
	private void InternetAvailable()
	{

	}
}
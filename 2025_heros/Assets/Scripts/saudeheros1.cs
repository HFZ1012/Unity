using UnityEngine;
using System.Collections;

public class saudeheros1 : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {

		target = GameObject.FindWithTag("lokatamarelo").transform;
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt(target);
	
	}
}

/// <summary>
/// Enemy spawner. auto Re-Spawning an Enemy by Random index of Objectman[]
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public bool Enabled = true;
	public GameObject[] Objectman; // Ememy object
	public float timeSpawn = 3;
	public int enemyCount = 10;
	public int radius;
	public string Type = "Enemy";
	private float timetemp = 0;
	private int indexSpawn;
	
	void Start ()
	{
		indexSpawn = Random.Range (0, Objectman.Length);
		timetemp = Time.time;
	}

	void Update ()
	{
		bool offlineMode = (!Network.isServer && !Network.isClient);
		// just a basic function to spawing an enemys by random index of Objectman[]
		if (!Enabled)
			return;
		
		if (Objectman [indexSpawn] == null)
			return;
		
		var gos = GameObject.FindGameObjectsWithTag (Objectman [indexSpawn].tag);
		
		if (gos.Length < enemyCount && Time.time > timetemp + timeSpawn) {
			timetemp = Time.time;
			
			if (!offlineMode) {
				if (Network.isServer)
					Network.Instantiate (Objectman [indexSpawn], transform.position + new Vector3 (Random.Range (-radius, radius), transform.position.y, Random.Range (-radius, radius)), Quaternion.identity, 0);
			} else {
				GameObject.Instantiate (Objectman [indexSpawn], transform.position + new Vector3 (Random.Range (-radius, radius), transform.position.y, Random.Range (-radius, radius)), Quaternion.identity);
			}
			
			indexSpawn = Random.Range (0, Objectman.Length);
		}
	}
	
	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere (transform.position, 0.5f);
		
	}
}

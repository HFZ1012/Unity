using UnityEngine;
using System.Collections;

public class SpawnerTrigger : MonoBehaviour
{

	public GameObject ObjectSpawn;
	public bool DestroyAfterActive = true;
	public float Duration = 3;
	public int radius = 1;
	public int SpawnNum = 1;
	
	void Start ()
	{
	
	}

	void Update ()
	{
	
	}
	
	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.GetComponent<PlayerManager> () || collider.gameObject.GetComponent<PlayerSave> ()) {
			if (DestroyAfterActive)
				GameObject.Destroy (this.gameObject);
			
			if (ObjectSpawn) {
				for (int i=0; i<SpawnNum; i++) {
					GameObject ob = (GameObject)GameObject.Instantiate (ObjectSpawn, this.transform.position + new Vector3 (Random.Range (-radius, radius), transform.position.y, Random.Range (-radius, radius)), this.transform.rotation);
					if (Duration > 0)
						GameObject.Destroy (ob.gameObject, Duration);
				}
			}
		}
	}
	
	void OnDrawGizmos ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere (transform.position, 0.5f);
		
	}
}

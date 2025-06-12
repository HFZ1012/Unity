using UnityEngine;
using System.Collections;

public class MiniMapPoint : MonoBehaviour {

	public Vector3 Scale = Vector3.one;
	void Start () {
		GameObject point = GameObject.CreatePrimitive(PrimitiveType.Quad);
		
		point.transform.Rotate(new Vector3(90,0,0));
		point.transform.position = this.transform.position + (Vector3.up * 10);
		point.layer = 8;// 8 is Minimap layer
		point.transform.parent = this.transform;
		if(point.GetComponent<Collider>())
			GameObject.Destroy(point.GetComponent<Collider>());
	}
	

	void Update () {
	
	}
}

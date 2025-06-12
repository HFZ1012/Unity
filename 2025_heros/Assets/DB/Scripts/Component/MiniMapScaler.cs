using UnityEngine;
using System.Collections;

public class MiniMapScaler : MonoBehaviour {
	public Camera MiniMapCamera;
	public Rect Size = new Rect(10, 10, 200, 200);
	public GUISkin Skin;
	
	void Start () {
		StyleManager StyleManage = (StyleManager)GameObject.FindObjectOfType (typeof(StyleManager));
		if (StyleManage && Skin == null)
			Skin = StyleManage.GetSkin (0);
	}

	void Update () {
		if(MiniMapCamera!=null){
			MiniMapCamera.pixelRect = new Rect(10,Screen.height - (Size.y + Size.height),Size.width,Size.height);
		}
	}
	
	void OnGUI(){
		if(Skin)
			GUI.skin = Skin;	
		
		//GUI.Box(Size,"");
	}
}

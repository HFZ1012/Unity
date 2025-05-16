using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{

  void OnMouseEnter()
  {
    Debug.Log("鼠标进入");
  }
  void OnMouseExit()
  {
    Debug.Log("鼠标离开");
  }
  void OnMouseDown()
  {
    Debug.Log("鼠标按下");
  }
  
  
  
}
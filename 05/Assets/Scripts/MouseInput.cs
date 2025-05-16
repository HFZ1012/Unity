using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseinput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log($"KeyDown(A)[{Time.frameCount}]");
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log($"KeyUp(A)[{Time.frameCount}]");
        }
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log($"Key(A)[{Time.frameCount}]");
        }
        Input.GetMouseButton(1);
        Vector2 mousePositiondelta = Input.mousePosition;
        Debug.Log($"MousePositionDelta:[{mousePositiondelta}]");
        Vector2 mouseScrollDelta = Input.mouseScrollDelta;
        Debug.Log($"MouseScrollDelta:[{mouseScrollDelta}]");
    }


    // void OnMouseEnter()
    // {
    //     Debug.Log("Mouse Enter");
    // }

    // void OnMouseExit()  
    // {
    //     Debug.Log("Mouse Exit");
    // }

    // void OnMouseDown()
    // {
    //     Debug.Log("Mouse Down");
    // }

    // void OnMouseUp()
    // {
    //     Debug.Log("Mouse Up");
    // }

    // void OnMouseDrag()
    // {
    //     Debug.Log("Mouse Drag");
    // }

    // void OnMouseOver()
    // {
    //     Debug.Log("Mouse Over");
    // }

    // void OnMouseUpAsButton()
    // {
    //     Debug.Log("Mouse Up As Button");
    // }

 
}

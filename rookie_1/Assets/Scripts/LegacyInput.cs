using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegacyInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log($"KeyDown(A)[{Time.frameCount}]");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log($"KeyUp(A)[{Time.frameCount}]");
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log($"Key(A)[{Time.frameCount}]");
        }
        Input.GetMouseButtonDown(1);
        Vector2 mousePositionDelta = Input.mousePosition;
        Vector2 mouseScrollDelta = Input.mouseScrollDelta;
    }
}

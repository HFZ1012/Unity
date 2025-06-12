using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance; // Singleton instance of the MouseWorld class;

    [SerializeField] private LayerMask mousePlaneLayerMask;

    private void Awake() // Awake is called when the script instance is being loaded;
    {
        instance = this; // Set the singleton instance to this instance;
    }

    public static Vector3 GetPosition() // Get the position of the mouse in world space;
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Get the ray from the camera to the mouse position;
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue,instance.mousePlaneLayerMask); // Get the raycast hit information;
        return raycastHit.point; // Return the raycast hit position;
    }
}

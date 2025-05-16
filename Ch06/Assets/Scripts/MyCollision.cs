using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    // void OnCollisionStay(Collision collision)
    // {
    //     Debug.Log("OnCollisionStay:"+collision.gameObject.name);
    // }

    // void OnCollisionExit(Collision collision)
    // {
    //     Debug.Log("OnCollisionExit:"+collision.gameObject.name);
    // }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter,{other.gameObject.name}");
    }
}

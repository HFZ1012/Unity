using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed = 1;
    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontal, 0, vertical);
        if(direction.magnitude >=1)
        {
            direction.Normalize();
        }
        transform.localPosition += direction * speed * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        anim.SetBool("Anim2", false);
    }
    
    void OnDisable()
    {
        anim.SetBool("Anim2", true);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoThings()
    {
        Debug.Log("DoThings");
    }
    public void InputArg(string arg)
    {
        Debug.Log("InputArg: " + arg);
    }
}

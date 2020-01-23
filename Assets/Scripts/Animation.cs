using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _anim.SetBool("TurnLeft", true);
            _anim.SetBool("TurnRight", false);
            _anim.SetBool("TurnFront", false);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            _anim.SetBool("TurnLeft", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _anim.SetBool("TurnLeft", false);
            _anim.SetBool("TurnRight", true);
            _anim.SetBool("TurnFront", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _anim.SetBool("TurnRight", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _anim.SetBool("TurnLeft", false);
            _anim.SetBool("TurnRight", false);
            _anim.SetBool("TurnFront", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _anim.SetBool("TurnFront", false);
        }
    }
}

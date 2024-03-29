using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnim : MonoBehaviour
{
    void Start()
    {
        
    }
void animActive()
    {
        GetComponent<Animator>().SetBool("Jump",false);
    }
}

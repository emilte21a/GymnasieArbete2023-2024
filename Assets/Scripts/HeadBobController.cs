using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    public Animator camAnim;

    private void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            camAnim.SetTrigger("walk");
        }
        else
        {
            camAnim.SetTrigger("idle");
        }
    }
}

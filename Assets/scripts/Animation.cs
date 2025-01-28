using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator animator;
    private bool IsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
        }
    }
     void Update()
    {
        if (IsGrounded)
        {
            animator.SetBool("IsJump", true);
        }
        else
        {
            animator.SetBool("IsJump", false);
        }
    }
}

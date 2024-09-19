using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    private bool isOnGrounded;
    private bool isOnBoder;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground") )
        {
            isOnGrounded = true;
        }
        else if(!other.gameObject.CompareTag("boder")&& !other.gameObject.CompareTag("ranger"))
        {
            isOnGrounded = false;
        }

        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isOnGrounded = false;
        }

    }
    public bool IsGrounded()
    {
        return isOnGrounded;
    }
    public bool IsBoder()
    {
        return isOnBoder;
    }
}

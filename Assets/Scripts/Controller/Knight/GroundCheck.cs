using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGrounded;
    private KnightActions knightActions;

    // Kiểm tra khi bắt đầu va chạm
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("map"))
        {
            Debug.Log("huhuh2");
            Debug.Log("huhuh");
            knightActions = GetComponentInChildren<KnightActions>();
            knightActions.TakeDamage(200f);
        }
    }

    // Kiểm tra khi vẫn đang va chạm
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    // Kiểm tra khi kết thúc va chạm
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}

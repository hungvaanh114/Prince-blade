using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Animator animator;
    public float dame;
    private KnightActions knightActions;
    void Start()
    {
        animator = GetComponent<Animator>();
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("knight"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            knightActions = collision.GetComponentInChildren<KnightActions>();
            animator.SetTrigger("burst");
            knightActions.TakeDamage(dame);
        }
        if (collision.CompareTag("ground"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            animator.SetTrigger("burst");
        }

    }
    public void onDestroy()
    {
        Destroy(gameObject);
    }
}

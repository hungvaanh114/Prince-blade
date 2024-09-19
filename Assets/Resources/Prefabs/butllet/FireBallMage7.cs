using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMage7 : MonoBehaviour
{
    [SerializeField] private float dame;
    private Rigidbody2D rb;
    private Animator animator;
    private KnightActions knightActions;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("knight"))
        {
            rb.velocity = Vector2.zero;
            knightActions = collision.GetComponentInChildren<KnightActions>();
            animator.SetTrigger("burst");
            knightActions.TakeDamage(dame);
        }
        if (collision.CompareTag("ground"))
        {
            rb.velocity = Vector2.zero;
            animator.SetTrigger("burst");
        }
    }
    public void onDestroy()
    {
        Destroy(gameObject);
    }

}

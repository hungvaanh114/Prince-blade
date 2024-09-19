using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMage3 : MonoBehaviour
{
    [SerializeField] private float shootSpeed = 10.0f;
    [SerializeField] private float dame;
    private Vector2 direction;
    private GameObject knight;
    private Rigidbody2D rb;
    private Animator animator;
    private KnightActions knightActions;

    void Start()
    {
        knight = GameObject.Find("Knight");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        if (knight != null)
        {
             direction = ((knight.transform.position - transform.position)).normalized;
            rb.velocity = direction * shootSpeed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle += 180f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            knight = null;
        }
        

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

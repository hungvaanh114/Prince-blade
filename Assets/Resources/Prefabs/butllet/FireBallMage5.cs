using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMage5 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    private KnightActions knightActions;
    [SerializeField] private float dame;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Destroy(gameObject, 10f);
    }
    void Update()
    {
        // Di chuyển từ trái sang phải bằng cách cập nhật vị trí
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
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

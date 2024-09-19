using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMage1 : MonoBehaviour
{
    [SerializeField] private float growSpeed = 1.0f;
    [SerializeField] private float minScale = 0.1f;
    [SerializeField] private float maxScale = 3.0f;
    [SerializeField] private float shootSpeed = 10.0f;
    [SerializeField] private float dame;
    private GameObject knight;
    private Rigidbody2D rb;
    private Animator animator;
    private KnightActions knightActions;
    private BossMage bossMage;
    private bool hasShot = false;
    void Start()
    {
        knight = GameObject.Find("Knight");
        transform.localScale = new Vector3( minScale,minScale,1);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bossMage = GetComponentInParent<BossMage>();
        Destroy(gameObject,10f);
    }

    void Update()
    {
        
        if (transform.localScale.x < maxScale)
        {
            bossMage.isMove = false;
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
        }
        else if (!hasShot) // Chỉ bắn một lần sau khi đạt kích thước tối đa
        {
            hasShot = true;
            if (knight != null)
            {
                bossMage.animator.SetTrigger("attack end");
                bossMage.isMove = true;
                float x = transform.localScale.x;
                // Tính toán hướng di chuyển từ vị trí hiện tại đến vị trí của knight
                transform.SetParent(null);
                Vector2 direction = ((knight.transform.position - transform.position)).normalized;
                rb.velocity = direction * shootSpeed;
                transform.localScale= new Vector3(x, transform.localScale.y,1);
            }
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
/*        if (collision.CompareTag("ground"))
        {
            rb.velocity = Vector2.zero;
            animator.SetTrigger("burst");
        }*/
    }
    public void onDestroy()
    {
        bossMage.animator.SetTrigger("attack end");
        bossMage.isMove = true;
        Destroy(gameObject);
    }

}

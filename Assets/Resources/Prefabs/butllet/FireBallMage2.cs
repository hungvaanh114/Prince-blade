using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMage2 : MonoBehaviour
{
    [SerializeField] private float shootSpeed = 10.0f;
    [SerializeField] private float dame;
    public float hoverAmplitude = 1.0f;
    private GameObject knight;
    private Rigidbody2D rb;
    private Animator animator;
    private KnightActions knightActions;
    public float hoverHeight;
    public float hoverSpeed = 2.0f;
    private float hoverTime;
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
            Hover();
            Vector2 direction = (knight.transform.position - transform.position).normalized;
            rb.velocity = direction * shootSpeed;
        }

    }
    void Hover()
    {
        hoverTime += hoverSpeed * Time.deltaTime;
        float newY = hoverHeight + Mathf.Sin(hoverTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        hoverTime += Time.deltaTime * hoverSpeed;

        // Tính toán giá trị dao động hình sin cho trục Y
        float sinOffset = Mathf.Sin(hoverTime) * hoverAmplitude;

        // Di chuyển lên xuống dựa trên giá trị sin
        transform.position = new Vector3(transform.position.x, transform.position.y + sinOffset, transform.position.z);

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
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMage4 : MonoBehaviour
{
    [SerializeField] private float growSpeed = 1.0f;
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float minScale = 0.01f;
    [SerializeField] private float maxScale = 5.0f;
    private KnightActions knightActions;
    [SerializeField] private float dame;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(minScale, minScale, 1);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < maxScale)
        {
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
        }
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("knight"))
        {
            knightActions = collision.GetComponentInChildren<KnightActions>();
            knightActions.TakeDamage(dame);
        }
    }
}

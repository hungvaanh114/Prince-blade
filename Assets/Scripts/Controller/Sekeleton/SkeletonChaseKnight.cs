using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonChaseKnight : MonoBehaviour
{
    private Transform knight;
    private bool isChasing = false;
    private SekeletonMove sekeletonMove;
    private void Start()
    {
        sekeletonMove = transform.parent.GetComponentInChildren<SekeletonMove>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("knight"))
        {
            isChasing = true;
            knight = other.GetComponent<Transform>();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("knight"))
        {
            isChasing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("knight"))
        {
            isChasing = false;
        }
    }
    private void Update()
    {
        if (isChasing && knight != null)
        {
            if (sekeletonMove.transform.position.x < knight.position.x)
            {
                sekeletonMove.movingRight = true;
                sekeletonMove.transform.localScale = new Vector3(1.4f, 1,1);
            }
            else if (transform.parent.position.x > knight.position.x)
            {
                sekeletonMove.movingRight = false;
                sekeletonMove.transform.localScale = new Vector3(-1.4f, 1, 1);
            }
        }
    }
}

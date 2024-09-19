using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecinctCheck2 : MonoBehaviour
{
    private SekeletonMove sekeletonMove;
    void Start()
    {
        sekeletonMove = gameObject.GetComponentInParent<SekeletonMove>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu Skeleton va chạm với vách 
        if (collision.gameObject.CompareTag("ground"))
        {
           sekeletonMove.isPrecinct = true;
        }
    }
}

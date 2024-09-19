using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecinctCheck1 : MonoBehaviour
{
    private SekeletonMove sekeletonMove;
    void Start()
    {
        sekeletonMove = gameObject.GetComponentInParent<SekeletonMove>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Đi vào khoảng không
        if (collision.gameObject.CompareTag("ground"))
        {
            sekeletonMove.isPrecinct = true;
        }
    }
}

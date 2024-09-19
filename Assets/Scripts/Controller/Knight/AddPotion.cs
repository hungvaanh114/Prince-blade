using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPotion : MonoBehaviour
{
     private KnightData knightData;
    private void Start()
    {
        knightData= Resources.Load<KnightData>("GameData/Knight/KnightData");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hp"))
        {
            knightData.PotionRed++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("mana"))
        {
            knightData.PotionBlue++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("gold"))
        {
            knightData.Gold++;
            Destroy(collision.gameObject);
        }
    }
}

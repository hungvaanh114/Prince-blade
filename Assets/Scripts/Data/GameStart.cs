using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public KnightData knightData;
    // Start is called before the first frame update
    void Start()
    {
        knightData.Health = 100f;
        knightData.Mana = 50f;
        knightData.AttackPower = 10f;
        knightData.Speed = 5f;
        knightData.AttackSpeed = 1f;
        knightData.JumpHeight = 2f;
        
     
       /* // Lưu trữ KnightData vào một tập tin asset
        string filePath = "Assets/Resources/GameData/Knight/KnightData.asset";
        UnityEditor.AssetDatabase.CreateAsset(knightData, filePath);
        UnityEditor.AssetDatabase.SaveAssets();*/
    }


}

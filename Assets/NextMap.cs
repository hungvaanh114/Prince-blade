using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMap : MonoBehaviour
{
    private Leaderboard leaderboard;
    private string savePath;

    private void Awake()
    {
        leaderboard = Resources.Load<Leaderboard>("GameData/Knight/top10");
        savePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        leaderboard.LoadFromJson(savePath);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("knight"))
        {
            leaderboard.SaveToJson(savePath);
            SceneManager.LoadScene(4);
        }
    }
}

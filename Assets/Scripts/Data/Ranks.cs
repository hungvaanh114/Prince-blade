using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Ranks : MonoBehaviour
{
    public Text text1;
    public Leaderboard leaderboard;
    int a = 1;
    private string savePath;
    // Start is called before the first frame update

    void Awake()
    {
        leaderboard = Resources.Load<Leaderboard>("GameData/Knight/top10");
        savePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        leaderboard.LoadFromJson(savePath);
        text1.text = "";
        foreach (PlayerScore playerScore in leaderboard.GetTopScores())
        {   
            text1.text +=  $"Rank {a}:{playerScore.playerName} |Score: {playerScore.score}\n";
            a++;
        }
        a = 1;
    }

}

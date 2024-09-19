using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameScoreManager : MonoBehaviour
{
    public Leaderboard leaderboard;
    public InputField namePL;
    public Text score;
    // Gọi hàm này khi người chơi đạt điểm
    public void AddScore()
    {
        int number = int.Parse(score.text);
        leaderboard.AddPlayerScore(namePL.text, number);
        foreach (PlayerScore playerScore in leaderboard.GetTopScores())
        {
            Debug.Log($"Name: {playerScore.playerName}, Score: {playerScore.score}");
        }
    }
}

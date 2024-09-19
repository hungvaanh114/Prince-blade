using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLeaderboard", menuName = "Leaderboard/Top10Scores")]
public class Leaderboard : ScriptableObject
{
    public List<PlayerScore> topScores = new List<PlayerScore>();
    private const int maxScores = 10;
    public void AddPlayerScore(string playerName, int score)
    {
        // Tạo đối tượng PlayerScore mới
        PlayerScore newScore = new PlayerScore { playerName = playerName, score = score };
        topScores.Add(newScore);
        topScores.Sort((a, b) => b.score.CompareTo(a.score));
        if (topScores.Count > maxScores)
        {
            topScores.RemoveAt(topScores.Count - 1);
        }
    }
    public List<PlayerScore> GetTopScores()
    {
        return new List<PlayerScore>(topScores);
    }
    public void SaveToJson(string filePath)
    {
        string json = JsonUtility.ToJson(this, true);
        File.WriteAllText(filePath, json);
    }

    public void LoadFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private Leaderboard leaderboard;
    private Key key;
    private string savePath;

    private void Awake()
    {
        leaderboard = Resources.Load<Leaderboard>("GameData/Knight/top10");
        key = Resources.Load<Key>("GameData/Keys");

        savePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        leaderboard.LoadFromJson(savePath);
        savePath = Path.Combine(Application.persistentDataPath, "key.json");
        key.LoadFromJson(savePath);
    }

    public void GoToNewsGameScene()
    {

        SceneManager.LoadScene(1);
    }
    public void GoToRanksScene()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToMenuScene()
    {
        leaderboard.SaveToJson(savePath);
        key.SaveToJson(savePath);
        SceneManager.LoadScene(0);
    }
    public void GoToSettingScene()
    {
        SceneManager.LoadScene(3);
    }
    public void ExitGame()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}

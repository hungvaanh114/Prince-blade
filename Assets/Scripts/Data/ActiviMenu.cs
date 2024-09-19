using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiviMenu : MonoBehaviour
{
    public GameObject image;
    public GameObject button1;
    public GameObject buttonOut;
    public PlayerScore playerScore;
    //private bool isPaused = false;
    // Start is called before the first frame update
    public void PauseGame1()
    {
        image.SetActive(true);
        button1.SetActive(true);
        buttonOut.SetActive(true);
        Time.timeScale = 0f; // Dừng thời gian
    }

    public void ResumeGame1()
    {
        image.SetActive(false);
        button1.SetActive(false);
        buttonOut.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void OutGame()
    {

    }
}

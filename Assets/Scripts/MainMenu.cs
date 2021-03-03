using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene;

    public GameObject CreditCanvas;
    

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
        scoreManager.currentScore = 0;
    } 

    public void OpenCredit()
    {
        CreditCanvas.SetActive(true);
    }

    public void CloseCredit()
    {
        CreditCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quitting game");
    }
}

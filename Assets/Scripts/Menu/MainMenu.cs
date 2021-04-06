using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string scene_01;
    public string scene_02;
    public string scene_03;

    public Canvas mainMenuCanvas;
    public Canvas levelSelectCanvas;
    public Canvas scoreBoardCanvas;
    public Canvas creditCanvas;

    public void OpenPlayMenu()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        levelSelectCanvas.gameObject.SetActive(true);
    }

    public void OpenScoreBoard()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        scoreBoardCanvas.gameObject.SetActive(true);
    }
    
    public void OpenCredit()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        creditCanvas.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quitting game");
    }
}

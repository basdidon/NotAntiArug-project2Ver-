using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static int currentScore = 0;
    public Text text;

    private void Start()
    {
        
    }

    private void Update()
    {
        text.text = currentScore.ToString();
    }
    public void addScore(int score)
    {
        currentScore += score;
        Debug.Log("score = " + currentScore);
    }

    public void reduceScore(int score)
    {
        currentScore -= score;
        if (currentScore < 0)
        {
            currentScore = 0;
        }
    }

}

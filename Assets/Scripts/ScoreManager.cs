using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text[] scoreText;
    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < scoreText.Length ; i++)
        {
            scoreText[i].text = "SCORE : " + score.ToString();
        }
    }

    public void AddScore()
    {
        score++;
        for (int i = 0; i < scoreText.Length; i++)
        {
            scoreText[i].text = "SCORE : " + score.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendScore : MonoBehaviour
{
    public TMPro.TextMeshProUGUI myScore;
    public TMPro.TextMeshProUGUI myName;
    public int currentScore;

    void Update()
    {
        myScore.text = $"SCORE: {PlayerPrefs.GetInt("highscore")}";
    }

    public void CheckScore()
    {
        if ((currentScore) < PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", currentScore);
            HighScores.UploadScore(myName.text, currentScore);
        }
    }
}

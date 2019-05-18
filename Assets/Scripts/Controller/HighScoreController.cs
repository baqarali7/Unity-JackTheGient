using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText, coinText;

    private void Start()
    {
        SetScoreOnDifficultyBase();
    }

    public void GoBackToMainManu()
    {
        SceneFaderScript.instance.LoadLevel("MainManu");
    }

    void setScore(int sco, int coinsco)
    {
        ScoreText.text = sco.ToString();
        coinText.text = coinsco.ToString();
    }

    void SetScoreOnDifficultyBase()
    {
        if(PlayerPreferences.GetEasyDifficulty() == 1)
        {
            setScore(PlayerPreferences.GetEastDifficultyHightScore(), PlayerPreferences.GetEasyDifficultyCoinScore());
        }

        if (PlayerPreferences.GetMediumDifficulty() == 1)
        {
            setScore(PlayerPreferences.GetMediumDifficultyHightScore(), PlayerPreferences.GetMediumDifficultyCoinScore());
        }
        if (PlayerPreferences.GetHardDifficulty() == 1)
        {
            setScore(PlayerPreferences.GetHardDifficultyHightScore(), PlayerPreferences.GetHardDifficultyCoinScore());
        }
    }
}

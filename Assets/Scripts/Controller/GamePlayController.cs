using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
   

    public static GamePlayController instance;

    [SerializeField]
    private Text ScoreText, LifeText, CoinText, GameOverScoreText, GameOverCoinText;

    [SerializeField]
    private GameObject PausePanel, GameOverPanel;

    [SerializeField]
    private GameObject ReadyButton;


    private void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
       
        Time.timeScale = 0f;
       
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameOverShowPanel(int FinalScore, int FinalCoinScore)
    {
        GameOverPanel.SetActive(true);
        GameOverScoreText.text = FinalScore.ToString();
        GameOverCoinText.text = FinalCoinScore.ToString();

        StartCoroutine(GameOverLoadMainManu());
    }

    
    IEnumerator GameOverLoadMainManu()
    {
        yield return new WaitForSeconds(3);
        SceneFaderScript.instance.LoadLevel("MainManu");
        
        
    }

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }

    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1);
        SceneFaderScript.instance.LoadLevel("JackAndTheGiant");
    }

    public void setScore(int score)
    {
        ScoreText.text = "x" + score;
    }

    public void setCoinScore(int coinscore)
    {
        CoinText.text = "x" + coinscore;

    }
    public void setLifeScore(int lifescore)
    {
        LifeText.text = "x" + lifescore;
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneFaderScript.instance.LoadLevel("MainManu");
        

    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        ReadyButton.SetActive(false);
    }
    
}

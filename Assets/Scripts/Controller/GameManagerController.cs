using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController instance;


    [HideInInspector]
    public bool gameStartedFromMainManu, gameStartedWhenPlayerDied;

    [HideInInspector]
    public int Score, CoinScore, LifeScore;



    void Awake()
    {

        MakeSingleton();
    }

    private void Start()
    {
        OnInitilizeVariables();
    }
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
        SceneManager.sceneLoaded += MainManuLoaded;
        SceneManager.sceneLoaded += OptionsManuLoaded;
        SceneManager.sceneLoaded += HighManuLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
        SceneManager.sceneLoaded -= MainManuLoaded;
        SceneManager.sceneLoaded -= OptionsManuLoaded;
        SceneManager.sceneLoaded -= HighManuLoaded;
    }


    void MainManuLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainManu")
        {
            Debug.Log("MainManu");
          
        }
    }

    void OptionsManuLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "OptionsManu")
        {
            
        }
    }
    void HighManuLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "HighScoreManu")
        {
            
        }
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "JackAndTheGiant")
        {
            if (gameStartedWhenPlayerDied)
            {

                GamePlayController.instance.setScore(Score);
                GamePlayController.instance.setCoinScore(CoinScore);
                GamePlayController.instance.setLifeScore(LifeScore);

                PlayerScore.scoreCount = Score;
                PlayerScore.coinCount = CoinScore;
                PlayerScore.lifeCount = LifeScore;



            }
            else if (gameStartedFromMainManu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;



                GamePlayController.instance.setScore(0);
                GamePlayController.instance.setCoinScore(0);
                GamePlayController.instance.setLifeScore(2);

            }

            
        }
    }


    public void CheckGameStatus(int score, int coinscore, int lifescore)
    {
        if (lifescore < 0)
        {
            if (PlayerPreferences.GetEasyDifficulty() == 1)
            {
                int highScore = PlayerPreferences.GetEastDifficultyHightScore();
                int coinHighScore = PlayerPreferences.GetEasyDifficultyCoinScore();

                if (highScore < score)
                {
                    PlayerPreferences.SetEastDifficultyHightScore(score);
                }
                if (coinHighScore < coinscore)
                {
                    PlayerPreferences.SetEasyDifficultyCoinScore(coinscore);
                }
            }
            if (PlayerPreferences.GetMediumDifficulty() == 1)
            {
                int MediumHighScore = PlayerPreferences.GetMediumDifficultyHightScore();
                int MediumcoinHighScore = PlayerPreferences.GetMediumDifficultyCoinScore();

                if (MediumHighScore < score)
                {
                    PlayerPreferences.SetMediumDifficultyHightScore(score);
                }
                if (MediumcoinHighScore < coinscore)
                {
                    PlayerPreferences.SetMediumDifficultyCoinScore(coinscore);
                }
            }
            if (PlayerPreferences.GetHardDifficulty() == 1)
            {
                int HardHighScore = PlayerPreferences.GetHardDifficultyHightScore();
                int HardcoinHighScore = PlayerPreferences.GetHardDifficultyCoinScore();

                if (HardHighScore < score)
                {
                    PlayerPreferences.SetHardDifficultyHightScore(score);
                }
                if (HardcoinHighScore < coinscore)
                {
                    PlayerPreferences.SetHardDifficultyCoinScore(coinscore);
                }
            }



            gameStartedFromMainManu = false;
            gameStartedWhenPlayerDied = false;

            GamePlayController.instance.GameOverShowPanel(score, coinscore);
        }

        else
        {
            this.Score = score;
            this.CoinScore = coinscore;
            this.LifeScore = lifescore;

            gameStartedFromMainManu = false;
            gameStartedWhenPlayerDied = true;

            GamePlayController.instance.PlayerDiedRestartTheGame();
        }
    }


    private void OnInitilizeVariables()
    {
        if (!PlayerPrefs.HasKey("Game Initilize"))
        {
            PlayerPreferences.SetEasyDifficulty(0);
            PlayerPreferences.SetEastDifficultyHightScore(0);
            PlayerPreferences.SetEasyDifficultyCoinScore(0);

            PlayerPreferences.SetMediumDifficulty(1);
            PlayerPreferences.SetMediumDifficultyHightScore(0);
            PlayerPreferences.SetMediumDifficultyCoinScore(0);


            PlayerPreferences.SetHardDifficulty(0);
            PlayerPreferences.SetHardDifficultyHightScore(0);
            PlayerPreferences.SetHardDifficultyCoinScore(0);

            PlayerPreferences.SetIsMusicOn(0);

            PlayerPrefs.SetInt("Game Initilize", 123);
        }
    }
}

      




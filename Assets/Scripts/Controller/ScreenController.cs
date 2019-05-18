using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    [SerializeField]
    private Button musicbtn;

    [SerializeField]
    private Sprite[] musicIcons;

    private void Start()
    {
        checkToPlayTheMusic();
    }

    void checkToPlayTheMusic()
    {
        if(PlayerPreferences.GetIsMusicOn() == 1)
        {
            MusicController.instance.MusicPlay(true);

            musicbtn.image.sprite = musicIcons[1];

        }

        else
        {
            MusicController.instance.MusicPlay(false);

            musicbtn.image.sprite = musicIcons[0];
        }
    }

    public void PlayGame()
    {
        GameManagerController.instance.gameStartedFromMainManu = true;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneFaderScript.instance.LoadLevel("JackAndTheGiant");
        
    }
    public void Options()
    {
        SceneFaderScript.instance.LoadLevel("OptionsManu");
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void HighScore()
    {
        SceneFaderScript.instance.LoadLevel("HighScoreManu");
       
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void musicButton()
    {
        if(PlayerPreferences.GetIsMusicOn() == 0)
        {
            PlayerPreferences.SetIsMusicOn(1);
            MusicController.instance.MusicPlay(true);
            musicbtn.image.sprite = musicIcons[1];
        }
        else if(PlayerPreferences.GetIsMusicOn() == 1)
        {
            PlayerPreferences.SetIsMusicOn(0);
            MusicController.instance.MusicPlay(false);
            musicbtn.image.sprite = musicIcons[0];
        }
    }
}

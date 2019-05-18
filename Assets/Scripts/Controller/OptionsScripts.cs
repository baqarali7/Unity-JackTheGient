using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsScripts : MonoBehaviour
{
    [SerializeField]
    private GameObject Easy, Medium, Hard;

    private void Start()
    {
        SetTheDifficulty();
    }

    public void GoBackToMainManu()
    {
        SceneFaderScript.instance.LoadLevel("MainManu");
    }

    void SetInitialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":

                Medium.SetActive(false);
                Hard.SetActive(false);

                break;

            case "medium":

                Easy.SetActive(false);
                Hard.SetActive(false);

                break;

            case "hard":

                Easy.SetActive(false);
                Medium.SetActive(false);

                break;
        }
    }

    void SetTheDifficulty()
    {
        if(PlayerPreferences.GetEasyDifficulty() == 1)
        {
            SetInitialDifficulty("easy");
        }

        if (PlayerPreferences.GetMediumDifficulty() == 1)
        {
            SetInitialDifficulty("medium");
        }

        if (PlayerPreferences.GetHardDifficulty() == 1)
        {
            SetInitialDifficulty("hard");
        }
    }

    public void EasyDifficulty()
    {
        PlayerPreferences.SetEasyDifficulty(1);
        PlayerPreferences.SetMediumDifficulty(0);
        PlayerPreferences.SetHardDifficulty(0);

        Easy.SetActive(true);
        Medium.SetActive(false);
        Hard.SetActive(false);
    }

    public void MediumDifficulty()
    {
        PlayerPreferences.SetEasyDifficulty(0);
        PlayerPreferences.SetMediumDifficulty(1);
        PlayerPreferences.SetHardDifficulty(0);

        Easy.SetActive(false);
        Medium.SetActive(true);
        Hard.SetActive(false);
    }

    public void HardDifficulty()
    {
        PlayerPreferences.SetEasyDifficulty(0);
        PlayerPreferences.SetMediumDifficulty(0);
        PlayerPreferences.SetHardDifficulty(1);

        Easy.SetActive(false);
        Medium.SetActive(false);
        Hard.SetActive(true);
    }
}

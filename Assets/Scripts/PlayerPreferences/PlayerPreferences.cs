using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class  PlayerPreferences 
{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";

    //Note We are going to use integers to represent boolean variables
    // 0 - false
    // 1 - true

    public static void SetEasyDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(PlayerPreferences.EasyDifficulty, difficulty);
    }

    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.EasyDifficulty);
    }

    public static void SetMediumDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(PlayerPreferences.MediumDifficulty, difficulty);
    }

    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.MediumDifficulty);
    }

    public static void SetHardDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(PlayerPreferences.HardDifficulty, difficulty);
    }

    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.HardDifficulty);
    }

    public static void SetEastDifficultyHightScore(int socre)
    {
        PlayerPrefs.SetInt(PlayerPreferences.EasyDifficultyHighScore, socre);
    }

    public static int GetEastDifficultyHightScore()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.EasyDifficultyHighScore);
    }

    public static void SetMediumDifficultyHightScore(int socre)
    {
        PlayerPrefs.SetInt(PlayerPreferences.MediumDifficultyHighScore, socre);
    }

    public static int GetMediumDifficultyHightScore()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.MediumDifficultyHighScore);
    }

    public static void SetHardDifficultyHightScore(int socre)
    {
        PlayerPrefs.SetInt(PlayerPreferences.HardDifficultyHighScore, socre);
    }

    public static int GetHardDifficultyHightScore()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.HardDifficultyHighScore);
    }

    public static void SetEasyDifficultyCoinScore(int coinsocre)
    {
        PlayerPrefs.SetInt(PlayerPreferences.EasyDifficultyCoinScore, coinsocre);
    }

    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.EasyDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int coinsocre)
    {
        PlayerPrefs.SetInt(PlayerPreferences.MediumDifficultyCoinScore, coinsocre);
    }

    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.MediumDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScore(int coinsocre)
    {
        PlayerPrefs.SetInt(PlayerPreferences.HardDifficultyCoinScore, coinsocre);
    }

    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.HardDifficultyCoinScore);
    }

    public static void SetIsMusicOn(int state)
    {
        PlayerPrefs.SetInt(PlayerPreferences.IsMusicOn, state);
    }

    public static int GetIsMusicOn()
    {
      return  PlayerPrefs.GetInt(PlayerPreferences.IsMusicOn);
    }
}

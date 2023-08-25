using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static int Score { get; private set; }

    public static void AddScore(int _points)
    {
        Score += _points;
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("Score", Score);
    }

    public static void LoadData()
    {
        Score = PlayerPrefs.GetInt("Score",0);
    }
}

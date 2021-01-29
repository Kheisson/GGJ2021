using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavePref
{
    const string ScoreKey = "Score";

    public static void SavePrefs()
    {
        PlayerPrefs.SetInt(ScoreKey, GameManager.Instance.HighScore);
        PlayerPrefs.Save();
        Debug.Log("Saved score");
    }

    public static void LoadPrefs()
    {
        var score = PlayerPrefs.GetInt(ScoreKey, 0);
        GameManager.Instance.HighScore = score;
    }
}


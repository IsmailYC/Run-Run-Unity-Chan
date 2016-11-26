using UnityEngine;
using System.Collections;

public static class PlayerPrefManager{

    public static void SetIsPoseBought(int pose, bool c)
    {
        if (c)
            PlayerPrefs.SetInt("Pose " + pose.ToString(), 1);
        else
            PlayerPrefs.SetInt("Pose " + pose.ToString(), 0);
    }

    public static void SetIsBackgroundBought(int background, bool c)
    {
        if (c)
            PlayerPrefs.SetInt("Background " + background.ToString(), 1);
        else
            PlayerPrefs.SetInt("Background " + background.ToString(), 0);
    }

    public static void SetScoreAmp(int scoreAmp)
    {
        PlayerPrefs.SetInt("Score Amp", scoreAmp);
    }

    public static void SetCoins(int coins)
    {
        PlayerPrefs.SetInt("Coins", coins);
    }

    public static void SetHighScore(int highscore)
    {
        if (highscore > GetHighScore())
            PlayerPrefs.SetInt("HighScore", highscore);
    }

    public static void SetPose(int pose)
    {
        PlayerPrefs.SetInt("Pose", pose);
    }

    public static void SetBackground(int background)
    {
        PlayerPrefs.SetInt("Background", background);
    }

    public static void SetCameraPosition(Vector3 cameraPosition)
    {
        PlayerPrefs.SetFloat("Camera Position X", cameraPosition.x);
        PlayerPrefs.SetFloat("Camera Position Y", cameraPosition.y);
    }

    public static bool IsPoseBought(int pose)
    {
        if (PlayerPrefs.HasKey("Pose " + pose.ToString()))
        {
            if (PlayerPrefs.GetInt("Pose " + pose.ToString()) == 1)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    public static bool IsBackgroundBought(int pose)
    {
        if (PlayerPrefs.HasKey("Background " + pose.ToString()))
        {
            if (PlayerPrefs.GetInt("Background " + pose.ToString()) == 1)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    public static int GetCoins()
    {
        if (PlayerPrefs.HasKey("Coins"))
            return PlayerPrefs.GetInt("Coins");
        else
            return 0;
    }

    public static int GetHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
            return PlayerPrefs.GetInt("HighScore");
        else
            return 0;
    }

    public static int GetPose()
    {
        if (PlayerPrefs.HasKey("Pose"))
            return PlayerPrefs.GetInt("Pose");
        else
            return 1;
    }

    public static int GetBackground()
    {
        if (PlayerPrefs.HasKey("Background"))
            return PlayerPrefs.GetInt("Background");
        else
            return 0;
    }

    public static Vector3 GetCameraPosition()
    {
        if (PlayerPrefs.HasKey("Camera Position X"))
        {
            return new Vector3(PlayerPrefs.GetFloat("Camera Position X"),
                PlayerPrefs.GetFloat("Camera Position Y"), 1);
        }
        else
            return Vector3.forward;
    }

    public static int GetScoreAmp()
    {
        if (PlayerPrefs.HasKey("Score Amp"))
            return PlayerPrefs.GetInt("Score Amp");
        else
            return 1;
    }
}

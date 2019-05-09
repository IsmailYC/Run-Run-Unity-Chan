using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour {
    public Button[] poseButtons;
    public Button[] backgroundButtons;
    public Text coinDisplay;
    public Text scoreAmpDisplay;

    int coins, scoreAmp;

    void OnEnable()
    {
        coins = PlayerPrefManager.GetCoins();
        coinDisplay.text = coins.ToString();
        scoreAmp = PlayerPrefManager.GetScoreAmp();
        scoreAmpDisplay.text = "X"+scoreAmp.ToString();
        for (int i = 0; i < poseButtons.Length; i++)
        {
            poseButtons[i].interactable = !PlayerPrefManager.IsPoseBought(i);
        }
        for (int i = 0; i < backgroundButtons.Length; i++)
        {
            backgroundButtons[i].interactable = !PlayerPrefManager.IsBackgroundBought(i);
        }
    }

    void OnDisable()
    {
        PlayerPrefManager.SetCoins(coins);
        PlayerPrefManager.SetScoreAmp(scoreAmp);
    }

    public void BuyPose(int pose)
    {
        if(coins>=500)
        {
            coins -= 500;
            coinDisplay.text = coins.ToString();
            PlayerPrefManager.SetIsPoseBought(pose,true);
            poseButtons[pose].interactable = false;
        }
    }

    public void BuyBackground(int background)
    {
        if (coins >= 300)
        {
            coins -= 300;
            coinDisplay.text = coins.ToString();
            PlayerPrefManager.SetIsBackgroundBought(background, true);
            backgroundButtons[background].interactable = false;
        }
    }

    public void UpgradeScoreAmp()
    {
        if(coins>=100 && scoreAmp<50)
        {
            coins -= 100;
            coinDisplay.text = coins.ToString();
            scoreAmp++;
            scoreAmpDisplay.text = "X"+scoreAmp.ToString();
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadBackgrounds : MonoBehaviour {
    public Button[] backgroundButtons;

    void OnEnable()
    {
        for (int i = 0; i < backgroundButtons.Length; i++)
        {
            backgroundButtons[i].interactable = PlayerPrefManager.IsBackgroundBought(i);
        }
    }
}

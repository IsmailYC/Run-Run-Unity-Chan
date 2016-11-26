using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadPoses : MonoBehaviour {
    public Button[] poseButtons;

    void OnEnable()
    {
        for(int i=0; i<poseButtons.Length; i++)
        {
            poseButtons[i].interactable = PlayerPrefManager.IsPoseBought(i);     
        }
    }
}

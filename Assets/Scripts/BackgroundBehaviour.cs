using UnityEngine;
using System.Collections;

public class BackgroundBehaviour : MonoBehaviour
{
    public Sprite[] bgs;

    SpriteRenderer bg;
    int background;
    void Awake()
    {
        bg = GetComponent<SpriteRenderer>();
        ChangeBackground(PlayerPrefManager.GetBackground());
    }

    public void ChangeBackground(int i)
    {
        background = i;
        bg.sprite = bgs[i];
    }

    void OnDisable()
    {
        PlayerPrefManager.SetBackground(background);
    }
}

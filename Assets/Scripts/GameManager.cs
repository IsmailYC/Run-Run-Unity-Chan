using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public bool isAlive;

    void Awake()
    {
        if (instance == null)
            instance = this;
        isAlive = true;
    }

    public void Die()
    {
        isAlive = false;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}

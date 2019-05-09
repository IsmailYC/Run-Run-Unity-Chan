using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public string scene;
    
    public void Load()
    {
        SceneManager.LoadScene(scene);
    }
}

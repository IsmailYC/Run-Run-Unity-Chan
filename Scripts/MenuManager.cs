using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public static MenuManager instance;
    public enum State { Menu, Pose, Background, Store, Position};

    public GameObject menuCanvas;
    public GameObject poseView;
    public GameObject backgroundView;
    public GameObject storeCanvas;
    public State state = State.Menu;

	// Use this for initialization
	void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        switch(state)
        {
            case State.Menu:
                if (Input.GetButtonDown("Cancel"))
                    CloseGame();
                break;
            case State.Pose:
                if (Input.GetButtonDown("Cancel"))
                    ClosePosing();
                break;
            case State.Background:
                if (Input.GetButtonDown("Cancel"))
                    CloseBackground();
                break;
            case State.Store:
                if (Input.GetButtonDown("Cancel"))
                    CloseStore();
                break;
            case State.Position:
                if (Input.GetButtonDown("Cancel"))
                    ClosePositioning();
                break;
        }
    }

    public void StartPosing()
    {
        if (state == State.Menu)
        {
            state = State.Pose;
            poseView.SetActive(true);
        }
    }

    public void ClosePosing()
    {
        state = State.Menu;
        poseView.SetActive(false);
    }

    public void StartBackground()
    {
        if(state==State.Menu)
        {
            state = State.Background;
            backgroundView.SetActive(true);
        }
    }

    public void CloseBackground()
    {
        state = State.Menu;
        backgroundView.SetActive(false);
    }

    public void StartPositioning()
    {
        if(state==State.Menu)
        {
            state = State.Position;
            menuCanvas.SetActive(false);
        }
    }

    public void ClosePositioning()
    {
        state = State.Menu;
        menuCanvas.SetActive(true);
    }

    public void OpenStore()
    {
        if(state==State.Menu)
        {
            state = State.Store;
            menuCanvas.SetActive(false);
            storeCanvas.SetActive(true);
        }
    }

    public void CloseStore()
    {
        state = State.Menu;
        storeCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void StartRunning()
    {
        SceneManager.LoadScene(1);
    }

    void CloseGame()
    {
        Application.Quit();
    }
}

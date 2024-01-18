using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI, pauseUI;
    [SerializeField] TMP_Text scoreUI, livesUI;
    [SerializeField] Slider healthUI;

    [SerializeField] FloatVariable health;
    //[Header("Events")]
    //[SerializeField] IntEvent scoreEvent;

    public enum State
    {
        TITLE,
        SETTINGS,
        NEW_GAME,
        PLAY,
        OVER
    }

    public State state = State.TITLE;
    //public float timer = 0;
    // Format to 2 decimal places -> string.Format("{0:F1", floatVariable);
    public int lives = 0, deaths = 0;

    public int Lives 
    { 
        get { return lives; } 
        set { lives = value; livesUI.text = "Lives: " + lives; } 
    }

    public bool pause = false;

    void Start()
    {
        //scoreEvent.onEventRaised += OnAddPoints;
    }

    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.SETTINGS:
                titleUI.SetActive(false);
                break;
            case State.NEW_GAME:
                titleUI.SetActive(false);
                Lives = 3;
                health.value = 100;
                state = State.PLAY;
                break;
            case State.PLAY:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case State.OVER:
                break;
        }

        healthUI.value = health.value / 100.0f;
    }

    public void OnTitle()
    {
        state = State.PLAY;
    }

    public void OnStartGame()
    {
        state = State.NEW_GAME;
    }

    public void OnSettings()
    {
        state = State.SETTINGS;
    }

    public void OnPause()
    {

    }

    public void OnOver()
    {
        state = State.OVER;
    }

    public void OnAddPoints(int points)
    {
        print(points);
    }
}


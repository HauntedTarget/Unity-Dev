using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text startButtonText;

    //[Header("Events")]
    //[SerializeField] IntEvent scoreEvent;

    public enum State
    {
        TITLE,
        PAUSE,
        PLAY,
        OVER
    }

    public State state = State.TITLE;
    //public float timer = 0;
    // Format to 2 decimal places -> string.Format("{0:F1", floatVariable);
    public int lives = 3;
    public int score = 0;

    public bool pause = true;

    void Start()
    {

    }

    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                titleUI.SetActive(true);
                pause = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.PLAY:
                titleUI.SetActive(false);
                pause = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case State.OVER:
                break;
        }

        livesUI.text = "Lives: " + lives.ToString();
    }

    public void OnStartGame()
    {
        startButtonText.text = "Continue";
        state = State.PLAY;
    }

    public void OnPause()
    {
        startButtonText.text = "Continue";
        state = State.TITLE;
    }

    public void OnOver()
    {
        state = State.OVER;
    }

    public void OnQuit()
    {
        Debug.Log("QuittingApplication");
        Application.Quit();
    }
}


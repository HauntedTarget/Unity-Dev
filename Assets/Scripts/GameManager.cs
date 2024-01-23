using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI, scoreUI;
    [SerializeField] TMP_Text startButtonText;

    //[Header("Events")]
    //[SerializeField] IntEvent scoreEvent;

    public enum State
    {
        TITLE,
        PAUSE,
        PLAY,
        OVER,
        WIN
    }

    public State state = State.TITLE;
    //public float timer = 0;
    // Format to 2 decimal places -> string.Format("{0:F1", floatVariable);
    public int lives = 3;
    public int score = 0;

    public bool pause = true;

    void Start()
    {
        GameObject.Find("GameSong").GetComponent<AudioSource>().Pause();
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
                GameObject.Find("GameSong").GetComponent<AudioSource>().Pause();
                break;
            case State.PLAY:
                titleUI.SetActive(false);
                pause = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if (!GameObject.Find("GameSong").GetComponent<AudioSource>().isPlaying) GameObject.Find("GameSong").GetComponent<AudioSource>().Play();

                if (lives <= 0) state = State.OVER;

                if (GameObject.FindGameObjectsWithTag("Gem").Length <= 0) state = State.WIN;

                break;
            case State.OVER:
                Debug.Log("LOSE");
                GameObject.Find("GameSong").GetComponent<AudioSource>().Pause();
                SceneManager.LoadScene("Lose");
                break;
            case State.WIN:
                Debug.Log("Win");
                GameObject.Find("GameSong").GetComponent<AudioSource>().Pause();
                SceneManager.LoadScene("Win");
                break;
        }

        livesUI.text = "Lives: " + lives.ToString();
        scoreUI.text = "Score: " + score.ToString();
    }

    private void OnLevelWasLoaded(int level)
    {
        score = 0;
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


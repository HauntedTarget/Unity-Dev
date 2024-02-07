using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI, ballInfoUI, shipInfoUI;
    [SerializeField] TMP_Text livesUI, scoreUI, playerLifeUI, enemyLifeUI;
    [SerializeField] TMP_Text startButtonText;

    //[Header("Events")]
    //[SerializeField] IntEvent scoreEvent;

    public enum State
    {
        TITLE,
        PAUSE,
        SPACE,
        PLAY,
        OVER,
        WIN
    }

    public State state = State.TITLE, gamePlayed = State.PLAY;
    //public float timer = 0;
    // Format to 2 decimal places -> string.Format("{0:F1", floatVariable);
    public int lives = 3;
    public int score = 0;
    public bool pause;

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
                ballInfoUI.SetActive(true);
                shipInfoUI.SetActive(false);
                pause = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                GameObject.Find("GameSong").GetComponent<AudioSource>().Pause();

                try
                {
                    GameObject.Find("playerShipObject").GetComponent<Inventory>().OnStopUse();
                }
                catch
                {
                    Debug.LogWarning("Scene is not the ship game! Are you on the ship game?");
                }

                break;
            case State.PLAY:
                titleUI.SetActive(false);
                pause = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if (!GameObject.Find("GameSong").GetComponent<AudioSource>().isPlaying)
                {
                    GameObject.Find("GameSong").GetComponent<AudioSource>().pitch = 1;
                    GameObject.Find("GameSong").GetComponent<AudioSource>().Play();
                }

                if (lives <= 0) OnOver();

                if (GameObject.FindGameObjectsWithTag("Gem").Length <= 0) OnWin();

                break;
            case State.SPACE:
                titleUI.SetActive(false);
                ballInfoUI.SetActive(false);
                shipInfoUI.SetActive(true);
                pause = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if (!GameObject.Find("GameSong").GetComponent<AudioSource>().isPlaying)
                {
                    GameObject.Find("GameSong").GetComponent<AudioSource>().pitch = -0.7f;
                    GameObject.Find("GameSong").GetComponent<AudioSource>().Play();
                }


                break;
            case State.OVER:
                Debug.Log("LOSE");
                GameObject.Find("GameSong").GetComponent<AudioSource>().Pause();
                break;
            case State.WIN:
                Debug.Log("Win");
                GameObject.Find("GameSong").GetComponent<AudioSource>().Pause();
                break;
        }

        livesUI.text = "Lives: " + lives.ToString();
        scoreUI.text = "Score: " + score.ToString();
        try
        {
            playerLifeUI.text = "Ship Health: " + GameObject.Find("playerShipObject").GetComponent<KinematicController>().health.ToString();
            enemyLifeUI.text = "Boss Health: " + GameObject.Find("Sun").GetComponent<enemyHitable>().enemyHealth.ToString();
        }
        catch (Exception)
        {
            Debug.LogWarning("Scene is not the ship game! Are you on the ship game?");
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        score = 0;
    }

    public void OnStartGame()
    {
        startButtonText.text = "Continue";
        state = gamePlayed;
    }

    public void OnSpace()
    {
        if (gamePlayed != State.SPACE) SceneManager.LoadScene("SpaceGameThing");
        startButtonText.text = "Continue";
        gamePlayed = State.SPACE;
        state = State.SPACE;
    }

    public void OnPause()
    {
        startButtonText.text = "Continue";
        state = State.TITLE;
    }

    public void OnOver()
    {
        SceneManager.LoadScene("Lose");
        state = State.OVER;
    }

    public void OnQuit()
    {
        Debug.Log("QuittingApplication");
        Application.Quit();
    }

    public void OnWin()
    {
        SceneManager.LoadScene("Win");
        state = State.WIN;
    }
}


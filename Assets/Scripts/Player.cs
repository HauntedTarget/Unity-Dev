using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text pickupOutput = null;

    public int Score { 
        get { return GameObject.Find("GameManager").GetComponent<GameManager>().score; }
        set
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().score = value;
            pickupOutput.text = "Score: " + GameObject.Find("GameManager").GetComponent<GameManager>().score.ToString();
        }
    }

    private void Start()
    {

    }

    public void AddPoints(int points)
    {
        Score += points;
    }

    public bool OnDeath()
    {

        GameObject.Find("GameManager").GetComponent<GameManager>().lives -= 1;
        return true;
    }
}

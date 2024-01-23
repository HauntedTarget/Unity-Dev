using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int Score { 
        get { return GameObject.Find("GameManager").GetComponent<GameManager>().score; }
        set
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().score = value;
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text pickupOutput = null;
    [SerializeField] FloatVariable health;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;

    private int score = 0;

    public int Score { 
        get { return score; }
        set { score = value; 
              pickupOutput.text = "Score: " + score.ToString(); 
              scoreEvent.RaiseEvent(score); } 
    }

    private void Start()
    {
        health.value = 5.5f;
    }

    public void AddPoints(int points)
    {
        Score += points;
    }

    public void Damage(float damage)
    {
        if (health.value > 0) health.value -= damage;
        if (health.value < 0) health.value = 0;
    }
}

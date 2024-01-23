using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftQuit : MonoBehaviour
{
    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().OnQuit();
        }
    }
}

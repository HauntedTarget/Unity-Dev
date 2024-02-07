using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameWin : MonoBehaviour
{
    
    public void OnCall()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().OnWin();
    }

}

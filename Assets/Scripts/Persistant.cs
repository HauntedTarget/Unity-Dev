using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistant : MonoBehaviour
{
    void Awake()
    {
        try
        {
            GameObject objs = GameObject.Find(gameObject.name);

            if (objs != null && objs != this.gameObject)
            {
                Destroy(this.gameObject);
            }
        }
        catch (Exception)
        {
            Debug.Log("NoCloneFound");
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

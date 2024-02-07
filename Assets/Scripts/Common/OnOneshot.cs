using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOneshot : MonoBehaviour
{
    [SerializeField] AudioClip oneshot = null;
    [SerializeField] AudioSource source = null;

    public void OnCall()
    {
        source.PlayOneShot(oneshot);
    }

}

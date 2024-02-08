using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMover : MonoBehaviour
{
    [SerializeField, Range(0,1)] float skySpeed; 

    // Update is called once per frame
    void Update()
    {
        // Help from: https://www.reddit.com/r/Unity3D/comments/pgd7kd/rotating_skybox_v2019315f1/
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skySpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(SplineFollower))]
public class SplineByName : MonoBehaviour
{
    [SerializeField] string splineName;

    void Start()
    {
        gameObject.GetComponent<SplineFollower>().splineContainer = GameObject.Find(splineName).GetComponent<SplineContainer>();
    }
}

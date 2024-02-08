using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SplineFollower))]
public class DestroyOnSplineFinish : MonoBehaviour
{
    private void Update()
    {
        if (GetComponent<SplineFollower>().distance >= GetComponent<SplineFollower>().splineContainer.CalculateLength()) Destroy(gameObject);
    }
}
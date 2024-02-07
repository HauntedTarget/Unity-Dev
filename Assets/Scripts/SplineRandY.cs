using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class SplineRandY : SplineFollower
{

    private float randY;

    void Start()
    {
        randY = UnityEngine.Random.Range(-3.0f, 3.0f);
    }

    void Update()
    {
        distance += movementRate * Time.deltaTime;

        UpdateTransform(math.frac(tDistance));
    }

    void UpdateTransform(float t)
    {
        Vector3 position = splineContainer.EvaluatePosition(t), 
            up = splineContainer.EvaluateUpVector(t), 
            foreward = Vector3.Normalize(splineContainer.EvaluateTangent(t)), 
            right = Vector3.Cross(up, foreward);

        transform.position = position + (up * randY);
        transform.rotation = quaternion.LookRotation(right, up);
    }
}

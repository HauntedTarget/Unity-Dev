using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class SplineFollower : MonoBehaviour
{
    [SerializeField] public SplineContainer splineContainer = null;
    [SerializeField] [Range(-50, 50)] public float movementRate = 1;

    [SerializeField] [Range(0, 1)] public float tDistance = 0; // distance along spline

    //Length in world coordnates
    public float length { get { return splineContainer.CalculateLength(); } }

    //World coordnate distance
    public float distance
    {
        get { return tDistance * length; }
        set { tDistance = value / length; }
    }

    void Start()
    {

    }

    void Update()
    {
        if (splineContainer != null)
        {
            distance += movementRate * Time.deltaTime;

            UpdateTransform(math.frac(tDistance));
        }
        else Debug.Log("No Spline On Object: " + gameObject.name);
    }

    void UpdateTransform(float t)
    {
        Vector3 position = splineContainer.EvaluatePosition(t), 
            up = splineContainer.EvaluateUpVector(t), 
            foreward = Vector3.Normalize(splineContainer.EvaluateTangent(t)), 
            right = Vector3.Cross(up, foreward);

        transform.position = position;
        transform.rotation = quaternion.LookRotation(right, up);
    }
}

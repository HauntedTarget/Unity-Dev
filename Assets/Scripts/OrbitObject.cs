using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitObject : MonoBehaviour
{
    [SerializeField] GameObject target = null;
    [SerializeField] [Range(1, 100)] float distance = 5, sensitivity = 0.2f;
    [SerializeField] [Range(20, 90)] float defaultPitch = 40;

    float yaw = 0, pitch = 0;

    private void Start()
    {
        pitch = defaultPitch;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch += Input.GetAxis("Mouse Y") * sensitivity;

        Quaternion qYaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qPitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion qRotation = qYaw * qPitch;

        transform.position = target.transform.position + (qRotation * Vector3.back * distance);
        transform.rotation = qRotation;
    }
}

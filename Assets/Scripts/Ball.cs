using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField][Range(1, 20)][Tooltip("Force of object movement")] private float force;

    public Rigidbody rb;

    private void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force, ForceMode.VelocityChange);
        }
    }
}

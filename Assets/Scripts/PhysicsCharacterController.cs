using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Camera view;
    [SerializeField] [Range(1, 10)] float maxForce, jumpForce;
    [Header("Collision")]
    [SerializeField] float rayLength = 1;
    [SerializeField] LayerMask groundLayer;

    Rigidbody rb;
    Vector3 force = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().pause)
        {
            Vector3 direction = Vector3.zero;

            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");

            Quaternion yRotation = Quaternion.AngleAxis(view.transform.rotation.eulerAngles.y, Vector3.up);
            force = yRotation * direction * maxForce;

            Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.blue);
            if (Input.GetButtonDown("Jump") && CheckGround())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            if (Input.GetButtonDown("Cancel"))
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().OnPause();
            }
        }
        else
        {
            if (Input.GetButtonDown("Cancel"))
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().OnStartGame();
            }
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Force);
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayer);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerA : MonoBehaviour
{
    [SerializeField] float speed = 5, jumpHeight = 2, sensitivity = 20, sprintScalar = 2;

    [SerializeField] Camera playerCamera;

    private bool pause = true;

    private Rigidbody m_rigidbody;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) pause = !pause;
        if (!pause)
        {
            float movement = speed;
            if (Input.GetKey(KeyCode.LeftShift)) movement *= sprintScalar;
            transform.position += movement * Time.deltaTime * ((transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal")));

            if (Input.GetKeyDown(KeyCode.Space)) m_rigidbody.AddForce(jumpHeight * Time.deltaTime * Vector3.up);

            float turnSpeedX = sensitivity * Time.deltaTime * Input.GetAxis("Mouse X");
            transform.Rotate(0, turnSpeedX, 0);

            float turnSpeedY = sensitivity * Time.deltaTime * Input.GetAxis("Mouse Y");
            playerCamera.transform.Rotate(-turnSpeedY, 0, 0);
        }
    }
}

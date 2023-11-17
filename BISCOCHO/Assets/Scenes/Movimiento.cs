using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float force = 150;
    Rigidbody rb;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main; // Assuming your camera is tagged as "MainCamera" or set as the main camera
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        Vector3 movement = (cameraForward.normalized * v + cameraRight.normalized * h).normalized;

        rb.AddForce(movement * force * Time.fixedDeltaTime);
    }
}

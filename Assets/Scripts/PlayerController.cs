using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed;

    public Transform orientation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 newMoveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);
        
        //Vector3 newMoveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);
        rb.velocity = newMoveDirection.normalized * moveSpeed;

    }


}

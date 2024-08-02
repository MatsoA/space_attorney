using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    void Movement() 
    {
        groundedPlayer = controller.isGrounded;

        //Debug.Log(groundedPlayer);

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        Vector3 move = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));

        if (move != Vector3.zero)
        {
          transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            Debug.Log("jump");
            groundedPlayer = false;
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;

        controller.Move(move * Time.deltaTime * playerSpeed + playerVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();

            interactable.HelperEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();

            interactable.HelperExit();
        }
    }

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
       Movement();
    }
}

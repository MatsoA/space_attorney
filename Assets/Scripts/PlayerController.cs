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
    
    public Transform helperHand;

    public bool inConversation = false;

    private IInteractable interactable = null;

    public CameraController mainCameraController;

    void Movement() 
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        Vector3 move = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));

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

    void Interact() {
        if (interactable != null) {
            helperHand.gameObject.SetActive(false);
            interactable.Interact();
            interactable = null;
        } else {
            Debug.Log("No interactable nearby");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interactable = other.gameObject.GetComponent<IInteractable>();
        if (interactable != null) {
            helperHand.gameObject.SetActive(true);
            interactable.HelperEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable") && interactable != null) {
            helperHand.gameObject.SetActive(false);
            interactable.HelperExit();
            interactable = null;
        }
    }

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!inConversation) {
            Movement();

            mainCameraController.sensModifier = 1f;
        } else {
            mainCameraController.sensModifier = 0.025f;
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            Interact();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlayerMovement : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private Vector3 kick = new Vector3(10f,0f, 10f);
    [SerializeField] private Coin coin;
    [SerializeField] public int scoreCoin;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private PlayerControls playerInput;
    private Vector2 movementInput;

    private void Awake()
    {
        playerInput = new PlayerControls();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    void Update()
    {
        Move();
        FlipPlayer();
    }
    private void Move()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (playerInput.Player.Jump.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void FlipPlayer()
    {
        bool playerMovingX = Mathf.Abs(movementInput.x) > Mathf.Epsilon;
        bool playerMovingZ = Mathf.Abs(movementInput.y) > Mathf.Epsilon;

        if (playerMovingX)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.localScale = new Vector3(Mathf.Sign(movementInput.x), 1f, 1f);
        }
        if (playerMovingZ)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.rotation= Quaternion.Euler(0f, Mathf.Sign(movementInput.y)*-90, 0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DamageDealer>())
        {
            if (this.gameObject.GetComponent<Transform>().localScale.x < 0)
            {
                controller.Move(kick);
            }
            else if (this.gameObject.GetComponent<Transform>().localScale.x > 0)
            {
                kick.x = -kick.x;
                controller.Move(kick);
            }
        }
        if (other.tag == "Coin")
        {
            scoreCoin += coin.coinValue;
        }
    }
}

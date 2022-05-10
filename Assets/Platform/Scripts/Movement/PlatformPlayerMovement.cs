using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] public Vector2 kick = new Vector2(10f, 10f);
    [SerializeField] public int scoreCoin;
    [SerializeField] private Coin coin;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private PlayerControls playerInput;
    private Vector2 movementInput;
    private float staticSpeed;

    private void Awake()
    {
        staticSpeed = playerSpeed;
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
    public void Move()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, 0f);

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (playerInput.Player.Jump.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (move != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Running", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Running", false);
        }
    }
    public void FlipPlayer()
    {
        bool playerMovingX = Mathf.Abs(movementInput.x) > Mathf.Epsilon;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (playerMovingX)
        {
            transform.localScale = new Vector3(Mathf.Sign(movementInput.x), 1f, 1f);
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

    public void SetNewSpeed(float newSpeed)
    {
        playerSpeed = newSpeed;
        Invoke("SetOldSpeed", 10f);
    }
    private void SetOldSpeed()
    {
        playerSpeed = staticSpeed;
    }
}

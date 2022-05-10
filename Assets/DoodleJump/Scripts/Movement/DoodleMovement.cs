using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleMovement : MonoBehaviour
{
    [SerializeField] private float gravityValue = 0f;
    [SerializeField] public float playerSpeed = 2.0f;
    [SerializeField] public float jumpHeight = 0f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Coin coin;
    [SerializeField] public int scoreCoin;

    [HideInInspector] public CharacterController controller;
    [HideInInspector] public Vector3 move;

    private PlayerControls playerInput;
    private Vector3 playerVelocity;

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
        KeepOnScreen();
    }
    public void Move()
    {
        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();;
        move = new Vector3(movementInput.x * 1.5f, playerVelocity.y, 0f);

        Quaternion rotation = Quaternion.Euler(Vector3.zero);
        transform.rotation = rotation;
        
        playerVelocity.y += gravityValue * Time.deltaTime;   
    }
    private void FixedUpdate()
    {
        controller.Move(move * Time.fixedDeltaTime * playerSpeed);
        KeepOnScreen();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block")
        {
            if (playerVelocity.y < 0)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
        }
        if(other.tag=="Coin")
        {
            scoreCoin += FindObjectOfType<Coin>().coinValue;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag=="Enemy")
        {
            FindObjectOfType<GameManager>().RestartScene();
        }
    }

    public void KeepOnScreen()
    {
        Vector3 newPos = transform.position;

        Vector3 veiwPos = Camera.main.WorldToViewportPoint(newPos);

        if(veiwPos.x>1)
        {
            newPos.x = -newPos.x+0.5f;
        }
        else if (veiwPos.x < 0)
        {
            newPos.x = -newPos.x-0.5f;
        }
        transform.position = newPos;
    }
}

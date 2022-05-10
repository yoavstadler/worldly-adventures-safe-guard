
using UnityEngine;

public class FlyerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] public int scoreCoin;
    [SerializeField] private Coin coin;

    private CharacterController controller;
    private PlayerControls playerInput;
    private Vector3 move;

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
    }

    private void Move()
    {
        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        move = new Vector3(movementInput.x, movementInput.y, 0f);
    }
    private void FixedUpdate()
    {
        controller.Move(move * Time.fixedDeltaTime * playerSpeed);
        Quaternion rotation = Quaternion.Euler(Vector3.zero);
        transform.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            scoreCoin += coin.coinValue;
        }
    }
}

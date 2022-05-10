using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class RunnerFixMovement : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] public Vector3 direction;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityScale;
    [SerializeField] private Coin coin;
    
    private CharacterController characterController;
    private Vector3 worldPositionTouch;
    private Vector3 worldLastPosition;
    private Vector3 diffPosition;
    private bool laneChange = false;
    private double time;

    [HideInInspector] public bool powerUp;
    [HideInInspector] public int scoreCoin;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        direction.y += gravityScale;
    }
    private void OnEnable()
    {
        TouchSimulation.Enable();
    }
    private void OnDisable()
    {
        TouchSimulation.Disable();
    }
    void Update()
    {
        Move();
    }
    public void Move()
    {
        Vector3 startPosition;
        Vector3 touchPosition;
        Ray rayStart;
        Ray rayEnd;

        Transform newTransform = GetComponent<Transform>();

        direction.y += gravityScale * Time.deltaTime;

        if (Touchscreen.current.press.isPressed)
        {

            startPosition = Touchscreen.current.primaryTouch.startPosition.ReadValue();
            touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            rayStart = Camera.main.ScreenPointToRay(startPosition);
            rayEnd = Camera.main.ScreenPointToRay(touchPosition);

            if (Physics.Raycast(rayStart, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                worldPositionTouch = raycastHit.point;

                if (Physics.Raycast(rayEnd, out RaycastHit raycastHit2, float.MaxValue, layerMask))
                {
                    worldLastPosition = raycastHit2.point;
                }
            }
            diffPosition = worldLastPosition - worldPositionTouch;

            if (time < 0.1f)
            {
                if (diffPosition.x > 2 && diffPosition.x > diffPosition.y && laneChange == false && newTransform.position.x < 2f)
                {
                    direction.x = 5.5f;
                    laneChange = true;
                    StartCoroutine(StopOnLane());
                }
                if (diffPosition.x < -2 && -diffPosition.x > diffPosition.y && laneChange == false && newTransform.position.x > -2f)
                {
                    direction.x = -5.5f;
                    laneChange = true;
                    StartCoroutine(StopOnLane());
                }
                if (diffPosition.y >= 2 && characterController.isGrounded)
                {
                    direction.y = jumpForce;
                }
            }
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
        }
        if (GetComponent<PowerUp>().checkPowerUp())
        {
            powerUp = true;
        }
        else
        {
            powerUp = false;
        }
    }
    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }
    IEnumerator StopOnLane()
    {
        yield return new WaitForSeconds(0.4f);
        direction.x = 0;
        laneChange = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            scoreCoin += coin.coinValue;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            StartCoroutine(WaitBeforeRestart());
        }
    }
    public IEnumerator WaitBeforeRestart()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<RunnerGameManager>().RestartScene();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaPLShooter : BaseShooter
{
    [SerializeField] private int numBullets;

    private CharacterController controller;
    private PlayerControls playerInput;
    private GameObject button;
    private int shoot = 0;

    private void Awake()
    {
        playerInput = new PlayerControls();
        controller = GetComponent<CharacterController>();
        button = FindObjectOfType<GamePlayStats>().Firebutton;
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {
        if (GetComponent<PowerUp>().checkPowerUp()&& shoot < numBullets)
        {
            button.gameObject.SetActive(true);
        }
        else if (shoot >= numBullets)
        {
            button.gameObject.SetActive(false);
            GetComponent<PowerUp>().SetBool();
            shoot = 0;
        }

        if (playerInput.Player.Fire.triggered && shoot < numBullets)
        {
            if (GetComponent<Transform>().localScale.x > 0)
            {
                Fire(transform.right); ;
                shoot++;
            }

            if (GetComponent<Transform>().localScale.x < 0)
            {
                Fire(-transform.right);
                shoot++;
            }
        }
        
    }
}

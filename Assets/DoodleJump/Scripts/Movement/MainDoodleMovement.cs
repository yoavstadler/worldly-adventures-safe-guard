using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoodleMovement : DoodleMovement
{
    [SerializeField] float powerUpJumpForce;

    private float oldJumpForce;
    void Start()
    {
        oldJumpForce = jumpHeight;
    }

    void Update()
    {
        Move();
        KeepOnScreen();

        if (GetComponent<PowerUp>().checkPowerUp())
        {
            jumpHeight = powerUpJumpForce;
        }
        else
        {
            jumpHeight = oldJumpForce;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChPlatformMovement : PlatformPlayerMovement
{
    [SerializeField] private float speedOnPowerUp = 0f;

    private void Update()
    {
        if(GetComponent<PowerUp>().checkPowerUp())
        {
            SetNewSpeed(speedOnPowerUp);
            Move();
            FlipPlayer();
        }
        else
        {
            Move();
            FlipPlayer();
        }
    }
}

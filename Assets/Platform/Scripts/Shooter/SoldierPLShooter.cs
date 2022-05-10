using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPLShooter : BaseShooter
{
    private void Update()
    {
        bool checkPowerUp = false;

        checkPowerUp = GetComponent<PowerUp>().checkPowerUp();

        if (checkPowerUp)
        {
            if (GetComponent<Transform>().localScale.x > 0)
            {
                Fire(transform.right);
            }
            if (GetComponent<Transform>().localScale.x < 0)
            {
                Fire(-transform.right);
            }
        }
    }
}

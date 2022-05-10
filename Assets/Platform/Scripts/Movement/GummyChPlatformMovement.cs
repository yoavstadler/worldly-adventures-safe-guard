using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyChPlatformMovement : PlatformPlayerMovement
{
    [SerializeField] private int playerDamage = 0;
    [SerializeField] private DamageDealer damageDealer;

    private Vector2 oldKick;
    private void Start()
    {
        oldKick = kick;
    }
    void Update()
    {
        if (FindObjectOfType<PowerUp>().checkPowerUp())
        {
            damageDealer.SetDamage(playerDamage);
            kick = Vector2.zero;
        }
        else
        {
            kick = oldKick;
            damageDealer.SetDamage(0);
        }
        Move();
        FlipPlayer();
    }
}

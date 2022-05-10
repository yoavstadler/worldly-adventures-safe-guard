using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFlyerStats : StatsParent
{
    bool checkPowerUp = false;
    private void Update()
    {
        checkPowerUp = GetComponent<PowerUp>().checkPowerUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            if (checkPowerUp && this.tag == "Player")//enemy body cant hurt player
            {
                return;
            }
            else
            {
                if (health <= 0)
                {
                    if (FindObjectOfType<FlyerMovement>())
                    {
                        FindObjectOfType<FlyerMovement>().scoreCoin += enemyValue;
                    }
                }
                TakeDamage(damageDealer.GeTDamage());
                if (cameraShake != null)
                {
                    ShakeCamera();
                }
                damageDealer.Hit();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyPlatformStats : StatsParent
{
    private void OnTriggerEnter(Collider other)
    {
        if (!GetComponent<PowerUp>().checkPowerUp())
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();

            if (damageDealer != null)
            {
                TakeDamage(damageDealer.GeTDamage());

                if (cameraShake != null)
                {
                    ShakeCamera();
                }
            }
        }
        if (health <= 0)
            FindObjectOfType<PlatformGameManager>().RestartScene();
    }
}

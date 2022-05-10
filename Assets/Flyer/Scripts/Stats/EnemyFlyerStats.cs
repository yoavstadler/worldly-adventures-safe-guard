using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyerStats : StatsParent
{
    private FlyerMovement Player;

    private void Start()
    {
        Player = FindObjectOfType<FlyerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GeTDamage());
            if (health <= 0)
            {
                Player.scoreCoin += enemyValue;
            }
            if (cameraShake != null)
            {
                ShakeCamera();
            }
            damageDealer.Hit();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerStats : StatsParent
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GeTDamage());
            
            if (cameraShake != null)
            {
                ShakeCamera();
            }
            damageDealer.Hit();

            if (health <= 0)
            {
                gameManager.RestartScene();
            }
        }
    }
}

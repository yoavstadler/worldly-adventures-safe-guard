using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatformStats : StatsParent
{
    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GeTDamage());
        }
        if(other.tag=="Bullet")
        {
            other.GetComponent<DamageDealer>().Hit();
        }
    }
}

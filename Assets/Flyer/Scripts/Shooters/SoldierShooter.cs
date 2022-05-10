using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierShooter : BaseShooter
{
    [SerializeField] private bool powerUp;

    void Update()
    {
        powerUp = GetComponent<PowerUp>().checkPowerUp();

        if(powerUp&& GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            PowerUpFire();
        }
        else
        {
            Fire(transform.up);
        }
    }
    private void PowerUpFire()
    {
        if (Time.time > playerTimeLastShot)
        {
            GameObject instance = Instantiate(BigprojectilePrefab, transform.position, Quaternion.identity);
            instance.GetComponent<BigProjectile>().enemyTransform = FindObjectOfType<EnemyShooter>().transform;

            playerTimeLastShot = Time.time + 1f;
            Destroy(instance, projectileLifetime);
        }
    }
}

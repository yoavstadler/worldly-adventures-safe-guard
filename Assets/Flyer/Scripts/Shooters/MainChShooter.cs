using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChShooter : BaseShooter
{
    private bool powerUp;

    void Update()
    {
        powerUp = GetComponent<PowerUp>().checkPowerUp();

        if (!powerUp)
        {
            Fire(transform.up);
        }
        else
        {
            PowerUpFire();
        }
    }

    private void PowerUpFire()
    {
        if (Time.time > playerTimeLastShot)
        {
            Vector3 positionFire1 = transform.position;
            Vector3 positionFire2 = transform.position;
            positionFire1.x += 0.1f;
            positionFire2.x -= 0.1f;
            GameObject instance1 = Instantiate(projectilePrefab, positionFire1, Quaternion.identity);
            GameObject instance2 = Instantiate(projectilePrefab, positionFire2, Quaternion.identity);
            Rigidbody rb1 = instance1.GetComponent<Rigidbody>();
            Rigidbody rb2 = instance2.GetComponent<Rigidbody>();

            if (rb1 != null && rb2 != null)
            {
                rb1.velocity = transform.up * projectileSpeed * Time.deltaTime;
                rb2.velocity = transform.up * projectileSpeed * Time.deltaTime;
            }
            playerTimeLastShot = Time.time + baseFiringRate;
            Destroy(instance1, projectileLifetime);
            Destroy(instance2, projectileLifetime);
        }
    }
}

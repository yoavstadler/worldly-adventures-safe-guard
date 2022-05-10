using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShooter : MonoBehaviour
{
    [SerializeField] public GameObject projectilePrefab;
    [SerializeField] public GameObject BigprojectilePrefab;
    [SerializeField] public float projectileSpeed = 10f;
    [SerializeField] public float projectileLifetime = 5f;
    [SerializeField] public float baseFiringRate = 2f;

    [HideInInspector] public  float playerTimeLastShot = 0f;


    public void Fire(Vector3 diraction)
    {
        if (Time.time > playerTimeLastShot)
        {  
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody rb = instance.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = diraction * projectileSpeed * Time.deltaTime;
            }

            playerTimeLastShot = Time.time + baseFiringRate;
            Destroy(instance, projectileLifetime);
        }
    }
}

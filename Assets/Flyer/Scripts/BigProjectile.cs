using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 0f;

    [HideInInspector] public Transform enemyTransform;

    void Start()
    {
        
    }
    private void Update()
    {
        if (enemyTransform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyTransform.position, projectileSpeed * Time.deltaTime);
        }
    }
}

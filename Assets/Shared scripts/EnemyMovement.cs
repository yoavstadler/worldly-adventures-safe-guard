using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 0f;

    private Rigidbody rb;
    public bool start=true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void Update()
    {
        if (start == true)
        {
            Invoke("EnemyMove", 1f);
        }
        else
        {
            EnemyMove();
        }
    }
    private void EnemyMove()
    {
        rb.velocity = new Vector3(enemySpeed * Time.deltaTime, 0f, 0f);
        start = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Wall")
        {
            enemySpeed = -enemySpeed;
            FlipEnemyFacing();
        }
    }
    private void FlipEnemyFacing()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.localScale = new Vector3(-(Mathf.Sign(rb.velocity.x)), 1f, 1f);
    }
}

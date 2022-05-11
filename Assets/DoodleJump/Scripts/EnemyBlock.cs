using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeDiraction;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveBlockEnemy();
    }
    private void MoveBlockEnemy()
    {
        if (MovingRight())
        {
            rb.velocity = new Vector3(speed, 0f, 0f);
        }
        else
        {
            rb.velocity = new Vector3(-speed, 0f, 0f);
        }
    }
    bool MovingRight()
    {
        return rb.velocity.x > 0;
    }
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Wall")
        {
            Vector3 newVelocity = rb.velocity;
            newVelocity.x = newVelocity.x * (-1);
            rb.velocity = newVelocity;
        }
        if (other.gameObject.tag == "Player")
        {
            if (FindObjectOfType<DoodleMovement>().powerUp)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), other,true);
            }
            else
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), other,false);
                FindObjectOfType<GameManager>().RestartScene();
            }
            Physics.IgnoreCollision(GetComponent<Collider>(), other, false);
        }
    }
 }

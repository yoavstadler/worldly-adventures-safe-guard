using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleEnemy : MonoBehaviour
{
    [SerializeField] public float speed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        MoveEnemy();
        KeepOnScreen();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (FindObjectOfType<DoodleMovement>().powerUp)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), other,true);
            }
            else
            {
                FindObjectOfType<GameManager>().RestartScene();
            }
            Physics.IgnoreCollision(GetComponent<Collider>(), other, false);
        }
    }
    private void MoveEnemy()
    {
        rb.velocity = new Vector3(speed, 0f, 0f);
        rb.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    private void KeepOnScreen()
    {
        Vector3 newPos = transform.position;

        Vector3 veiwPos = Camera.main.WorldToViewportPoint(newPos);

        if (veiwPos.x > 1.1)
        {
            newPos.x = -newPos.x + 0.1f;
        }
        else if (veiwPos.x < -0.1)
        {
            newPos.x = -newPos.x - 0.1f;
        }

        transform.position = newPos;
    }
}

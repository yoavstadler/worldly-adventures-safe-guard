using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillColider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}

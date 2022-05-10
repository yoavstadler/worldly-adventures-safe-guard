using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag=="Coin")
        {
            Destroy(other.gameObject);
        }
    }

}

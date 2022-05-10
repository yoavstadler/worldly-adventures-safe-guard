using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)  //similar as moving block.
    {
        if (other.tag == "Player")
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}

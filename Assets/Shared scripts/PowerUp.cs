using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float waitTime = 5f;

    private bool powerUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            powerUp = true;
            Destroy(other.gameObject);
            Invoke("SetBool", waitTime);
        }
    }
    public bool checkPowerUp()
    {
        return powerUp;
    }
    public void SetBool()
    {
        powerUp = false;
    }
}

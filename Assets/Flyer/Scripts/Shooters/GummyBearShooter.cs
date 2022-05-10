using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyBearShooter : BaseShooter
{
    [SerializeField] private GameObject explosion;

    void Update()
    {
        Fire(transform.up);
    }
}

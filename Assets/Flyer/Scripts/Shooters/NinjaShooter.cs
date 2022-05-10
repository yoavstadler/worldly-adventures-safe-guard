using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaShooter : BaseShooter
{
    private void Update()
    {
        Fire(transform.up);
    }
}

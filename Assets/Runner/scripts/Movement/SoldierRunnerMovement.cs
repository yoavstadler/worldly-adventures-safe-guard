using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRunnerMovement : RunnerFixMovement
{
    [SerializeField] private GameObject Shield;

    private void Update()
    {
        Move();
        if (powerUp)
        {
            IncreaseSize();
        }
        else
        {
            ReduceSize();
        }
    }
    private void IncreaseSize()
    {
        Shield.SetActive(true);
    }
    private void ReduceSize()
    {
        Shield.SetActive(false);
    }
}

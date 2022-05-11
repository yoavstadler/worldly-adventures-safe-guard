using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyBearRunnerMovement : RunnerFixMovement
{
    [SerializeField] private GameObject bigCollider;

    private void Update()
    {
        Move();
        if(powerUp)
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
        bigCollider.SetActive(true);
        GetComponentInChildren<Animator>().SetBool("Increase", true);
    }
    private void ReduceSize()
    {
        bigCollider.SetActive(false);
        GetComponentInChildren<Animator>().SetBool("Increase", false);
    }
}

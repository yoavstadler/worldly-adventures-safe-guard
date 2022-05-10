using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaRunnerMovement : RunnerFixMovement
{
    private void Update()
    {
        if (powerUp)
        {
           foreach(EnemyRunnerWall enemy in FindObjectsOfType<EnemyRunnerWall>())
            {
                enemy.GetComponent<Collider>().enabled = false;
            }
        }
        else
        {
            foreach (EnemyRunnerWall enemy in FindObjectsOfType<EnemyRunnerWall>())
            {
                enemy.GetComponent<Collider>().enabled = true;
            }
        }
        Move();
    }
}

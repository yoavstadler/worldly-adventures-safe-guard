using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRunnerMovement : RunnerFixMovement
{
    [SerializeField] private float afterDeathZSpawn;

    private Vector3 beforeDeathPosition;
    private float zPosision;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            beforeDeathPosition = transform.position;
            
            if (powerUp)
            {
                zPosision = direction.z;
                direction.z = 0;
                beforeDeathPosition.z -= afterDeathZSpawn;
                transform.position = beforeDeathPosition;
                GetComponent<PowerUp>().SetBool();
                StartCoroutine(KeepMoving());
            }
            else
            {
                StartCoroutine(WaitBeforeRestart());
            }
        }
    }
    IEnumerator KeepMoving()
    {
        yield return new WaitForSeconds(1f);
        direction.z = zPosision;
    }
}

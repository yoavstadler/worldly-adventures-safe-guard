using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMaze : MonoBehaviour
{
    public Transform playerTramsform;

    void Update()
    {
        if (playerTramsform != null)
        {
            transform.position = new Vector3(playerTramsform.position.x,
                transform.position.y,
                playerTramsform.position.z);
        }
    }
}

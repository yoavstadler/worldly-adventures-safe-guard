using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRunner : MonoBehaviour
{
    [SerializeField] private RunnerGameManager gameManager;

    [SerializeField] private Transform playerPosition;
    private Vector3 offSet;

    void Start()
    {
        playerPosition = gameManager.currentCharacter.transform;
        offSet = playerPosition.position - transform.position;
    }
    void Update()
    {
        transform.position = playerPosition.position - offSet;
    }
}

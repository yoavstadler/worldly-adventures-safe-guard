using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlatformCamera : MonoBehaviour
{
    private GameObject currentCharacter;

    void Start()
    {
        StartCoroutine(SetCamera());    
    }
    IEnumerator SetCamera()
    {
        yield return new WaitForSeconds(0.1f);
        currentCharacter = FindObjectOfType<PlatformGameManager>().currentCharacter;
        GetComponent<CinemachineStateDrivenCamera>().Follow = currentCharacter.transform;
        GetComponent<CinemachineStateDrivenCamera>().m_AnimatedTarget = currentCharacter.GetComponent<Animator>();
    }

}

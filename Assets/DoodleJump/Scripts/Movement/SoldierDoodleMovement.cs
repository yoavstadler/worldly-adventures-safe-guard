using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDoodleMovement : DoodleMovement
{
    [SerializeField] private GameObject bubbleShield;

    void Update()
    {
        Move();
        KeepOnScreen();

        if (powerUp)
        {
            bubbleShield.SetActive(true);
            GetComponent<Animator>().SetBool("BubbleSize", true);

            /*foreach(DoodleEnemy enemy in FindObjectsOfType<DoodleEnemy>())
            {
                enemy.GetComponent<BoxCollider>().enabled = false;
            }*/
        }
        else
        {
            GetComponent<Animator>().SetBool("BubbleSize", false);
            bubbleShield.SetActive(false);

            /*foreach (DoodleEnemy enemy in FindObjectsOfType<DoodleEnemy>())
            {
                enemy.GetComponent<BoxCollider>().enabled = true;
            }*/
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearExplosion : MonoBehaviour
{
    private BoxCollider explosioncollider;
    public int score;
    private FlyerMovement player;

    private float x;
    private float y;

    private void Start()
    {
        explosioncollider = gameObject.GetComponent<BoxCollider>();
        player = FindObjectOfType<FlyerMovement>();
    }

    void Update()
    {
        if (GetComponentInParent<PowerUp>().checkPowerUp())
        {
            StartCoroutine(GetBigger());
        }
        else
        { 
            x = 0f;
            y = 0f;
            score = 0;
        }

    }

    IEnumerator GetBigger()
    {
        x += 0.2f;
        y += 0.2f;

        explosioncollider.size = new Vector3(x, y, 0f);
        yield return new WaitForSeconds(0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            score = other.GetComponent<EnemyFlyerStats>().enemyValue;
            player.scoreCoin += score;
            Destroy(other.gameObject);
        }
    }
}

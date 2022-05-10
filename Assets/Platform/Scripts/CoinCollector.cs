using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Coin coin;
    [SerializeField] public int scoreCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            scoreCoin += coin.coinValue;
        }
    }
}

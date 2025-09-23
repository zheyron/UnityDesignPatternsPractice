using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCoin : Coin
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.AddCoins(5);
            Destroy(gameObject);
        }
    }
}

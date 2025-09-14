using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFactory : MonoBehaviour
{
    [SerializeField] private Coin[] coinsList;
    private Dictionary<string, Coin> coinMap;
    [SerializeField] private SuperCoin[] superCoinsList;
    private Dictionary<string, SuperCoin> superCoinMap;

    private void Awake()
    {
        coinMap = new Dictionary<string, Coin>();

        foreach (var coin in coinsList)
        {
            coinMap.Add(coin.Id, coin);
        }
        superCoinMap = new Dictionary<string, SuperCoin>();

        foreach (var superCoin in superCoinsList)
        {
            superCoinMap.Add(superCoin.Id, superCoin);
        }
    }

    public Coin CreateCoin(string id)
    {
        if (!coinMap.TryGetValue(id, out Coin coin))
        {
            return null;
        }
        return Instantiate(coin);
    }

    public SuperCoin CreateSuperCoin(string id)
    {
        if (!superCoinMap.TryGetValue(id, out SuperCoin superCoin))
        {
            return null;
        }
        return Instantiate(superCoin);
    }

}

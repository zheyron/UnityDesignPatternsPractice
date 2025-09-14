using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAbstractFactory : MonoBehaviour
{
    [SerializeField] private CoinFactory coinFactory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            coinFactory.CreateCoin("coin");
            Debug.Log("Spawning coin");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            coinFactory.CreateSuperCoin("supercoin");
            Debug.Log("Spawning super coin");
        }
        
    }
}

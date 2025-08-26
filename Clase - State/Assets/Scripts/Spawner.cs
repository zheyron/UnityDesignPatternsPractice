using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory EnemyFactory;
    [SerializeField] private Transform _spawnPoint;

    public Transform SpawnPoint => _spawnPoint; // property to expose it safely

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EnemyFactory.CreateEnemy("Zombie", _spawnPoint.position);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            EnemyFactory.CreateEnemy("Ghost", _spawnPoint.position);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            EnemyFactory.CreateEnemy("Vampire", _spawnPoint.position);
        }
    }
}

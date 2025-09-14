using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Enemy[] enemiesList;
    private Dictionary<string, Enemy> idEnemiesDict;

    private void Awake()
    {
        idEnemiesDict = new Dictionary<string, Enemy>();

        foreach (var enemy in enemiesList)
        {
            idEnemiesDict.Add(enemy.Id, enemy);
        }

    }

    public Enemy CreateEnemy(string id, Vector3 position)
    {
        if (!idEnemiesDict.TryGetValue(id, out Enemy enemy))
        {
            return null;
        }
        return Instantiate(enemy, position, Quaternion.identity);
    }

}

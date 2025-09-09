using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/EnemyStats", order = 1)]
public class SO_Enemy : ScriptableObject
{
    public float maxHealth;
    public float baseDamage;
    public Material baseMaterial;
    public string enemyType;

    public virtual void Attack()
    {
        Debug.Log("Atacando y realizando " + baseDamage + " de daño");
    }
}

public class Vampire : SO_Enemy
{ 
    public override void Attack()
    {
        Debug.Log("Vampire atacando...");
        base.Attack();
    }
}

public class Zombie : SO_Enemy
{
    public override void Attack()
    {
        Debug.Log("Zombie atacando...");
        base.Attack();
    }
}

public class Ghost : SO_Enemy
{
    public override void Attack()
    {
        Debug.Log("Ghost atacando...");
        base.Attack();
    }
}
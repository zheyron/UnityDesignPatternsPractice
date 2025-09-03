using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/EnemyStats", order = 1)]
public class SO_Enemy : ScriptableObject
{
    public float maxHealth;
    public float baseDamage;
    public Material baseMaterial;

}

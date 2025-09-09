using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private string id;

    public string Id => id;
    public SO_Enemy enemyType;

    private float currentHealth;
    private Rigidbody rb;


    private void Awake()
    {
        if (enemyType == null)
        {
            Debug.LogError("${Id} has no EnemyType assigned.");
        }

        currentHealth = enemyType.maxHealth;

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Para que no se caiga de costado
    }

}

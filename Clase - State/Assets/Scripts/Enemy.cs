using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string id;

    public string Id => id;
    public SO_Enemy SO_Enemy;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Para que no se caiga de costado
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // Velocidad del jugador

    private Rigidbody rb; // Referencia al Rigidbody

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Para que no se caiga de costado
    }

    void FixedUpdate()
    {
        // Capturamos input (WASD / Flechas)
        float x = Input.GetAxisRaw("Horizontal"); // A/D o ←/→
        float z = Input.GetAxisRaw("Vertical");   // W/S o ↑/↓

        // Creamos un vector de movimiento (solo XZ)
        Vector3 move = new Vector3(x, 0f, z).normalized;

        // Aplicamos movimiento multiplicado por velocidad
        //rb.velocity = move * moveSpeed;
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}

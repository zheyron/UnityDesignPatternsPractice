using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] Player player;

   [SerializeField] private float moveSpeed = 5f;

    // The receiver method that concrete commands will call
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public float GetMoveSpeed() => moveSpeed;


}

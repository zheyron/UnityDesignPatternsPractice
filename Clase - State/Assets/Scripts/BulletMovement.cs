using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float destroyTime;
    public ObjectPool<BulletMovement> pool;

    private void Start()
    {
        Invoke("BulletDestroy", destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void BulletDestroy()
    {
        pool.Release(this);
    }

}

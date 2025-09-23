using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletMovement : MonoBehaviour
{
    public enum BulletType
    {
        single,
        multi
    }

    [SerializeField] private float speed;
    [SerializeField] private float destroyTime = 2.0f;
    [SerializeField] private BulletType type;


    public ObjectPool<BulletMovement> pool;

    private void OnEnable()
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

    public BulletType GetBulletType() => type;

}

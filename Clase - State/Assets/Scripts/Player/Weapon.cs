using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletMovement bullet;
    [SerializeField] private GameObject point;

    ObjectPool<BulletMovement> bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new ObjectPool<BulletMovement>(CreateBullet,GetBullet,ReleaseBullet,DestroyBullet, false,10,15);

        //for (int i = 0;i <10; i++)
        //{
        //    BulletMovement b = bulletPool.Get();
        //    bulletPool.Release(b);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate(bullet, point.transform.position,point.transform.rotation);
            bulletPool.Get();

        }
    }

    BulletMovement CreateBullet()
    {
        // Crear una nueva bala
        BulletMovement newBullet = Instantiate(bullet);
        newBullet.gameObject.SetActive(false);
        newBullet.pool = bulletPool;
        return newBullet;
    }

    void GetBullet(BulletMovement bullet)
    {
        // Activar una bala existente.
        bullet.gameObject.SetActive(true);
        bullet.gameObject.transform.position = point.transform.position;
        bullet.gameObject.transform.rotation = point.transform.rotation;
    }

    void ReleaseBullet(BulletMovement bullet)
    {
        // liberar o desactivar una bala}
        bullet.gameObject.SetActive(false);
    }


    void DestroyBullet(BulletMovement bullet)
    {
        // Destruir la bala.
        Destroy(bullet.gameObject);
    }
}

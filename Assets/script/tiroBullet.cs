using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVida = 2.0f;
    public float bulletSpeed = 6.0f;
    bool fire;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(!fire)
                InvokeRepeating("Fire",0f,0.2f);
                fire = true;
        }
        else
        {
            CancelInvoke("Fire");
            fire = false;
        }
    }

    void Fire()
    {
        // Cria um Bullet a partir de BulletPrefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Adiciona velocidade a Bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destruir Bullet depois de n segundos
        Destroy(bullet, bulletVida);
    }
}

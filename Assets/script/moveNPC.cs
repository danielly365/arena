using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class moveNPC : MonoBehaviour
{
    public float visao = 20.0f;
    public string nome;
    public Transform alvo;
    private NavMeshAgent agente;
    private float discTiro;
    public GameObject tiro;
    public Transform spawnpoint;
     public float bulletVida = 2.0f;
    public float bulletSpeed = 6.0f;
    bool isShoot;

    // Start is called before the first frame update
    void Start()
    {
        if(nome != "")
        {
            transform.name = nome;
        }
        agente = GetComponent<NavMeshAgent>();
        alvo = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, alvo.position) <= visao)
        {
            agente.isStopped = false;
            agente.SetDestination(alvo.position);
        }
        else
        {
            agente.isStopped = true;
        }

        agente.destination = alvo.position;
        float distance = Vector3.Distance(transform.position, alvo.position);
        if(distance<=visao)
        {
            if(!isShoot)
            {
                InvokeRepeating("Shoot", 0f, 0.5f);
                isShoot = true;
            }
        }
        else
        {
            CancelInvoke("Shoot");
            isShoot = false;
        }
    }

    void Shoot()
    {
        
         // Cria um Bullet a partir de BulletPrefab
        var bullet = (GameObject)Instantiate(tiro, spawnpoint.position, spawnpoint.rotation);

        // Adiciona velocidade a Bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destruir Bullet depois de n segundos
        Destroy(bullet, bulletVida);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "projetil")
        {
            if (gameObject != null)
            {      
                Destroy(gameObject);
            } 
        }
    }
}

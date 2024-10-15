using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resp : MonoBehaviour
{
 public float tempo;
 public GameObject vilão;
 public GameObject cura;

 float conta;
   
    void NovoInimigo()
    {
       
     if(!GameObject.Find("inimigo") || GameObject.Find("inimigo"))
     {
        conta += Time.deltaTime;
        if(conta > tempo ){
            Instantiate(vilão);
            conta = 0;
        }

     }
    }
    void Update()
    {
        NovoInimigo();
    }
}

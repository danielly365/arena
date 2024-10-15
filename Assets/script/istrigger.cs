using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class istrigger : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "vilão")
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }
}

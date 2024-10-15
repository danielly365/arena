using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controlePlayer : MonoBehaviour
{
    public float velocity = 10.0f;
    public float rotation = 90.0f;
    public Slider vida;

    void Start()
    {
        vida.value = 10;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = (Input.GetAxis("Horizontal"));
        float y = (Input.GetAxis("Vertical"));
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 dir = new Vector3(x, 0 ,y) * velocity;

        transform.Translate(dir * Time.deltaTime);

        transform.Rotate(new Vector3(
            0,
            mouseX*rotation*Time.deltaTime,
            0
        ));
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "projetilinimigo")
        {
            Debug.Log("acertou");
            if(vida.value > 0)
            {
                vida.value --;
            }
        }
        if(other.gameObject.tag == "cura")
        {
            Debug.Log("curou");
            if(vida.value < 10)
            {
                vida.value ++;
            }
        }
        if(vida.value == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
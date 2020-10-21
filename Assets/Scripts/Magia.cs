using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magia : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        //Ao colidir com inimigo, o destroi 
        if (colisor.gameObject.tag == "Inimigo")
        {
            Destroy(colisor.gameObject);
        }
    }
}

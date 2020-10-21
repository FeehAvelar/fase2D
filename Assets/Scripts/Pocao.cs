using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocao : MonoBehaviour
{

    public int vida = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            //Ao colidir com com player, recupera vida
            var player = colisor.gameObject.GetComponent<Player>();
            player.RecuperaVida(vida);
            Destroy(gameObject);
        }
    }
}

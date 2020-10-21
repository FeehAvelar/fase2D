using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamasAzuis : MonoBehaviour
{
    public float velocidade = 1;
    public int dano = 20;

    // Use this for initialization
    void Start()
    {
        //Se auto destroi depois de 5s
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimentacao
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        //quando colidir com player
        if (colisor.gameObject.tag == "Player")
        {
            var playerLife = colisor.gameObject.transform.GetComponent<Player_Life>();
            playerLife.perdeVida(dano);
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFogo : MonoBehaviour {

    private Rigidbody2D rb;
    private float posicaoY = 0f;
    public float altura = 400f;

	// Use this for initialization
	void Start () {
        //Se auto destroi depois de 2s
        Destroy(gameObject, 2f);
        
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * altura);
        posicaoY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (posicaoY > transform.position.y) //Descendo
        {
             transform.eulerAngles = new Vector2(180, 0);
        }
        posicaoY = transform.position.y;
	}

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            colisor.gameObject.GetComponent<Player_Life>().perdeVida(10);
        }
        Destroy(gameObject);
    }
}

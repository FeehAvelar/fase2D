using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

    public float velocidade;
    [Tooltip("True para direite, False para esquerda")]
    public bool direcao; //Esquerda ou direita
    public float duracaoDirecao;

    private float tempoNaDirecao;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (direcao)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        //movimentacao
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        
        //tempo em cada direcao
        tempoNaDirecao += Time.deltaTime;
        if (tempoNaDirecao >= duracaoDirecao)
        {
            tempoNaDirecao = 0;
            direcao = !direcao;
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            animator.SetTrigger("Atacou");
            var player = colisor.gameObject.transform.GetComponent<Player_Life>();

            player.perdeVida(30);
            colisor.gameObject.transform.Translate(-Vector2.right);
        }



    }
}

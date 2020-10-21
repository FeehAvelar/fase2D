using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovimento : MonoBehaviour
{
    [Header("Atibutos")]
    public float speed = 5f;
    [Tooltip("Tempo que a plataforma vai andar na mesma diração")]
    public float duracaoPosicao = 2f;
    private float ContaTempo = 0f;
    [Header("Direções")]
    [Tooltip("Caso a plataforma vai andar na horizontal")]
    public bool Horizontal;
    [Tooltip("Caso a plataforma vai andar na Vertical")]
    public bool Vertical;
    [Header("Direções que ira andar")]
    [Tooltip("True para começar andando para Direita")]
    public bool Direita = true; //True (Direita) False (Esquerda)
    [Tooltip("True para começar andando para Esquerda")]
    public bool Up = true; //true (Up) False Down


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Aumenta o tempo que esta na posiçao atual
        ContaTempo = ContaTempo + Time.deltaTime;
        if (ContaTempo >= duracaoPosicao)
        {
            //Zera contagem
            ContaTempo = 0f;
            //Muda Posicao
            if (Horizontal)
            {

                if (Direita)
                {
                    Direita = false;
                }
                else
                {
                    Direita = true;
                }
            }

            if (Vertical)
            {
                Up = !Up;
            }
        }
        //Movimenta
        if (Horizontal)
        {
            if (Direita)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (!Direita)
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }
        }
        if (Vertical)
        {
            if (Up)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            if (!Up)
            {
                transform.Translate(-Vector2.up * speed * Time.deltaTime);
            }
        }
    }

    //Enquanto colidir 
    void OnCollisionStay2D(Collision2D colisor)
    {
        if (colisor.gameObject.CompareTag("Player"))
        {
            colisor.gameObject.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.CompareTag("Player"))
        {
            colisor.gameObject.transform.parent = null;
        }
    }
}




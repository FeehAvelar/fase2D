using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDestuir : MonoBehaviour
{

    public float DuracaoPlataforma;
    public bool Cair;

    private float ContaTempo;
    private bool pisou;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pisou)
        {
            ContaTempo = ContaTempo + Time.deltaTime;
            //Se o tempo for maior que a direão
            if (ContaTempo >= DuracaoPlataforma)
            {
                if (Cair)
                {
                    gameObject.AddComponent<Rigidbody2D>();
                    Destroy(gameObject, 2f);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.CompareTag("Player"))
        {
            pisou = true;
        }
    }

}

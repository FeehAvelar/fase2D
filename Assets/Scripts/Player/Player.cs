using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Player é o nome do script (classe ou objeto)
public class Player : MonoBehaviour
{
    public float velocidade = 2;
    public float forcaPulo = 50;
    public Transform chaoVerificador;

    private Rigidbody2D rb;
    private bool estaNoChao;

    public Transform spritePlayer;
    private Animator animator;


    public GameObject vida;
    public GameObject vidaText;
    public int MaxVida;
    public int vidaAtual;
    
    public GameObject ataqueEspecial;
    public float duracaoAtaque;
    private float contagemAtaque;


    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = spritePlayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
   
    public void RecuperaVida(int recupera)
    {
        vidaAtual += recupera;

        if (vidaAtual > MaxVida)
        {
            vidaAtual = MaxVida;
        }

        if ((vidaAtual * 100 / MaxVida) >= 30)
        {
            vida.GetComponentInChildren<Image>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        }
        vidaText.GetComponent<Text>().text = "HP: " + vidaAtual + "/" + MaxVida;
    }

 }
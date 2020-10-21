using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject SpritePlayer;
    public float Velocidade = 2;
    public float forcaPulo = 10;

    public Transform ChaoVerificador;
    private bool estaNoChao;

    private Rigidbody2D rb;
    private Animator Anim;

    //Ataque
    [Header("Ataque Basico")]
    public GameObject ataqueBasico;
    public float duracaoAtaqueBasico;
    public float IntervaloAtaqueBasico;
    private float contagemAtaqueBasico;
    public float contaIntervaloBasico;


    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Anim = SpritePlayer.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Atacando();
        Movimentacao();        
        ContaIntervalo();
	}

    void Movimentacao()
    {
        //Verifica se está na layer piso
        estaNoChao = Physics2D.Linecast(transform.position, ChaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
        //Seta animação chao com o valor da var estaNoChao
        Anim.SetBool("Chao", estaNoChao);
        //Seta animacao movimento com o valor la linha AXIS
        Anim.SetFloat("Movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        //Anda para direita
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            transform.Translate(Vector2.right * Velocidade * Time.deltaTime);
        }
        //Anda para esquerda
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector2(0, - 180);
            //transform.Rotate(0, 180, 0);
            transform.Translate(Vector2.right * Velocidade * Time.deltaTime);
        }

        //Jump
        if (Input.GetButton("Jump") && estaNoChao)
        {
            rb.AddForce(new Vector2(0, forcaPulo));
        }
    }

    void Atacando()
    {
        if (Input.GetButtonDown("Fire1") && GetComponent<Player_Life>().vidaAtual >= 11 && (IntervaloAtaqueBasico <= contaIntervaloBasico))
        {
            ataqueBasico.SetActive(true);
            contagemAtaqueBasico = 0f;
            contaIntervaloBasico = 0f;
            GetComponent<Player_Life>().perdeVida(20);
        }

        if (Input.GetButton("Fire1"))
        {
            contagemAtaqueBasico += Time.deltaTime;
            if (contagemAtaqueBasico >= duracaoAtaqueBasico)
            {
                ataqueBasico.SetActive(false);

            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            ataqueBasico.SetActive(false);
        }


    }

    void ContaIntervalo()
    {
        //Contagem de intervalo do ataque basico
        contaIntervaloBasico = contaIntervaloBasico + Time.deltaTime;
    }    
}

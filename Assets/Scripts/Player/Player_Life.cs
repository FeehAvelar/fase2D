using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class Player_Life : MonoBehaviour {
    [Header("Conf. de vida")]
    [Tooltip("Vida maxima que o player chega")]
    public int vidaMaxima = 100;
    public int vidaAtual;

    [Header("Componentes da Canvas(HUD)")]
    //Slider e seus componentes
    public Slider HPSlider;
    public GameObject FillSlider;
    public GameObject VidaTexto;

    bool Damaged;
    
    private float contaTempoMorte = 0f;

    // Use this for initialization
    void Awake()
    {
        // Se no inicio a vida atual for diferente da vida maxima
        if (vidaAtual != vidaMaxima)
        {
            vidaAtual = vidaMaxima;
        }

        //Configurando Slider
        HPSlider.GetComponent<Slider>().maxValue = vidaMaxima;
        HPSlider.GetComponent<Slider>().value = vidaAtual;


        FillSlider.GetComponent<Image>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        HPSlider.GetComponentInChildren<Text>().text = "HP: " + vidaAtual + "/" + vidaMaxima;
        
        //COnfurando Animação
    }
	
	// Update is called once per frame
	void Update () {
        checkVivo();
    }

    public void checkVivo()
    {
        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            Death();
        }
    }

    public void perdeVida(int Dano)
    {
        vidaAtual -= Dano;

        HPSlider.value = vidaAtual;

        if (vidaAtual <= 0)
        {
            HPSlider.value = 0;
            FillSlider.GetComponent<Image>().color = new Vector4(0, 0, 0, 0);
            Death();
        }

        //Se vida for maior que 90%
        if (vidaAtual > vidaMaxima * 0.90)
        {
            FillSlider.GetComponent<Image>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        }
        //Se vida for Menor que 90% E Maior que 70%
        if ((vidaAtual <= vidaMaxima *0.90) && (vidaAtual > vidaMaxima * 0.7))
        {
            FillSlider.GetComponent<Image>().color = Color.green;
        }
        //Se vida for Menor que 70% E Maior que 30%
        if ((vidaAtual <= vidaMaxima *0.7) && (vidaAtual > vidaMaxima * 0.3))
        {
            FillSlider.GetComponent<Image>().color = Color.yellow;
        }
        //Se vida for Menor que 30%
        if (vidaAtual <= vidaMaxima * 0.3)
        {
            FillSlider.GetComponent<Image>().color = Color.red;
        }

        HPSlider.GetComponentInChildren<Text>().text = "HP: " + vidaAtual + "/" + vidaMaxima;
    }

    void Death(float tempoMorte = 2f)
    {
        gameObject.GetComponent<Player>().enabled = false;
        FillSlider.GetComponent<Image>().color = new Vector4(0, 0, 0, 0);
        gameObject.GetComponent<Animator>().SetTrigger("Morrendo");
        gameObject.GetComponent<PlayerController>().enabled = false;

        contaTempoMorte = contaTempoMorte + Time.deltaTime;
        if (contaTempoMorte >= tempoMorte)
        {
            contaTempoMorte = 0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

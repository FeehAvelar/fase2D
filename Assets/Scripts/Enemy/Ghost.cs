using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public float intervaloAtaque;
    private float contagemIntervalo;
    private bool atacou;
    public float distanciaAtaque;


    public GameObject ataque;
    public GameObject player;

    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        //verifica distancia do player
        var distancia = (player.transform.position.x - transform.position.x);

        //direciona o inimigo
        if (distancia > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        
        //verifica se pode atacar
        if (!atacou && Mathf.Abs(distancia) <= distanciaAtaque)
        {
            animator.SetTrigger("Atacou");
            Instantiate(ataque, transform.position, transform.rotation);
            atacou = true;
        }
        //se atacou, faz contagem de intervalo para novos ataques
        if (atacou)
        {
            contagemIntervalo += Time.deltaTime;
            if (contagemIntervalo >= intervaloAtaque)
            {
                atacou = false;
                contagemIntervalo = 0;
            }
        }
     }
}

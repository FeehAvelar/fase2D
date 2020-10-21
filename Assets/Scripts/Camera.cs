using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Transform player;

	// Use this for initialization
	void Start () {
        //Encontra o player, e captura sua posicao
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 novaPosicao = new Vector3(player.position.x, player.position.y, transform.position.z);
        //Assim faz a camera sempre seguir o player
        transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.time);
    }
}

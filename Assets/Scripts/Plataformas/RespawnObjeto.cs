using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnObjeto : MonoBehaviour {

    public GameObject objeto; //Objeto a ser criado
    public float tempoRespawn = 0f; //tempo que ira demorar para dar respawn
    public float tempoCorrido = 0f; //Tempo que ja passou desde o ultimo respawn
    public float tempoVida = 0f; //O tempo maximo que um objeto fica em cena


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        tempoCorrido = tempoCorrido + Time.deltaTime;
        if (tempoCorrido >= tempoRespawn)
        {
            Instantiate(objeto, transform.position, objeto.transform.rotation);
            tempoCorrido = 0f;
        }
        
    }
}

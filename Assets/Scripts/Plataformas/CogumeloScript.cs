using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogumeloScript : MonoBehaviour {

    public float jumpForce = 300;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnCollisionEnter2D(Collision2D Colisor)
    {
		//joga o que colidir para cima
        Colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce); 
    }
}

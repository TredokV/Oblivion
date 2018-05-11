using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D balita){
		if(balita.gameObject.tag == "Enemy" || balita.gameObject.tag == "Walls"){
			Destroy(gameObject);
		}
	}
}

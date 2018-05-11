using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
	public Transform rombus;
	public Transform biggie;


	void OnTriggerEnter2D(Collider2D balota){
		if(balota.gameObject.tag == "Player" || balota.gameObject.tag == "Walls" || balota.gameObject.tag == "PlayerProjectile"){
			Destroy(gameObject);
		}
	}
}

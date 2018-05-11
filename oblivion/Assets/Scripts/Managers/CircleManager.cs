using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			Destroy(gameObject);
		}
	}
	/*void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerProjectile"){
			Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
		}
	}*/	
}

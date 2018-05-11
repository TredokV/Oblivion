using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
	Transform player;
	public GameObject enemyProjectile;
	public Rigidbody2D bulletrb;

	private Rigidbody2D selfRB;
	private float projectileVelocity;
	public float rotationSpeed;
	public float playerDetectionRange;
	public int shootMode;

	// Use this for initialization
	void Awake() {
		projectileVelocity = 3;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		selfRB = GetComponent<Rigidbody2D>();
		shootMode = Random.Range(0, 2);
	}

	// Update is called once per frame
	void Update () {
		// Get the distance betweeen the player and the main enemies
		float distanceToTarget = Vector2.Distance(transform.position, player.position);

		if(shootMode == 0){
			Mode0Detect(distanceToTarget);
		}
		if(shootMode == 1){
			Mode1Detect(distanceToTarget);
		}
	}

	// This detects when a player get close enough to attack.
	void Mode0Detect(float distance){
		// if its close enough ATTACK
		if(distance < playerDetectionRange){
			ShootRight();
			Rotate();
		}
	}
	void Rotate(){
		 selfRB.MoveRotation(selfRB.rotation + rotationSpeed * Time.deltaTime);
	}
	void ShootRight(){
		Vector2 shootDirection = transform.right * 500;
		GameObject bullet = (GameObject)Instantiate(enemyProjectile, (Vector2)transform.position, Quaternion.identity);
		bulletrb = bullet.GetComponent<Rigidbody2D>();
		bulletrb.velocity = shootDirection * projectileVelocity;
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}

  void Mode1Detect(float distance){
		if(distance < playerDetectionRange){
			//ShootAhead();
			ShootPlayer();
			ShootBehind();
		}
  }

 	void ShootPlayer(){
		Vector3 playerDelta = player.position - transform.position;
		Vector3 force = playerDelta.normalized * 1200;
		GameObject bullet = (GameObject)Instantiate(enemyProjectile, transform.position, Quaternion.identity);
		bulletrb = bullet.GetComponent<Rigidbody2D>();
		bulletrb.velocity = force;
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}

	void ShootAhead(){
		Vector3 directionBehind = new Vector3(0, 0, -37);
		Vector3 playerDelta = player.position - transform.position;
		Vector3 force = playerDelta.normalized * 1200;
	  Vector3 forceAhead = Quaternion.Euler(directionBehind) * force;

		GameObject bullet = (GameObject)Instantiate(enemyProjectile, transform.position, Quaternion.identity);
		bulletrb = bullet.GetComponent<Rigidbody2D>();
		bulletrb.velocity = forceAhead;
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

	}

	void ShootBehind(){
		Vector3 directionAhead = new Vector3(0, 0, 37);
		Vector3 playerDelta = player.position - transform.position;
		Vector3 force = playerDelta.normalized * 1200;
		Vector3 forceBehind = Quaternion.Euler(directionAhead) * force;

		GameObject bullet = (GameObject)Instantiate(enemyProjectile, transform.position, Quaternion.identity);
		bulletrb = bullet.GetComponent<Rigidbody2D>();
		bulletrb.velocity = forceBehind;
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());


	}
}

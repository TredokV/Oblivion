using UnityEngine;

public class EnemyHealth : MonoBehaviour{

  public int startingHealth = 1;
  public int currentHealth;
  //public float sinkSpeed = 2.5f;
  public int scoreValue = 10;

  PolygonCollider2D collider;
  bool isDead;
  bool isSinking;

  void OnTriggerEnter2D(Collider2D enemigo){
    if(enemigo.gameObject.tag == "PlayerProjectile"){
      TakeDamage(1);
    }
  }
  void OnCollisionEnter2D(Collision2D enemigo){
    if(enemigo.gameObject.tag == "Player"){
      TakeDamage(1);
    }
  }

  void Awake(){
    collider = GetComponent<PolygonCollider2D>();
    currentHealth = startingHealth;
  }

  public void TakeDamage(int amount){
    if(isDead)
      return;

    currentHealth -= amount;
    if(currentHealth <= 0)
      Death();
  }

  void Death(){
    isDead = true;
    Destroy(gameObject);
  }
}

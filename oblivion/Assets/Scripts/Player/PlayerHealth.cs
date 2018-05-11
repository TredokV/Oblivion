using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerHealth : MonoBehaviour{
  public int startingHealth = 5;
  public int currentHealth;

  // For the UI
  public Text lifeText;
  public Image damageImage;
  public float flashSpeed = 2f;
  public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

  PlayerMovement playerMovement;
  PlayerShooting playerShooting;
  bool isDead;
  bool damaged;

  void OnCollisionEnter2D(Collision2D player){
    if(player.gameObject.tag == "Enemy"){
      TakeDamage(1);
    }
  }
  void OnTriggerEnter2D(Collider2D player){
    if(player.gameObject.tag == "Enemy"){
      TakeDamage(1);
    }
  }

  void Awake(){
    playerMovement = GetComponent<PlayerMovement>();
    playerShooting = GetComponentInChildren<PlayerShooting>();
    currentHealth = startingHealth;
  }

  void Update(){
    if(damaged){
      damageImage.color = flashColour;
    } else{
      damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
    }
    damaged = false;
  }

  public void TakeDamage(int amount){
    damaged = true;
    currentHealth -= amount;
    //lifeText = (String)currentHealth;
    if(currentHealth <= 0 && !isDead){
      Death();
    }
  }

  void Death(){
    isDead = true;
    playerMovement.enabled = false;
    playerShooting.enabled = false;
    Destroy(gameObject);
  }
}

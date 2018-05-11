using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerShooting : MonoBehaviour{

  public GameObject projectilePrefab; // Create a GameObject for the bullet
  public Rigidbody2D bulletrb;        // Create a Rigidbody2D for the bullet
  public Transform bulletTransform;   // Create a Transform for the bullet
  private float projectileVelocity;   // Declare float for the velocity
  float timer = 0;
  float timeBetweenBullets = .05f;

  void Start(){
    projectileVelocity = 70000;
  }

	void FixedUpdate(){
    timer += Time.deltaTime;
    float h = Input.GetAxis("HorizontalRight");
    float v = Input.GetAxis("VerticalRight");
    if(timer >= timeBetweenBullets){
      ShootLeft(h, v);
      Shoot(h, v);
      ShootRight(h, v);
      timer = 0;
    }
	}

  void ShootRight(float h, float v){
      if(h != 0 || v != 0){
        Vector3 bulletDirection = new Vector3(0, 0, 7);

        Vector3 shootDirection = new Vector3(h, v, 0);
        Vector3 shootSpawn = new Vector3(h * 160, v * 160, 0);
        Vector3 force = shootDirection.normalized * projectileVelocity;
        Vector3 shootDirectionCorrected = Quaternion.Euler(bulletDirection) * force;
        float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

        GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position + shootSpawn, Quaternion.identity);

        bulletrb = bullet.GetComponent<Rigidbody2D>();
        bulletTransform = bullet.GetComponent<Transform>();

        bulletTransform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        bulletrb.velocity = shootDirectionCorrected;
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      }
    }

    void ShootLeft(float h, float v){
        if(h != 0 || v != 0){
          Vector3 bulletDirection = new Vector3(0, 0, -7);

          Vector3 shootDirection = new Vector3(h, v, 0);
          Vector3 shootSpawn = new Vector3(h * 160, v * 160, 0);
          Vector3 force = shootDirection.normalized * projectileVelocity;
          Vector3 shootDirectionCorrected = Quaternion.Euler(bulletDirection) * force;
          float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

          GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position + shootSpawn, Quaternion.identity);

          bulletrb = bullet.GetComponent<Rigidbody2D>();
          bulletTransform = bullet.GetComponent<Transform>();

          bulletTransform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
          bulletrb.velocity = shootDirectionCorrected;
          Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
      }


  void Shoot(float h, float v){
    if(h != 0 || v != 0){
      Vector2 shootDirection = new Vector2(h, v);
      Vector2 shootSpawn = new Vector2(h * 160, v * 160);

      float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg ;
      //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
      GameObject bullet = (GameObject)Instantiate(projectilePrefab, (Vector2)transform.position + shootSpawn, Quaternion.identity);

      bulletrb = bullet.GetComponent<Rigidbody2D>();
      bulletTransform = bullet.GetComponent<Transform>();

      bulletTransform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
      bulletrb.velocity = shootDirection * projectileVelocity;
      Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
	}
}

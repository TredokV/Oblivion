using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour{
  Transform player;
  PlayerHealth playerHealth;
  EnemyHealth enemyHealth;
  int speed = 700;

  void Awake(){
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }

  void Update(){
    Vector3 playerDir = player.position - transform.position;
    float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg - 90f;
    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
    transform.Translate(Vector3.up * Time.deltaTime * speed);
  }
}

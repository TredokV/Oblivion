using UnityEngine;

public class EnemyManager : MonoBehaviour{
  public PlayerHealth playerHealth;
  public GameObject enemy;
  public float spawnTime = 3f;
  public Transform[] spawnPoints;

  void Start(){
    InvokeRepeating("Spawn", spawnTime, spawnTime);
  }


  void Spawn(){
    if(playerHealth.currentHealth <= 0f){
      return;
    }
    int spawnPointsIndex = Random.Range(0, spawnPoints.Length);
    Instantiate(enemy, spawnPoints[spawnPointsIndex].position, spawnPoints[spawnPointsIndex].rotation);
  }
}

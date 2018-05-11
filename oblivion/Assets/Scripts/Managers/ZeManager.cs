using UnityEngine;
using System.Collections.Generic;

public class ZeManager : MonoBehaviour{
  public Animator anim;
  public PlayerHealth playerHealth;
  public GameObject enemy;
  public Transform[] spawnPoints;
  private List<GameObject> zeCounter = new List<GameObject>();

  private float timeToWake = 10f;
  private float timer;
  private int one = 10;
  private int two = 10;
  private int three = 10;
  private int four = 10;

  void Start(){
    Invoke("Spawn", 2);
  }

  void Update(){
    timer += Time.deltaTime;
    if(timer >= timeToWake)
      enemyCounter();
  }

  void Spawn(){
    int i = 0;
    //for(int i = 0; i < 4; i++){
    while(i < 4){
      int spawnPointsIndex = Random.Range(0, spawnPoints.Length);
      if(spawnPointsIndex == one || spawnPointsIndex == two || spawnPointsIndex == three || spawnPointsIndex == four){
        continue;
      }
      // Creamos el objeto
      GameObject zeEnemy = (GameObject)Instantiate(enemy, spawnPoints[spawnPointsIndex].position, spawnPoints[spawnPointsIndex].rotation);
      zeCounter.Add(zeEnemy);
      i++;
      if(one == 10){
        one = spawnPointsIndex;
        continue;
      }
      if(two == 10){
        two = spawnPointsIndex;
        continue;
      }
      if(three == 10){
        three = spawnPointsIndex;
        continue;
      }
      if(four == 10){
        four = spawnPointsIndex;
        continue;
      }
    } // while
  } // Spawn

  void enemyCounter(){
    timer = 0f;
    for(int i = 0; i < zeCounter.Count; i++){
        GameObject zeEnemy = zeCounter[i];
        if(zeEnemy == null){
          zeCounter.Remove(zeEnemy);
        }
    }

    if(zeCounter.Count == 0){
      gameFinish();
      Destroy(gameObject);
    }
  }

  void gameFinish(){
    GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
    for(int i = 0; i < enemy.Length; i++){
			Destroy(enemy[i]);
		}
    anim.SetTrigger("GameFinished");
  }
}

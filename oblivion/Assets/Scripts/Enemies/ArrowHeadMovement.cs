using UnityEngine;
using System.Collections;

public class ArrowHeadMovement : MonoBehaviour{
  Transform player;
  Transform detectorTransform;
  PlayerHealth playerHealth;
  EnemyHealth enemyHealth;
  public GameObject detector;
  GameObject Detector;
  int speed = 2000;
  float timer = 3f;
  float timeBetweenChases = 3;
  int i = 0;

  void Awake(){
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }

  void OnCollisionEnter2D(Collision2D detect){
    if(detect.gameObject.tag == "ArrowHeadDetector"){
      StartCoroutine(waiter());
    }
  }

  void Update(){
    if(Detector == null){
      Detector = (GameObject)Instantiate(detector, player.position, Quaternion.identity);
    }
    detectorTransform = Detector.transform;
    chase(detectorTransform.position - transform.position);
  }

  IEnumerator waiter(){
    Debug.Log("mierda");
    yield return new WaitForSecondsRealtime(3);
    Debug.Log("Cacota");
  }

  void chase(Vector3 direction){
    float step = speed * Time.deltaTime;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
    transform.Translate(Vector3.up * Time.deltaTime * speed);
  }
}

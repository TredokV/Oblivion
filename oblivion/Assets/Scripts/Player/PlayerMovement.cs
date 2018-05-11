using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public float speed;
    private Rigidbody2D rb2d;
    private Transform rotationPlayer;
    Vector2 movement;
    Vector3 rotation;

    void Start(){
      rb2d = GetComponent<Rigidbody2D>();
      rotationPlayer = GetComponent<Transform>();
    }

    void FixedUpdate(){
      float h = Input.GetAxis("Horizontal");
      float v = Input.GetAxis("Vertical");
      Move(h, v);
      Turning(h, v);
    }

    void Turning(float h, float v){

       if(h != 0 || v != 0){
         Vector2 moveDirection = new Vector2(h, v);
         float angle = Mathf.Atan2(-h,v) * Mathf.Rad2Deg;
         rotationPlayer.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       }
    }

    void Move(float h, float v){
      Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
      rb2d.velocity = movement * speed;
    }
}

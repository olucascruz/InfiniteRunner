using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    private GameController gc;
    private Vector2 initialLocal;
    public float distance;
    public Transform point1;
    public Transform detectorEnemy;
    public LayerMask layer;
    private bool detectPlayer;
    private bool isInChaseRange;
    public float checkRadius;

    void Start()
    {
         rb = this.GetComponent<Rigidbody2D>();
         gc = GameController.gc;
         initialLocal = transform.position;

    }

    void Update(){
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, layer);
        detectPlayer = Physics2D.Linecast(point1.position, detectorEnemy.position, layer);
    }

    void FixedUpdate()
    {
        
        Move();
        
    }

    void Move(){
        if(detectPlayer || isInChaseRange){
            rb.velocity = new Vector2(speed*(-1), rb.velocity.y);
        }else{
            rb.velocity = new Vector2(speed*(0.2f), rb.velocity.y);
        }
    }

    void Dead(){
        rb.AddForce(new Vector2(0f, 30f), ForceMode2D.Impulse);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Player.isBig)
        {
            Dead();
            gc.AddScore();
        }

    }
    
}

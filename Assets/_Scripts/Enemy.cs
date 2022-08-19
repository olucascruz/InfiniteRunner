using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    private GameController gc;
    private Vector2 initialLocal;
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


    void FixedUpdate()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, layer);
        Move();
        
    }

    void Move(){
            rb.velocity = new Vector2(speed, rb.velocity.y);
       
    }

    void Dead(){
        rb.AddForce(new Vector2(0f, 30f), ForceMode2D.Impulse);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Player.isBig)
        {
            Dead();
        }

    }
    
}

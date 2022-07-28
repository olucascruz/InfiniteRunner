using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
         rb = this.GetComponent<Rigidbody2D>();
         gc = GameController.gc; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    void move(){
        float mH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void dead(){
        rb.AddForce(new Vector2(0f, 30f), ForceMode2D.Impulse);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9 && Player.isBig)
        {
            dead();
            gc.addScore();
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
           if(collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}

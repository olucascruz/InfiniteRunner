using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
   
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isJumping;
    private GameController gc;
    public static bool isBig = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        gc = GameController.gc; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        if(gc.qntBanana == 5){
            anim.SetBool("BigProta", true);
            isBig = true;
            Invoke("returnNormal", 5f);
        }
    }

    public void jump(){
        if(!isJumping && !isBig){
            isJumping = true;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }

    void move(){
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
        if(collision.gameObject.layer == 7 && !isBig)
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    void returnNormal(){
        anim.SetBool("BigProta", false);
        isBig = false;
    }
}

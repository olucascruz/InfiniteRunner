using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
   
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private Animator anim;
    public bool isJumping;
    private GameController gc;
    public static bool isBig = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        gc = GameController.gc; 
    }

    void Update(){

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if(gc.qntBanana == 5){
            anim.SetBool("BigProta", true);
            isBig = true;
            Invoke("ReturnNormal", 5f);
        }
    }

    public void Jump(){
        
        if(!isJumping && !isBig){
            isJumping = true;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }

    

    void Move(){
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
        if(collision.gameObject.tag == "Enemy"  && !isBig)
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    void ReturnNormal(){
        anim.SetBool("BigProta", false);
        isBig = false;
    }
}

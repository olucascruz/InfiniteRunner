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
    private bool isOnFloor = true;
    private GameController gc;
    public static bool isBig = false;
    public LayerMask layer;
    public float distanceFloor = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        gc = GameController.gc; 
    }

    void Update(){
        if(gc.qntBanana == 5){
            anim.SetBool("BigProta", true);
            isBig = true;
            Invoke("ReturnNormal", 5f);
        }
    }

   
    void FixedUpdate()
    {
        Move();

        isOnFloor = Physics2D.Raycast(transform.position, Vector2.down, distanceFloor, layer);
        
    }

    public void Jump(){
        
        if(isOnFloor && !isBig){
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

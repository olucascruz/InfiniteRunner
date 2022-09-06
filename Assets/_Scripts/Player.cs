using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private JumpForce jumpForce;
    [SerializeField]
    private LayerMask layer;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isOnFloor = true;
    public static bool isBig = false;
    public float distanceFloor = 1;
    private GameController gc;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        gc = GameController.gc; 
    }

    void Update(){
        if(gc.GetQntBanana() == 5){
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
        float jump = jumpForce.value * 4f;
        if(isOnFloor && !isBig && jump > 1f){
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
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

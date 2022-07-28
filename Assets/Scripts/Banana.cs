using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
         gc = GameController.gc;  
    }

     void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
            gc.addScore();
            gc.addBanana();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{ 
    [SerializeField]
    private GameObject positionPlayer;
    private GameController gc;


    // Start is called before the first frame update
    void Start()
    {
         gc = GameController.gc;
         positionPlayer = GameObject.FindGameObjectWithTag("Player");

    }


    void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            gc.AddBanana();
            Invoke("ReturnBanana", 2f);
        }
    }

    void ReturnBanana(){
        gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private GameController gc;
    public GameObject positionPlayer;
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
            gc.AddScore();
            gc.AddBanana();
        }
    }
}
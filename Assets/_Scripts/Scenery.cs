using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{   
    [SerializeField]
    private GameObject Banana;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject floor;


    // Update is called once per frame
    void FixedUpdate()
    {
        moveScenery();
        if (transform.position.x < -10){
            int isBanana = Random.Range(0, 3);


            if(isBanana > 0){
                Banana.SetActive(true);
            }else{
                Banana.SetActive(false);
            }
        }
    }


    void moveScenery(){
        transform.Translate(Vector2.left*Time.deltaTime);
         if (transform.position.x < -10) {
            transform.position = new Vector2(
                transform.position.x + 20,
                transform.position.y
            );
         }
    }
}

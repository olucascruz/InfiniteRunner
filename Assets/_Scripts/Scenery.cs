using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{   
    public GameObject Banana;
    public Transform player;
    public GameObject floor;

    // Update is called once per frame
    void Update()
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

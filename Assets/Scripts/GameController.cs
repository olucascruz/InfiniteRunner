using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform player; 
    public Transform cam;
    public GameObject floor;
    public GameObject floor_ground;
    public GameObject banana;
    public GameObject enemy;
    public Text scoreText;
    public int score = 0;
    public Text qntBananaText;
    public int qntBanana = 0;
    public static GameController gc;


    // Update is called once per frame
     void Awake()
    {   
        if(gc == null)
        {
            gc = this;
        }
        else if(gc != this)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        moveCam();
        if(player.localPosition.x > floor.transform.position.x + 1f){
            createGround();
            int isBanana = Random.Range(0, 3);
            int isEnemy = Random.Range(0, 3);
            
            if(isBanana >= 1 && !Player.isBig){
                createBanana();
            }

            if(isEnemy >= 1){
                createEnemy();
            }
        }

        RefreshScreen();
        
        if(qntBanana == 5 && !Player.isBig){
            Invoke("zered", 0.2f);
        }
    }

    void zered(){
        qntBanana = 0;
    }

    void moveCam(){
        cam.localPosition = new Vector3(player.localPosition.x+0.5f, 
                                        cam.localPosition.y, 
                                        cam.localPosition.z);
    }
    
    void createGround(){
         GameObject ground = Instantiate(floor);
         Destroy(floor);
         floor = ground;
         GameObject ground1 = Instantiate(floor_ground);
         Destroy(floor_ground);
         floor_ground = ground1;
         ground.transform.position = new Vector3(    
                        floor.transform.position.x+4f,
                        floor.transform.position.y,
                        floor.transform.position.z);
         ground1.transform.position = new Vector3(    
                        floor_ground.transform.position.x+4f,
                        floor_ground.transform.position.y,
                        floor_ground.transform.position.z);
    }

    void createBanana(){
        GameObject newBanana = Instantiate(banana);
        newBanana.transform.position = new Vector3(    
                        floor.transform.position.x+4f,
                        floor.transform.position.y+0.25f,
                        floor.transform.position.z);
    }

    void createEnemy(){
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = new Vector3(    
                        floor.transform.position.x+4f,
                        floor.transform.position.y+0.5f,
                        floor.transform.position.z);
    }


    public void RefreshScreen()
    {
        scoreText.text = score.ToString();
        qntBananaText.text = qntBanana.ToString();
    }

    public void addScore(){
        score = score + 5;
    }
    public void addBanana(){
        qntBanana++;
    }
}

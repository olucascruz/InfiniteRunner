using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
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
        RefreshScreen();
        
        if(qntBanana == 5 && !Player.isBig){
            Invoke("Zered", 0.2f);
        }
    }

    void Zered(){
        qntBanana = 0;
    }


    public void RefreshScreen()
    {
        scoreText.text = score.ToString();
        qntBananaText.text = qntBanana.ToString();
    }

    public void AddScore(){
        score = score + 5;
    }
    public void AddBanana(){
        qntBanana++;
    }
}

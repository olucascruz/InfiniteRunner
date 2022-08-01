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
    public Image I_jumpForce;
    public Button JumpButton;
    private bool ButtonUpPress;
    
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

    void Start(){
        I_jumpForce.fillAmount = 0;
        JumpButton.onClick.AddListener(OnGUI);
    }
    
    void Update()
    {
        if(ButtonUpPress){
            I_jumpForce.fillAmount = I_jumpForce.fillAmount + 0.01f;
            if(I_jumpForce.fillAmount == 1){
                I_jumpForce.fillAmount = 0;
            }   
        }else{
            I_jumpForce.fillAmount = 0;
        }
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

    public void OnGUI(){

        
        if (Event.current.type == EventType.MouseDown)
        {
            ButtonUpPress = true;
        }

        if (Event.current.type == EventType.MouseUp)
        {
           ButtonUpPress = false;
        }

    }

}

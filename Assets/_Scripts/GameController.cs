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
    public JumpForce F_jumpForce;
    private bool add_jumpForce = true;
    
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
        F_jumpForce.value = 0;
        I_jumpForce.fillAmount = 0;
        JumpButton.onClick.AddListener(OnGUI);
    }
    
    void Update()
    {

        I_jumpForce.fillAmount = F_jumpForce.value;
        if(F_jumpForce.value > 1){
            F_jumpForce.value = 1;
            Invoke("DownJumpBar", 0.2f);
        }
        else if(F_jumpForce.value < 0){
            add_jumpForce = true;
        }
        if(ButtonUpPress){
            if(add_jumpForce){
            F_jumpForce.value = F_jumpForce.value + 0.02f;
            }
            else{
                F_jumpForce.value = F_jumpForce.value - 0.02f;
            }    
        }else{
            F_jumpForce.value = 0;
        }
        RefreshScreen();
        
        if(qntBanana == 5 && Player.isBig){
            Invoke("Zered", 0.2f);
        }
    }

    void DownJumpBar(){
        add_jumpForce = false;
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
        Event m_Event = Event.current;
        
        if (m_Event.type == EventType.MouseDown)
        {
            ButtonUpPress = true;
        }

        if (m_Event.type == EventType.MouseUp)
        {
           ButtonUpPress = false;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private float multiplyScore;
    private float score = 0;
    [SerializeField]
    private Text qntBananaText;
    [SerializeField]
    private Image I_jumpForce;
    [SerializeField]
    private Button JumpButton;
    [SerializeField]
    private JumpForce F_jumpForce;
    [SerializeField]
    private int qntBanana = 0;
    private bool ButtonUpPress;
    private bool add_jumpForce = true;
    public static GameController gc;

    
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
        SetScore(Time.deltaTime * multiplyScore);
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
        scoreText.text = $"Score: {Mathf.FloorToInt(score)}";
        qntBananaText.text = qntBanana.ToString();
    }


    public void SetScore(float _score){
        this.score += _score;
    }


    public void AddBanana(){
        qntBanana++;
    }


    public void OnGUI(){
        Event m_Event = Event.current;
        Debug.Log(m_Event);
        
        
        if (m_Event.type == EventType.MouseDown)
        {
            ButtonUpPress = true;
        }

        if (m_Event.type == EventType.MouseUp)
        {
           ButtonUpPress = false;
        }

    }

    public int GetQntBanana(){
        return qntBanana;
    }

}

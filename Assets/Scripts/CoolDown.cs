using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class CoolDown : MonoBehaviour
{

    [SerializeField] float timer=5;
    public Button btn;
    bool isPressed = false;
    public TMP_Text btn_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        btn.onClick.AddListener(coolDownTimer);
        if (isPressed) { 
            if(timer > 0)
            {
                timer-=Time.deltaTime;
                btn.interactable = false;
                btn_text.text = timer.ToString("F0");
            }
            else {
                timer = 5;
                isPressed = false;
                btn.interactable = true;
                btn_text.text = "Football";
            }
        }
    }
    void coolDownTimer()
    {
        isPressed = true;
    }
}

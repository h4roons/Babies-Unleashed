using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class CoolDown : MonoBehaviour
{
    [SerializeField] float timer;
    public Button btn;
    bool isPressed = false;
    public TMP_Text btn_text;
    string original_text;
    float original_timer;
    // Start is called before the first frame update
    void Start()
    {
        
        original_text = btn_text.text;
        original_timer = timer; 
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
                timer = original_timer;
                isPressed = false;
                btn.interactable = true;
                btn_text.text = original_text;
            }
        }
    }
    void coolDownTimer()
    {
        isPressed = true;
    }
}

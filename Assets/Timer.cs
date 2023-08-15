using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float timer;
    public TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            
            timerText.text = timer.ToString("F0");
        }
        else {
            Debug.Log("Timer Completed");
        }
    }
}

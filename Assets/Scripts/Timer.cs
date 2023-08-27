using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float timer=1f;

    bool startTimer=false;

    public TMP_Text timerText;

    public Canvas WinScreen;

    public Canvas GameUII;

    public AudioSource bgm;

    public AudioSource levelcomplete;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        bgm.gameObject.SetActive(true);
        GameUII.gameObject.SetActive(true);
        levelcomplete.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && startTimer)
        {
            timer -= Time.deltaTime;
            
            timerText.text = timer.ToString("F0");
        }
        else if (!startTimer)
        {
            Debug.Log("Rest State");
        }
        else
        {
            levelcomplete.gameObject.SetActive(true);
            bgm.gameObject.SetActive(false);
            GameUII.gameObject.SetActive(false);
            Time.timeScale = 0f;
            WinScreen.gameObject.SetActive(true);
            Debug.Log("Timer Completed");
        }
    }
    public void beginTimer() { 
        startTimer = true;  
    }
}

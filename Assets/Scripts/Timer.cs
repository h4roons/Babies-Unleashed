using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float timer;
    public TMP_Text timerText;

    public Canvas WinScreen;

    public Canvas GameUII;

    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        bgm.gameObject.SetActive(true);
        GameUII.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            
            timerText.text = timer.ToString("F0");
        }
        else
        {
            bgm.gameObject.SetActive(false);
            
            GameUII.gameObject.SetActive(false);
            Time.timeScale = 0f;
            WinScreen.gameObject.SetActive(true);
            
            Debug.Log("Timer Completed");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{

    public Canvas GameUii;

    public Canvas LoseScreen;

    public AudioSource bgm;

    public AudioSource levelFailMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetType() == typeof(BoxCollider)) { 
            if (other.CompareTag("Player"))
            {
                
                bgm.gameObject.SetActive(false);
                levelFailMusic.gameObject.SetActive(true);
                GameUii.gameObject.SetActive(false);
                Time.timeScale = 0f;
                LoseScreen.gameObject.SetActive(true);
                
            }
        }
    }
}

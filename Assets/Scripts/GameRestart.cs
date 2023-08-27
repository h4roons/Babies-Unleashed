using UnityEngine;
using TMPro;
public class GameRestart : MonoBehaviour
{

    public Canvas GameUii;

    public Canvas LoseScreen;

    public AudioSource bgm;

    public AudioSource levelFailMusic;
    [SerializeField] TMP_Text loseTimerText;
    bool loseTimer = false;
    [SerializeField] Animator animator;
  
    [SerializeField] float t;

    void Update()
    {
        if (loseTimer)
        {
            loseTimerText.gameObject.SetActive(true);
            if (t >= 0)
            {
                t -= Time.deltaTime * 8;
                if (t <= 20)
                {
                    
                    animator.speed = 1.5f;
                }
                DisplayTIime(t);
            }
            else
            {
                Restart();
            }
        }
        else
        {

            // loseTimerGO.gameObject.SetActive(false);
        }
    }
    void DisplayTIime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float min = Mathf.FloorToInt(timeToDisplay / 60);
        float secs = Mathf.FloorToInt(timeToDisplay % 60);

        loseTimerText.text = string.Format("{0:00} : {1:00} ", min, secs);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetType() == typeof(BoxCollider)) { 
            if (other.CompareTag("Player"))
            {
                loseTimer = true;

               
            }
           
        }
    }
    private void OnTriggerExit(Collider other) {
        loseTimer = false;
    }

    private void Restart()
    {
        bgm.gameObject.SetActive(false);
        levelFailMusic.gameObject.SetActive(true);
        GameUii.gameObject.SetActive(false);
        Time.timeScale = 0f;
        LoseScreen.gameObject.SetActive(true);
    }
}

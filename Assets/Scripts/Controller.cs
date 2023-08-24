using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class Controller : MonoBehaviour
{
    public LayerMask layerMask;
    [SerializeField] GameObject danger;
    NavMeshAgent player;
    private Transform obstacletransf;
    private float ObstacleCurrentTime;
    private float obstacleReqTime;
    bool babyLocked=false;
    // Start is called before the first frame update
    public void Run()
    {
        player = GetComponent<NavMeshAgent>();

        player.SetDestination(danger.transform.position);
        GetComponent<Animator>().SetTrigger("Run");



    }

    public void SetObstacleNull()
    {
        Debug.Log("Set Obstacle Null");
        Search();
        GetComponent<Animator>().SetBool("isPlaying", false);
        babyLocked = false;
        Destroy(obstacletransf.gameObject);
        player.SetDestination(danger.transform.position);

    }
    public void Search()
    {

        Debug.Log("Search called");


        Transform obstacle;
        if (obstacletransf == null)
        {
            RaycastHit hit;


            float distanceToObstacle = 0;

            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 10, layerMask))
            {
                distanceToObstacle = hit.distance;
                Debug.Log(hit.transform.name);
                Debug.Log("Obstacle detected");
                obstacle = hit.collider.transform;
                obstacleReqTime = obstacle.GetComponent<Obstacle>().obstacleTime;
                ObstacleCurrentTime = 0f;
                player.SetDestination(obstacle.position);
            }
        }

        // Cast a sphere wrapping character controller 10 meters forward

        // to see if it is about to hit anything.






        else
        {
            float dist = Vector3.Distance(player.transform.position, obstacletransf.position);

            if (dist <= (player.stoppingDistance + 1f))
            {
                if (ObstacleCurrentTime < obstacleReqTime)
                {
                    ObstacleCurrentTime += Time.deltaTime;

                }
                else
                {

                    Debug.Log(dist);
                    Debug.Log("Obstacle Reached");
                    obstacletransf.gameObject.SetActive(false);
                    obstacle = null;
                    player.SetDestination(danger.transform.position);
                    ObstacleCurrentTime = 0f;
                    obstacleReqTime = 0f;


                }

            }
        }

    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color=Color.red;
    //     Gizmos.DrawSphere(transform.position,0.5f);
    // }
    public SpriteRenderer[] thought;
    Color thoughtColor;
    bool thoughtOut = false;
    bool thoughtIn = false;
    LineRenderer lineRenderer;
    float t = 0f;
    Vector3 targetPos;
    private void Start()
    {
        StartCoroutine(Restless());
        lineRenderer = GetComponent<LineRenderer>();
        targetPos = danger.transform.position;
    }

    void Update()
    {

        //Line Renderer Stuff
        lineRenderer.positionCount = 2;

        t += Time.deltaTime / 2;
        t = Mathf.Clamp01(t);
        Vector3 target = Vector3.Lerp(transform.position, targetPos, t);
        
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, target);

        if (thoughtIn)
        {
            for (int i = 0; i < thought.Length; i++)
            {
                // Get the current color of the sprite
                Color currentColor = thought[i].color;

                if (currentColor.a < 1)
                {
                    // Set the new alpha value
                    Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, currentColor.a += Time.deltaTime / .6f);

                    // Assign the new color with modified alpha back to the sprite renderer
                    thought[i].color = newColor;

                    if (thoughtColor.a >= 1)
                    {
                        thoughtIn = false;
                    }
                }
            }

        }

        if (thoughtOut)
        {
            for (int i = 0; i < thought.Length; i++)
            {
                // Get the current color of the sprite
                Color currentColor = thought[i].color;

                if (currentColor.a > 0)
                {
                    // Set the new alpha value
                    Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, currentColor.a -= Time.deltaTime / .6f);

                    // Assign the new color with modified alpha back to the sprite renderer
                    thought[i].color = newColor;

                    if (thoughtColor.a <= 0)
                    {
                        thoughtIn = false;
                    }
                }
            }

        }

        // 
        // newAlpha.a = 1;
        // thought.color = Color.Lerp(thought.color, newAlpha, .02f);
        //    while(newAlpha.a != 1)
        //    {

        //    }


        // Update is called once per frame




    }
    IEnumerator Restless()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1, 10));
        // Debug.Log("ji");
        GetComponent<Animator>().SetTrigger("Kera");
        yield return new WaitForSeconds(.7f);

        
        lineRenderer.enabled = true;

        thoughtIn = true;
        yield return new WaitForSeconds(2);
        thoughtOut = true;
    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.transform.name + " LMAO");
        if (other.transform.CompareTag("Distraction") && other.GetComponent<Obstacle>().locked==false && babyLocked==false && GetComponent<Animator>().GetBool("isPlaying")==false)
        {
            Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
            obstacletransf = other.transform;
            babyLocked = true;
            other.GetComponent<Obstacle>().locked =true;
            player.SetDestination(other.transform.position);
           
            if (obstacle != null)
            {
                GetComponent<Animator>().SetBool("isPlaying", true);
                //yield return new WaitForSeconds(obstacle.obstacleTime);
                //Search();
                //SetObstacleNull();
            }
            
        }
        else
        {

        }
    }



}

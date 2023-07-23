using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{   
    public LayerMask layerMask;
    [SerializeField] GameObject enemy;
    [SerializeField] NavMeshAgent player;
    [SerializeField] private GameObject distraction;
    private Transform obstacle;
    private float ObstacleCurrentTime;

    private float obstacleReqTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<NavMeshAgent>();
        player.SetDestination(enemy.transform.position);
    }
    public void Search()
    {
        
       
        
        RaycastHit hit;

        
        float distanceToObstacle = 0;
        
        // Cast a sphere wrapping character controller 10 meters forward
        
        // to see if it is about to hit anything.
        if(obstacle == null)
        {
            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 10,layerMask))
        {
            distanceToObstacle = hit.distance;
            Debug.Log("Obstacle detected");
            obstacle = hit.collider.transform;
            obstacleReqTime = obstacle.GetComponent<Obstacle>().obstacleTime;
            ObstacleCurrentTime = 0f;
            player.SetDestination(obstacle.position);
        }
            
        }
        else
        {
            float dist = Vector3.Distance(player.transform.position, obstacle.position);
            
            if(dist<=(player.stoppingDistance+1f))
            {
                if (ObstacleCurrentTime < obstacleReqTime)
                {
                    ObstacleCurrentTime += Time.deltaTime;

                }
                else
                {
                    
                    Debug.Log(dist);
                    Debug.Log("Obstacle Reached");
                    obstacle.gameObject.SetActive(false);
                    obstacle = null;
                    player.SetDestination(enemy.transform.position);
                    ObstacleCurrentTime = 0f;
                    obstacleReqTime = 0f;

                }
                
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        Search();
    }

    
    
}

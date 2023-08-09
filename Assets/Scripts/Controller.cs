using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public LayerMask layerMask;
    [SerializeField] GameObject enemy;
    [SerializeField] NavMeshAgent player;
    private Transform obstacle;
    private float ObstacleCurrentTime;
    private float obstacleReqTime;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<NavMeshAgent>();
        player.SetDestination(enemy.transform.position);
        
    }

    private void OnEnable()
    {
        // Messenger.AddListener(GameEvent.obstacleInstantiated,Sarch);
         
    }

    private void OnDisable()
    {
        // Messenger.RemoveListener(GameEvent.obstacleInstantiated,Sarch);
         
    }

    public void Search()
    {
        Debug.Log("Search called");



        if (obstacle == null)
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
            float dist = Vector3.Distance(player.transform.position, obstacle.position);

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
                    obstacle.gameObject.SetActive(false);
                    obstacle = null;
                    player.SetDestination(enemy.transform.position);
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

    void Sarch()
    {
        

        // Update is called once per frame
        



    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log(other.transform.name + " LMAO");
        if (other.transform.tag == "Distraction")
        {

            obstacle = other.transform;
            player.SetDestination(other.transform.position);
            Search();
            Invoke("SetObstacleNull",10f);

        }
        else {
            Debug.Log("Game Finished");
        }
    }
    
    void SetObstacleNull()
    {
       
        Destroy(obstacle.gameObject);
        player.SetDestination(enemy.transform.position);

    }
    void Update()
    {
       

    }
}

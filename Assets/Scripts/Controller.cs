using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] NavMeshAgent player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        player.SetDestination(enemy.transform.position);
    }
}

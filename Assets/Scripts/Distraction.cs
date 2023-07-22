using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Distraction : MonoBehaviour
{
    [SerializeField] NavMeshAgent player;
    // Start is called before the first frame update
    void Start()
    {
        player= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }
}

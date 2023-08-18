using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubixManager : MonoBehaviour
{
    [SerializeField] GameObject touchManager;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void createObstactle()
    {
       
        
        touchManager.SetActive(true);
    }
}

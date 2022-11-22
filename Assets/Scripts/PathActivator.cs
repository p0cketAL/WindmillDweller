using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathActivator : MonoBehaviour
{
    public Transform cubePathActivator;
    public int pathIndex = 0;
    private bool isDone = false;
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(isDone == false){
            cubePathActivator.GetComponent<Walkable>().possiblePaths[pathIndex].active = true;
            isDone = true;
        }
    }
}

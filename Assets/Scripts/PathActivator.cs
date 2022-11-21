using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathActivator : MonoBehaviour
{
    public Transform cubePathActivator;
    public int pathIndex = 0;
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        cubePathActivator.GetComponent<Walkable>().possiblePaths[pathIndex].active = true;
    }
}

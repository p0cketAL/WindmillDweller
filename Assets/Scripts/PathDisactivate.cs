using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDisactivate : MonoBehaviour
{
    public List<Transform> keyCubes = new List<Transform>();
   
    private PlayerControll status;
    private int currentIndex = 0;


    private void OnTriggerEnter(Collider other) {
        keyCubes[currentIndex].GetComponent<Walkable>().possiblePaths[0].active = false;
        currentIndex += 1;
    }
}
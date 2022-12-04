using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePivot : MonoBehaviour
{
    public Transform pivot;
    public Transform cubeWithButton;

    public int pathIndex = 0;
    private bool hasRotated = false;
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {

        if (hasRotated == false)
        {
            pivot.transform.Rotate(0.0f, 0.0f, 270.0f, Space.Self);
            cubeWithButton.GetComponent<Walkable>().possiblePaths[pathIndex].active = true;
            hasRotated = true;
        }

    }
}

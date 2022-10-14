using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePivot : MonoBehaviour
{
    public Transform pivot;
    public Transform cubeWithButton;
    public int pathIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        pivot.transform.Rotate(270.0f, 0.0f, 0.0f, Space.Self);
        cubeWithButton.GetComponent<Walkable>().possiblePaths[pathIndex].active = true;
    }
}

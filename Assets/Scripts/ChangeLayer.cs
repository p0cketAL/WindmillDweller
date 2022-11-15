using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    private GameObject character;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerStay(Collider other) {
        character = GameObject.FindGameObjectWithTag("Player");
        int LayerTopLayer = LayerMask.NameToLayer("Top Layer");
        character.layer = LayerTopLayer;
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForward : MonoBehaviour
{
    private PlayerControll c; 
    public Transform character;
    private float rotationSpeed = 7f;
    private Transform normal;
    private Transform result;



    void Update () {
        c = GetComponent<PlayerControll>();
        
        if (c.finalPath.Count > 0 && c.finalPath[0] != null){
            result.position = Vector3.ProjectOnPlane(character.position, normal.forward);
            //character.transform.position = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(c.finalPath[0].position - character.transform.position), rotationSpeed * Time.deltaTime);
            
            //character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(c.finalPath[0].position - character.transform.position), rotationSpeed * Time.deltaTime);
        }
    }
}

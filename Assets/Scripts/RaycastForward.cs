using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RaycastForward : MonoBehaviour
{
    private PlayerControll c; 
    public Transform character;
    private float rotationSpeed = 7f;
    private Transform normal;
    private Transform result;

    public float rotationTime = 0.5f;
    Coroutine rotationCoroutine;
    bool rotationOn = false;
    Sequence mySequence;


    void Update () {
        c = GetComponent<PlayerControll>();
        
        if (c.finalPath.Count > 0 && c.finalPath[0] != null){
            if(!rotationOn){
                rotationCoroutine = StartCoroutine(Rotation()); 
            }    
        }
    }

    IEnumerator Rotation(){

        for (int i = c.finalPath.Count - 1; i > 0; i--){
            rotationOn = true;
            Quaternion start = transform.rotation;
            Vector3 direction = (c.finalPath[0].position - transform.position).normalized;
            Quaternion end = Quaternion.LookRotation(direction);
            Debug.DrawRay( transform.position, direction * 100, Color.cyan, 10);
            float chrono = 0f;
            float ratio = 0f;
            mySequence.Append(transform.DOLookAt(c.finalPath[i].position, .1f, AxisConstraint.Y, Vector3.up));

            while(ratio < 1f){
                chrono += Time.deltaTime;
                ratio = chrono/ rotationTime;
                transform.rotation = Quaternion.Slerp(start, end, ratio);
                yield return null;
            }
        }
        rotationOn = false;
    }
}

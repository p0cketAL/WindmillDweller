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

    public float maxSlopeAngle;
    private RaycastHit slopeHit;

    public float rotationTime = 0.5f;
    Coroutine rotationCoroutine;
    bool rotationOn = false;
    Sequence mySequence;
    public Vector3 direction;


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
            //Vector3 direction = (c.finalPath[0].position - transform.position).normalized;
            direction = (c.clickedCube.position - transform.position).normalized;

            Quaternion end = Quaternion.LookRotation(direction);
            //Debug.DrawRay( transform.position, direction * 100, Color.cyan, 10);
            float chrono = 0f;
            float ratio = 0f;
            //mySequence.Append(transform.DOLookAt(c.finalPath[i].position, .1f, AxisConstraint.Y, Vector3.up));

            while(ratio < 1f){
                chrono += Time.deltaTime;
                ratio = chrono/ rotationTime;
                transform.rotation = Quaternion.Slerp(start, end, ratio);
                yield return null;
            }
        }
        rotationOn = false;
    }
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal);
    }
}

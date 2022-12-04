using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeConstraintAxis : MonoBehaviour
{
    Move move;
    
    void Awake()
    {
        move = GameObject.Find("Owl").GetComponent<Move>();
    }
   
    // Update is called once per frame
    void Update()
    {
        Debug.Log(move.constraint);
    }

    private void OnTriggerEnter(Collider other)
    {
        move.constraint = DG.Tweening.AxisConstraint.X;
    }

}

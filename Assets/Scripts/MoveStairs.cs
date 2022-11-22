using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveStairs : MonoBehaviour
{
    public Transform movingStair;
    public float animDuration;
    public Ease animEase;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        moveStaircase();
    }
    private void moveStaircase() {
        movingStair
            .DOMoveY(7f,animDuration)
            //.SetEase(animEase)
            .SetDelay (1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Reveal : MonoBehaviour
{
    public Transform maskCube;
    public float animDuration;
    public Ease animEase;
    
    void Start()
    {
        maskCube
            .DOMoveY (-2f, animDuration)
            .SetEase (animEase);   
    }
}

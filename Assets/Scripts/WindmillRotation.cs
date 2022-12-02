using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WindmillRotation : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 0f, 100f) * Time.deltaTime);
       
    }
   
    //With Coroutine
    //IEnumerator spin()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(0f);
    //        float timer = 0f;
    //        Quaternion lastRotation = transform.rotation;
    //        while (timer < 1)
    //        {
    //            transform.Rotate(0, 0,  60 * Time.deltaTime);
    //            timer = timer + Time.deltaTime;
    //            yield return null;
    //        }
    //        transform.rotation = lastRotation;
    //        transform.Rotate(0, 0, 60);
    //    }
    //}

    //void Start()
    //{
    //    StartCoroutine(spin());
    //}
    
    //with DOTween
    //void Start()
    //{
    //    transform.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Unset);
    //}

}

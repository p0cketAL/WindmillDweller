using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerControll player;
    public List<Transform> pivots;
    public int  index = 0;



    void Awake()
    {
        instance = this;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int multiplier = Input.GetKey(KeyCode.RightArrow) ? 1 : -1;
            pivots[index].DORotate(new Vector3(0, 0, 90 * multiplier), .6f, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
        }
    }
}
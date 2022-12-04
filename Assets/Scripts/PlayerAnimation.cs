using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public PlayerControll player;

     void Start()
     {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerControll>();
     }

    void Update()
    {
        if (player.walking == true)
        {
            animator.SetBool("IsWalking", true);
        }
    }
}

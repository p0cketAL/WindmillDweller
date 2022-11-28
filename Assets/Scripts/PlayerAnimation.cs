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
        player.walking = false;
    }

    void Update()
    {
        if (player.walking == true)
            animator.SetBool("Walking", player.walking);
    }
}

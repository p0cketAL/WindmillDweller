using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


public class Move : MonoBehaviour
{
    private PlayerControll character;
    private Vector3 startPosition;
    private Vector3 endPosition;

    public float moveTime = 1f;

    public UnityEvent whenMove;

    public enum State {walk, stand}
    public State status = State.stand;
    public Quaternion currentRotation;
    public AxisConstraint constraint = AxisConstraint.Y;

    public Animator animator;


    public IEnumerator WalkingCharacter(List<Transform>finalPath)
    {
        finalPath.Reverse();
        
        foreach(Transform point in finalPath) {
            character.walking = true;

            startPosition = transform.position;

            endPosition = point.position + transform.up;

            float time = 0f;

            while(time < moveTime){

                Sequence mySequence = DOTween.Sequence();
                time += Time.deltaTime;

                float ratio = time/moveTime;

                transform.position = Vector3.Lerp(startPosition, endPosition, ratio);
                mySequence.Join(transform.DOLookAt(point.position, .1f, constraint, Vector3.up).SetLoops(1));
                character.walking = true;
                yield return null;
                character.walking = false;
            }
        }
    }

    void Start()
    {
        character = GetComponent<PlayerControll>();
        startPosition = character.currentCube.transform.position;
        endPosition = character.indicator.transform.position;
    }

    void Update() 
    {
        if (character.walking)
        {
            //animator.SetBool("IsWalking", true);
        }
        else
        {
            //animator.SetBool("IsWalking", false);
        }
    }
    public void WalkingNow(){
        StartCoroutine(WalkingCharacter(character.finalPath));
    }
}

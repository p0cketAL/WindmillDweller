using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Move : MonoBehaviour
{
    private PlayerControll character;
    private PlayerControll currentSpot;
    private Vector3 startPosition;
    private Vector3 endPosition;

    public float moveTime = 2f;

    public UnityEvent whenMove;


    public enum State {walk, stand}
    public State status = State.stand;

    IEnumerator WalkingCharacter(){
        status = State.walk;
        Vector3 startPosition = transform.position;
        float time = 0f;
        while(time < moveTime){
            time += Time.deltaTime;
            float ratio = time/moveTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, ratio); 
            yield return null;
        }
        transform.position = endPosition;
    }

    void Start()
    {
        character = GetComponent<PlayerControll>();
        startPosition = character.currentCube.transform.position;
        //endPosition = character.indicator.transform.position;
    }

    void Update() 
    {
        startPosition = character.currentCube.transform.position;
        endPosition = character.indicator.transform.position;
    }
    public void WalkingNow(){
        StartCoroutine(WalkingCharacter());       
    }
}

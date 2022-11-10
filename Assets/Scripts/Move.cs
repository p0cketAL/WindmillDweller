using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Move : MonoBehaviour
{
    private PlayerControll character;
    private Vector3 startPosition;
    private Vector3 endPosition;

    public float moveTime = 1f;

    public UnityEvent whenMove;


    public enum State {walk, stand}
    public State status = State.stand;

    IEnumerator WalkingCharacter(List<Transform>finalPath)
    {
        finalPath.Reverse();
        
        foreach(Transform point in finalPath) {
            
            startPosition = transform.position;

            endPosition = point.position + transform.up;

            float time = 0f;

            while(time < moveTime){

                time += Time.deltaTime;

                float ratio = time/moveTime;

                transform.position = Vector3.Lerp(startPosition, endPosition, ratio);

                yield return null;
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

    }
    public void WalkingNow(){
        StartCoroutine(WalkingCharacter(character.finalPath));       
    }

}

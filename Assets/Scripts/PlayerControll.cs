using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PlayerControll : MonoBehaviour
{
    public bool walking = false;

    public Transform currentCube;
    public Transform clickedCube;
    public Transform indicator;
    private Move move;
    

    public List<Transform> finalPath = new List<Transform>();


    void Start()
    {
        RayCastDown();
    }

    void Update()
    {
        // get current cube under the player with RayCast  
        RayCastDown();

        if (currentCube.GetComponent<Walkable>().movingGround || currentCube.GetComponent<Walkable>().needToParent)
        {
            transform.parent = currentCube;
        }
        else
        {
            transform.parent = null;
        }

        // click on the cube to move the player
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit mouseHit;

            if (Physics.Raycast(mouseRay, out mouseHit))
            {
                if (mouseHit.transform.GetComponent<Walkable>() != null)
                {
                    clickedCube = mouseHit.transform;
                    Debug.DrawRay(transform.position, transform.forward, Color.green);
                    finalPath.Clear();
                    FindPath();
                    indicator.position = mouseHit.transform.GetComponent<Walkable>().GetWalkPoint();

                }
            }
        }
    }

    void FindPath()
    {
        List<Transform> nextCubes = new List<Transform>();
        List<Transform> pastCubes = new List<Transform>();
        Clear();
        foreach (WalkPath path in currentCube.GetComponent<Walkable>().possiblePaths)
        {
            if (path.active)
            {
                nextCubes.Add(path.target);
                path.target.GetComponent<Walkable>().previousBlock = currentCube;
            }
        }

        pastCubes.Add(currentCube);
        Clear();
        ExploreCube(nextCubes, pastCubes);
        BuildPath();
    }

    public void RayCastDown()
    {
        Ray playerRayCast = new Ray(transform.position, -transform.up);

        RaycastHit playerHit;
      

        if (Physics.Raycast(playerRayCast, out playerHit))
        {
            if (playerHit.transform.GetComponent<Walkable>() != null)
            {
                currentCube = playerHit.transform;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Ray ray = new Ray(transform.position, -transform.up);
        Gizmos.DrawRay(ray);
    }
    void Clear()
    {
        foreach (Transform t in finalPath)
        {
            t.GetComponent<Walkable>().previousBlock = null;
        }
        finalPath.Clear();
        walking = false;
    }

    void ExploreCube(List<Transform> nextCubes, List<Transform> visitedCubes)
    {   
        Transform current = nextCubes.First();
        nextCubes.Remove(current);

        if (current == clickedCube)
        {
            return;
        }

        foreach (WalkPath path in current.GetComponent<Walkable>().possiblePaths)
        {
            if (!visitedCubes.Contains(path.target) && path.active)
            {
                nextCubes.Add(path.target);
                path.target.GetComponent<Walkable>().previousBlock = current;
            }
        }

        visitedCubes.Add(current);

        if (nextCubes.Any())
        {
            ExploreCube(nextCubes, visitedCubes);
        }
    }

    void BuildPath()
    {
        Transform cube = clickedCube;
        while ((cube != currentCube) && walking == false)
        {
            if (cube.GetComponent<Walkable>().previousBlock != null)
            {
                finalPath.Add(cube);
                cube = cube.GetComponent<Walkable>().previousBlock;
            }
            else
                return;
        }

        FollowPath();
    }

    void FollowPath()
    {  
        walking = true;
        move = GetComponent<Move>();
        move.WalkingNow();
    }   
}

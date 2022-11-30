using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkable : MonoBehaviour
{
    public List<WalkPath> possiblePaths = new List<WalkPath>();

    public Transform previousBlock;

    public bool movingGround = false;
    public bool needToParent = false;
    public bool isStair;

    public Vector3 offset;
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(GetWalkPoint(), 0.1f);

        if (possiblePaths == null)
            return;

        foreach (WalkPath p in possiblePaths)
        {
            if (p.target == null)
                return;
            Gizmos.color = p.active ? Color.black : Color.clear;
            Gizmos.DrawLine(GetWalkPoint(), p.target.GetComponent<Walkable>().GetWalkPoint());
        }
    }

    public Vector3 GetWalkPoint()
    {
        return transform.TransformPoint(offset);
    }
}

[System.Serializable]
public class WalkPath
{
    public Transform target;
    public bool active = true;
    
}





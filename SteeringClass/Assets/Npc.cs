using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public List<Vector3> targetPoints = new List<Vector3>();
    public Seek seek;
    public float distance;
    private int _index;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var actualPoint = targetPoints[_index];
        if (Vector3.Distance(actualPoint, transform.position) < distance)
        {
            NextPoint();
        }
        seek.Target = targetPoints[_index];
    }

    private void NextPoint()
    {
        if (_index == targetPoints.Count -1)
        {
            _index = 0;
            
           
        }
        else
        {
            _index++;
        }
    }
}

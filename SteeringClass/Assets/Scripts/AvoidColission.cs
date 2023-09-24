using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidColission : SteeringBehavior
{
    public ObstacleSpawner obstacleController;
    public float maxSeeAhead;
    public float obstacleRadius;
    public float maxAvoidForce;
    public bool showVectors;
    public List<Vector3> _obstacleList;
    private Vector3 _ahead;
    private Vector3 _ahead2;

    private void Start()
    {
        _obstacleList = obstacleController.obstaclePositions;
        _ahead = Velocity.normalized * maxSeeAhead;
        _ahead2 = Velocity.normalized * maxSeeAhead * 0.5f;
        FindBiggestThread();
    }

    public override Vector3 GetForce()
    {
        
        Vector3 steering = new Vector3();
        return steering;
    }

    Vector3 FindBiggestThread()
    {
        foreach (var obstacle in _obstacleList)
        {
            float distance = Vector3.Distance(obstacle, Position);
          
            if (distance < obstacleRadius)
            {
                Debug.Log(distance);
            }
            
        }
        return new Vector3();
    }

    bool CollisionDetected()
    {
        return true;
    }
    
    
}

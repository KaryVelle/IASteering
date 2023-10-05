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
    [SerializeField] private List<Vector3> _obstacleList;
    private Vector3 _ahead;
    private Vector3 _ahead2;
    private float _distance;
    private Vector3 biggestThread;

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
            
            _distance = Vector3.Distance(obstacle, Position);
            bool collision = CollisionDetected(_ahead, _ahead2);

        }
        return new Vector3();
    }

    private bool CollisionDetected(Vector3 _ahead, Vector3 _ahead2)
    {
        if (this._ahead > ) 
        {
            
        }
        return true;
    }
    
    
}

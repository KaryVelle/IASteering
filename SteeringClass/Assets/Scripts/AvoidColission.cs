using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidColission : SteeringBehavior
{
    public ObstacleSpawner obstacleSpawner;
    public float maxSeeAhead;
    public float obstacleRadius;
    public float maxAvoidForce;
    public bool showVectors = true;
    public List<Vector3> _obstacleList;
    private Vector3 _ahead;
    private Vector3 _ahead2;

    private void Start()
    {
        _obstacleList = obstacleSpawner.obstaclePositions;
    }
    


    public override Vector3 GetForce()
    {
        
        _ahead = Position + (Velocity.normalized * maxSeeAhead);
        
        _ahead2 = Position + (Velocity.normalized * maxSeeAhead * 0.5f);
        
        if (showVectors)
        {
            Debug.DrawLine(Position, _ahead ,Color.green);
        }
        

        Vector3? biggest = FindBiggestThread();
        if (biggest == null)
        {
            // no hay obs
            return Vector3.zero;
        }
        else
        {
            //si hay
           // Debug.Log("obstaculo");
            Vector3 avoidance = _ahead - biggest.Value;
            avoidance = avoidance.normalized;
            avoidance *= maxAvoidForce;
            return  avoidance ;
            
        }
       
    }

    Vector3? FindBiggestThread()
    {
        Vector3? mostThreatening = null;
        
        foreach (var obstacle in _obstacleList)
        {
            float distance = Vector3.Distance(obstacle, Position);
            bool collision = Collision(_ahead, _ahead2, obstacle);

            if (collision &&  (mostThreatening == null || distance <= Vector3.Distance(Position,mostThreatening.Value)))
            {
                mostThreatening = obstacle;
            }
        }
        return mostThreatening;
    }

    bool Collision(Vector3 _ahead, Vector3 _ahead2, Vector3 obstacle)
    {
        if (Vector3.Distance(_ahead, obstacle) < obstacleRadius || 
            Vector3.Distance(_ahead2, obstacle) < obstacleRadius)
        {
            Debug.Log("Si hay");
            return true;
        }
        //Debug.Log("No hay");
        return false;
    }
}

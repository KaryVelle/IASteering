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
    

    public override Vector3 GetForce()
    {
        
        
        _obstacleList = obstacleSpawner.obstaclePositions;
        _ahead = Velocity.normalized * maxSeeAhead;
        _ahead2 = Velocity.normalized * maxSeeAhead * 0.5f;
        
        
            Debug.DrawLine(Position, Position + _ahead, Color.black);
        

        Vector3? biggest = FindBiggestThread();
        if (biggest == null)
        {
            // no hay obs
            Debug.Log("obstaculo");
            return Vector3.zero;
        }
        else
        {
            //si hay
            Debug.Log("obstaculo");
            Vector3 avoidance = _ahead - biggest.Value;
            avoidance = Vector3.Normalize(avoidance) * maxAvoidForce;
            return   Velocity.normalized + avoidance ;
            
        }
       
    }

    Vector3? FindBiggestThread()
    {
        Vector3? mostThreatening = null;
        
        foreach (var obstacle in _obstacleList)
        {
            float distance = Vector3.Distance(obstacle, Position);
            bool collision = Collision(_ahead, _ahead2, obstacle);

            if (collision && (mostThreatening == null)  || 
               collision && distance < Vector3.Distance(Position, mostThreatening.Value))
            {
                mostThreatening = obstacle;
            }
        }
        return mostThreatening;
    }

    bool Collision(Vector3 _ahead, Vector3 _ahead2, Vector3 obstacle)
    {
        if ((Vector3.Distance(obstacle, _ahead) <= obstacleRadius) ||
            (Vector3.Distance(obstacle, _ahead2) <= obstacleRadius))
        {
            return true;
        }
        return false;
    }
}

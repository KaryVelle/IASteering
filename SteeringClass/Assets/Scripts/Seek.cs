using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehavior
{
    public bool arrival;
    public float slowingRadius;
    private float _distance;


    public override Vector3 GetForce()
    {
  

        Position = transform.position;
        _distance = Vector3.Distance(Target, Position); 
        DesiredVelocity= (Target - Position).normalized * speed;
       
        
      if (arrival)
      {
          if (_distance < slowingRadius)
          {
              DesiredVelocity = DesiredVelocity.normalized * speed * (_distance / slowingRadius);
             
          }
          else
          {
              DesiredVelocity = DesiredVelocity.normalized * speed;
          }
      }
      
      transform.position += Velocity * Time.deltaTime;
      Vector3 steering = DesiredVelocity - Velocity;
      Velocity = Vector3.ClampMagnitude(Velocity + steering, speed);
      return steering;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : SteeringBehavior
{
    public bool arrival;
    public float slowingRadius;
    private float _distance;
  

    public override Vector3 GetForce()
    {
        Position = transform.position;
        _distance = Vector3.Distance(Target, Position); 
        DesiredVelocity= ( Position - Target ).normalized * speed;
       
        
        if (arrival)
        {
            if (_distance > slowingRadius)
            {
                DesiredVelocity = new Vector3(0, 0, 0);

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

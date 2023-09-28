using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persuit : SteeringBehavior
{
    private int T;
    public GameObject pursuitTarget;
    public PlayerController _pController;
    
    
    void Start()
    {
       
    }

    public override Vector3 GetForce()
    {
        
        Vector3 futurePosition = pursuitTarget.transform.position + _pController.vel * T;
        Position = transform.position;
        DesiredVelocity = (futurePosition - Position).normalized * speed;
        Vector3 steering = DesiredVelocity - Velocity;
        Velocity = Vector3.ClampMagnitude(Velocity + steering, speed);
        return steering;
    }


}

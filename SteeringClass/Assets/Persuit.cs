using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persuit : SteeringBehavior
{
    public int T;
    public GameObject pursuitTarget;
    public PlayerController _pController;
    
    
    void Start()
    {
       
    }

    public override Vector3 GetForce()
    {
        
        Vector3 target = pursuitTarget.transform.position + _pController.vel * T;
        
        DesiredVelocity = (target - Position).normalized * speed;
        transform.position += Velocity * Time.deltaTime;
        Vector3 steering = DesiredVelocity - Velocity;
        Velocity = Vector3.ClampMagnitude(Velocity + steering, speed);
        return steering;
    }


}

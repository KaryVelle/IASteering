using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : SteeringBehavior
{
    
    public float runAwayCircle;
    public float safeRadius;
    [SerializeField] private int _T;
    public GameObject pursuitTarget;
    private PlayerController _pController;


    private void Start()
    {
        _pController = pursuitTarget.GetComponent<PlayerController>();
    }


    public override Vector3 GetForce()
    {

        return Seek();
    }

    private Vector3 Seek()
    {
        Position = transform.position;
        Target = pursuitTarget.transform.position;
        Vector3 FuturePos = Target + _pController.vel * _T;
        DesiredVelocity = (Position - FuturePos).normalized * speed;

        float distance = (Target - Position).magnitude;

        Vector3 steering = DesiredVelocity - Velocity;
        Velocity = Vector3.ClampMagnitude(Velocity + steering, speed);

        if (distance < runAwayCircle)
        {
            
            DesiredVelocity = (DesiredVelocity).normalized * speed * (runAwayCircle / distance);
            return steering;
        }
        if (distance < runAwayCircle && distance > safeRadius)
        {
           
            var distanceFRadius = distance / safeRadius;

            DesiredVelocity = (DesiredVelocity).normalized * speed * distanceFRadius;

            return steering;

        }


        Velocity = Vector3.zero;
        return Vector3.zero;
    }
}

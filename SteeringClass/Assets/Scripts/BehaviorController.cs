using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorController : MonoBehaviour
{
    public List<SteeringBehavior> behaviors = new List<SteeringBehavior>();
    public Rigidbody rigidBody;
    public Vector3 velocity;
    public Vector3 totalForce = Vector3.zero;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //inicializando en ceros
        totalForce = Vector3.zero;
        
        //Sacar el vector de la fuerza
        foreach ( SteeringBehavior behavior in behaviors)
        {
            behavior.Position = transform.position;
            totalForce += behavior.GetForce();
        }

       
        rigidBody.velocity += totalForce;
        transform.position += velocity * Time.deltaTime;

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class Wander : SteeringBehavior
{
    public float circleDistance;
    public float circleRadius;
    public float[] targetChange;
    public Vector3 targetSpace;
    public float angleChange;
    public float[] angleRange;
    public bool showVectors;
    private bool _startRandom;
    private float _rotationAngle;
    private Seek _seek;
    private Vector3 _displacement;
    private Vector3 _circleCenter;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _seek = gameObject.GetComponent<Seek>();
        StartCoroutine(RandomTarget());
        StartCoroutine(RandomAngle(angleChange));
        
    }

    public override Vector3 GetForce()
    {

        if (showVectors)
        {
            DrawVectors(_circleCenter, _displacement);
        }

        _seek.Target = targetSpace;
        
        //Circle Center
       _circleCenter = Velocity.normalized * circleDistance;

        //displacement
        Quaternion rotate = Quaternion.AngleAxis(angleChange, Vector3.forward);
         _displacement = (Velocity.normalized * circleRadius);
        Vector3 wander = rotate * _displacement;

        //Steering Wander
        Vector3 steeringWander = _circleCenter + wander;
        
        
     //  Vector2 direction = Target - transform.position;
     //   transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        
      return  steeringWander;
    }

    private IEnumerator RandomTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f,0.8f));
            targetSpace= new Vector3(Random.Range(targetChange[0], targetChange[1]),0, Random.Range(targetChange[0], targetChange[1]));
            
        } 
    }

    private IEnumerator RandomAngle(float angle)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f,0.8f));
            angle = Random.Range(angleRange[0], angleRange[1]);
            

        }
        
        
    }
    
    private void DrawVectors(Vector3 circle_center, Vector3 displacement)
    {
        
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + circle_center, Color.green);
        Debug.DrawLine(gameObject.transform.position + circle_center, transform.position + circle_center + displacement, Color.red);
        Debug.DrawLine( gameObject.transform.position, gameObject.transform.position + circle_center + displacement, Color.blue);
    
        
    }
 
}

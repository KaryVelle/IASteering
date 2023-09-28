using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 vel;
    

    
    void Update()
    {
        rb.velocity = vel;
    }
}

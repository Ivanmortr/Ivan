using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableParticle : ParticleWithCharge
{
    [SerializeField]
    private float mass = 1;

     

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        UpdateColor();
        rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = mass;
        rb.useGravity = false;
        
    }

    // Update is called once per frame
   
}

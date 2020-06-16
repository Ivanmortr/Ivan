using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWithCharge : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float charge =1;

    private Color color;

    void Start()
    {
        UpdateColor();
    }

    public void UpdateColor()
    {
        color = charge > 0 ? Color.red : Color.blue;
        GetComponent<Renderer>().material.color = color;
    }
  
}

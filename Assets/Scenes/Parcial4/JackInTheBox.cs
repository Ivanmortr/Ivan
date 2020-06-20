using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackInTheBox : MonoBehaviour
{
    public float k;
    public float m;
    public float xbalance;
    public float a;
    public float v;
    public float T;
    public float f;
    public float dampening;
    
    public float acc;

    public Transform spring;
    public Transform hijo;
    float valor= 0;
    float valor2;
    public void Test()
    {
        float displacement = xbalance - a;
        dampening = k * displacement;
        acc += ((k / m) * displacement) - dampening;
        spring.localScale = new Vector3(spring.localScale.x, spring.localScale.y - acc, spring.localScale.z);
        hijo.localPosition = new Vector3(hijo.localPosition.x,hijo.localPosition.y - acc,hijo.localPosition.z); 
       
    }


}

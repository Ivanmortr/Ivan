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


    Vector3 minScale;
    public Vector3 maxScale;
    public bool repetir;
    public float speed = 2f;
    public float duration = 5f;


    IEnumerator Start()
    {
        minScale = spring.transform.localScale;
        Test();

        while (repetir)
        {
            yield return repetirLerp(minScale, maxScale, duration);
            yield return repetirLerp(maxScale, minScale, duration);
        }
    }

    public void Test()
    {
        float displacement = xbalance - a;
        dampening = k * displacement;
        acc += ((k / m) * displacement) - dampening;
        spring.localScale = new Vector3(spring.localScale.x, spring.localScale.y - acc, spring.localScale.z);
        maxScale = spring.localScale;
        hijo.localPosition = (spring.localScale * -1);
       
    }

    public IEnumerator repetirLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while( i < 1.0f)
        {
            i += Time.deltaTime * rate;
            spring.transform.localScale = Vector3.Lerp(a, b, i);
            hijo.localPosition = (spring.localScale * -1);
            yield return null;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanoInclinado : MonoBehaviour
{
    private float g = -9.81f, yI, yF, d, t;

    // los BP no funcionan en mi visual no se porque

    private void Start()
    {
        yI = transform.position.y;
        StartCoroutine(ShootRay());
        CalculateTime(d);
        Move(transform.position, new Vector3(transform.position.x, transform.position.y - d, transform.position.z), t);
    }

    IEnumerator ShootRay()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.Log("Ray hit");
            d = Mathf.Abs(hit.distance - transform.localScale.x / 2);
        }
        else
            Debug.Log("No ray hit");

        yield return null;
    }
    void CalculateTime(float d)
    {


        t = Mathf.Abs(d / g);
    }

    void Move(Vector3 a, Vector3 b, float t)
    {
        float lerpValue = 0.0f;

        while (lerpValue <= t +1)
        {
            transform.position = Vector3.Lerp(a, b, lerpValue);
            lerpValue += Time.deltaTime;
            Debug.Log(lerpValue);
          //  yield return null;
        }
        

      
    }
}
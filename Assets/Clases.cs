using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clases : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    float F1;

    [SerializeField]
    float F2;

    public float D1;
    public float D2;
    void Start()
    {
        //F1 = gameObject.GetComponent<Rigidbody>();
        //F2 = gameObject.GetComponent<Rigidbody>();

    }

    float Formula(float F1,  float F2, float D1)
    {

        D2 = (F1 * D1) / F2;

        return D2;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
        Formula(F1, F2, D1);

        }

        Debug.Log(D2);
        
    }
}

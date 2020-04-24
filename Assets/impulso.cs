using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulso : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb= collision.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 50, ForceMode.Impulse);
    }
}

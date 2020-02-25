using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasePractica3 : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody Objetin;
    public float Fuerza;
    void Start()
    {
        Objetin = gameObject.GetComponent<Rigidbody>();

        AplicarFuerza(Fuerza);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Space))
        {
            AplicarFuerza(Fuerza);
        }

    } 

    public void AplicarFuerza(float fuerza)
    {
        fuerza = Fuerza;

        Objetin.AddForce(transform.up * fuerza, ForceMode.Force);

        float trabajo = fuerza * 12;

        Debug.Log(trabajo);
    }
}

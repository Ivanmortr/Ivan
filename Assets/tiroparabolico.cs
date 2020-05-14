using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroparabolico : MonoBehaviour
{

    public Rigidbody pelotita;
    public int multiplicador;
    public float KV;

    private void Start()
    {
        pelotita = GetComponent<Rigidbody>();
        multiplicador = 20;
    }

    public void Update()
    {

        if(Input.GetKey(KeyCode.Space))
        {
            KV += Time.deltaTime * multiplicador;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Lanzar();
        }
    }

    void Lanzar()
    {
        float energiaP = KV;
        pelotita.AddForce(energiaP * Vector3.up * multiplicador);

    }

}

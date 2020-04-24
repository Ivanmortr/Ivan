using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Practica2 : MonoBehaviour
{
    public GameObject Esferita;
    
    float FF;
    float FuerzaIzq;
    float FuerzaDer;
    Rigidbody rb;
    public Text FuerzaIzqT;
    public Text FuerzaDerT;
    // Start is called before the first frame update
    void Start()
    {
        rb = Esferita.GetComponent<Rigidbody>();
        FuerzaIzqT.text = "";
        FuerzaDerT.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FF -= 0.01f;
            FuerzaIzq -= 0.01f;
            
          
        }
        if (Input.GetMouseButtonDown(1))
        {
            FF += 0.01f;
            FuerzaDer += 0.01f;
          
        }
        
        rb.AddForce(new Vector3(FF, 0, 0), ForceMode.VelocityChange);
        FuerzaDerT.text = "Equipo Derecho: " + FuerzaDer;
        FuerzaIzqT.text = "Equipo Izquierdo: " + FuerzaIzq;
        
    }


}
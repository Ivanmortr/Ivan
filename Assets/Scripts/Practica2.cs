using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Practica2 : MonoBehaviour
{
    public GameObject Esferita;
    int FIzq;
    int FDer;
    int FF;
    [SerializeField]
    Text fuerza1, fuerza2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FIzq += 1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            FDer += 1;
        }
        FF = FDer - FIzq;

        int FIzq2 = FIzq - FDer;
        int FDer2 = FDer - FIzq;
        Esferita.transform.position =new Vector3 (FF, 0, 0);
        fuerza1.text ="Fuerza izq " + FIzq2;
        fuerza2.text = "Fuerza der " + FDer2;

    }
}

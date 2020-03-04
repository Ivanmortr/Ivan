using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class TareaParabolic: MonoBehaviour
{

    [Tooltip("Position we want to hit")]
    public Vector3 targetPos;

    [Tooltip("Horizontal speed, in units/sec")]
    public float speed = 10;

    [Tooltip("How high the arc should be, in units")]
    public float arcHeight = 1;


    Vector3 startPos;

    void Start()
    {
        // guardamos nuestra posicion inicial
       
        startPos = transform.position;
    }

    void Update()
    {
        // Calcula la siguiente posicion, con el angulo puesto
        float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
        float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist); //la formula para obtener el maximo de  trabajo de arco a cualquier altura de arco que haya especificado.
        Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

        // Gira para apuntar la siguiente posición y luego muévete allí
        transform.rotation = LookAt2D(nextPos - transform.position);
        transform.position = nextPos;
        

        // Haz algo cuando se llega a la posicion
        if (nextPos == targetPos) Arrived();
    }

    void Arrived()
    {
        Destroy(gameObject);
    }

    /// 
    /// This is a 2D version of Quaternion.LookAt; it returns a quaternion
    /// that makes the local +X axis point in the given forward direction.
    /// 
    /// forward direction
    /// Quaternion that rotates +X to align with forward
    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanoInclinado : MonoBehaviour
{
    //public GameObject[] RAMPS;
    private float g = -9.81f, y1, yf;
    float distance;
    float time;

    GameObject plank;

    public GameObject[] waypoints;
    int current = 0;
    public float rotSpeed;
    public float velocidad;
    public float velocidad2;
    float WPradius = 1;


    bool useSen;
    public bool llegado = false;
    public bool llegadoPlancha2 = false;
    Vector3 startPos;
    public void Start()
    {
        y1 = transform.position.y;

        CastearRayDown();
        time = Mathf.Abs(CalculatTime(distance));
        StartCoroutine(MoveToPlank(transform.position, new Vector3(transform.position.x, transform.position.y - distance, transform.position.z), time));
        startPos = plank.GetComponent<WayPoints>().WayPointB.transform.position;
       
    }

    void CastearRayDown()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            distance = Mathf.Abs(hit.distance - transform.localScale.x / 2);
            Debug.Log("distancia: " + distance );
            plank = hit.collider.gameObject;
        }
    }
    float SacardistanciaRecorridaEnY(float thetha, float h)
    {
        float angle2 = thetha;
        angle2 = thetha * Mathf.PI / 180;
        float anguloDeg = Mathf.Sin(angle2);


        float resultado1 = h / Mathf.Sin( thetha);

        float resultado = 2.150306f + resultado1;

        Debug.Log("Distancia a subir en Y: " + resultado);
        return resultado;

    }
    float SacardistanciaRecorridaEnX(float thetha, float h)
    {
        float angle2 = thetha;
        angle2 = thetha * Mathf.PI / 180;
        float anguloDeg = Mathf.Cos(angle2);


        float resultado1 = h / anguloDeg;
        resultado1 *= 10;
        float resultado = -6.277693f + resultado1;
        Debug.Log("Distancia a subir en X: " + resultado1);
        Debug.Log("Distancia a subir en X: " + resultado);

        return resultado;

    }
    IEnumerator MoveToPlank(Vector3 a, Vector3 b, float t)
    {
        float lerpValue = 0.0f;
        while (lerpValue < time)
        {
            this.transform.position = Vector3.Lerp(a, b, lerpValue);

            lerpValue += Time.deltaTime;
            yield return null;
        }
        this.transform.position = b;

        
        plank.GetComponent<WayPoints>().WayPointA.transform.position = b;
        CalculateDistanceOfPlank();


    }

    float CalculatTime(float d)
    {

        return distance / g;
    }

    float SacarPX(float hipotenusa, float angle)
    {
        float distance;
        float componenteX;
        if (plank.GetComponent<WayPoints>().sen)
        {
            //true
            float angle2 = angle;
            angle2 = angle * Mathf.PI / 180;
            float angulorad = Mathf.Sin(angle2);

            componenteX = Mathf.Sin(angulorad) * 9.8f;
            Debug.Log("angulo rad: " + angulorad);
            Debug.Log("Componente X: " + Mathf.Sin(angulorad) * 9.8f);
            //Debug.Log(angle2);
            distance = Mathf.Sin(angle) * hipotenusa;
            useSen = false;
        }
        else
        {
            //false
            distance = Mathf.Cos(angle) * hipotenusa;
            componenteX = Mathf.Sin(angle) * 9.8f;
            useSen = true;
        }
        
        return componenteX;
    }

    float SacarPY(float hipotenusa, float angle)
    {
        float distance;
        float componenteY;
        if (useSen)
        {
            //true
            distance = Mathf.Sin(angle) * hipotenusa;
            
        }
        else
        {
            //false
            distance = Mathf.Cos(angle) * hipotenusa;
        }

        Debug.Log("Componente en Y: " + Mathf.Cos(angle) * 9.8f);
        return Mathf.Abs(distance);
    }

    float getAceleration(float fuerza, float maza)
    {
        Debug.Log("Aceleration: " + fuerza / maza);
        return fuerza / maza;
        
    }


    void CalculateDistanceOfPlank()
    {

        float hipotenusa = plank.transform.localScale.x; //horizontal diustance
        float angle = plank.transform.localEulerAngles.z;
        float height = Mathf.Sin(angle) * hipotenusa; // distnacia de altura
        //float horizontal_height = Mathf.Cos(angle) * hipotenusa;
        float masa = 1;
        // m * g
        //9.81 p
        float peso = masa * g;
        Debug.Log("peso:" + peso);

        Debug.Log("hipotenusa: " + hipotenusa);



        float fx = SacarPX(hipotenusa, angle);
        float fy = SacarPY(hipotenusa, angle);
        float aceleration = getAceleration(fx, 1);
        //0.98 a
        //24.75
        //vf = 4.97
        
        TranslateTOPlancha1(-4.316854f, 3.179822f,aceleration);
        
        

        //StartCoroutine(MoveFromAtoB(plank.GetComponent<WayPoints>().WayPointA.transform.position, plank.GetComponent<WayPoints>().WayPointB.transform.position, 5.064f, hipotenusa));


        //calcular nuevo vector y usar de nuevo el lerp /tiempo
    }
    void TranslateTOPlancha1(float px, float py,float aceleracion)
    {
        
        bool stop = false;
        if (stop != true)
            velocidad2 += (aceleracion * 0.1f) * 0.1f; 

        if (Vector3.Distance(new Vector3(px, py, -0.2f), transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                stop = true;
                llegado = true;

            }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(px, py, -0.21f), Time.deltaTime * velocidad2);

    }
    float TimeParaRecorrer(float distancia, float aceleracion)
    {
        float tiempo = Mathf.Sqrt(25.64f);

        Debug.Log("Tiempo en recorrer" + tiempo);
        return tiempo;
    }
    IEnumerator MoveFromAtoB(Vector3 a, Vector3 b, float t, float hipotenusa)
    {
        float lerpValue = 0.0f;
        float Perc;
        while (lerpValue < t)
        {
            Perc = lerpValue / t;
            this.transform.position = Vector3.Lerp(a, b, Perc);

            lerpValue += Time.deltaTime;
            
            yield return null;
        }
        llegado = true;
        yield return null;
    }
    public Vector3 targetPos;
    [Tooltip("Horizontal speed, in units/sec")]
    public float speed = 10;

    [Tooltip("How high the arc should be, in units")]
    public float arcHeight = 1;
   
    
    void Update()
    {
        bool terminado = false;
        // Calcula la siguiente posicion, con el angulo puesto
        if(llegado!=true&&terminado ==false&&llegadoPlancha2 !=true)
        CalculateDistanceOfPlank();
        if (llegado == true)
         MovementParabolic();
        else if(llegadoPlancha2 == true)
        {
            float posY = SacardistanciaRecorridaEnY(6, -0.130f);
            float posX = SacardistanciaRecorridaEnX(6, -0.130f);
            
            TranslateTO(posX,posY);
            if(velocidad <= -6.739994f)
            {
                llegadoPlancha2 = false;
                terminado = true;
                Debug.Log("Terminado");
                Destroy(gameObject);
            }
          //llamar la funcion para subir
        }
        else
        {
           
        }
    }

    IEnumerator destruir()
    {
        
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void TranslateTO(float px, float py)
    {
        bool stop = false;
        if(stop != true)
        velocidad -=(4f * 0.1f)* 0.1f;

        if (Vector3.Distance(new Vector3(px,py,-0.2f),transform.position) < WPradius)
        {
            current++;
            if(velocidad<= -6.739994f)
            {
                Destroy(gameObject);
                
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(px,py,-0.21f), Time.deltaTime * velocidad);

    }
    public void MovementParabolic()
    {
        // Calcula la siguiente posicion, con el angulo puesto
        float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0; // sacamos la distancia
        float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime); // El movimiento MRU
        float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
        float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist); //la formula para obtener el maximo de  trabajo de arco a cualquier altura de arco que haya especificado.
        Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

        // Gira para apuntar la siguiente posición y luego muévete allí
        transform.rotation = LookAt2D(nextPos - transform.position);
        transform.position = nextPos;
        // Haz algo cuando se llega a la posicion

        
        if (nextPos.x == targetPos.x) Arrived();
    }
    void Arrived()
    {
        llegado = false;
        llegadoPlancha2 = true;
        
    }
    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }

}

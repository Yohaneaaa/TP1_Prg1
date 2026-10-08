using UnityEngine;

public class plataformaMovil : MonoBehaviour
{
    public Vector3 desplazamiento = new Vector3(0, 40, 0);
    public float velocidad = 20f;

    private Rigidbody rb;             
    private Vector3 puntoA;
    private Vector3 puntoB;
    private float progreso = 0f;
    private int direccion = 1;
    private float tiempoViaje;
    private Vector3 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        puntoA = transform.position;
        puntoB = puntoA + desplazamiento;

        tiempoViaje = desplazamiento.magnitude / velocidad;

        Invoke("CambiarDireccion", tiempoViaje);
    }

    void FixedUpdate()
    {
        progreso += direccion * Time.fixedDeltaTime / tiempoViaje;
        progreso = Mathf.Clamp01(progreso);

        Vector3 destino = Vector3.Lerp(puntoA, puntoB, progreso);
        movimiento = destino - rb.position;   
        rb.MovePosition(destino);             
    }

    void CambiarDireccion()
    {
        direccion = -direccion;
        Debug.Log(gameObject.name + " cambió de dirección");

        Invoke("CambiarDireccion", tiempoViaje);
    }

    void OnCollisionStay(Collision c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            
            Vector3 extra = movimiento;
            if (extra.y > 0) extra.y = 0;
            c.transform.position += extra;
        }
    }
}
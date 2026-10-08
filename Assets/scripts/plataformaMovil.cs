using UnityEngine;

public class plataformaMovil : MonoBehaviour
{
    public Vector3 desplazamiento = new Vector3(0, 40, 0);
    public float velocidad = 20f;

    private Vector3 puntoA;
    private Vector3 puntoB;
    private float progreso = 0f;   // 0 = en el punto A, 1 = en el punto B
    private int direccion = 1;     // 1 = va hacia B, -1 = vuelve hacia A
    private float tiempoViaje;
    private Vector3 movimiento;

    void Start()
    {
        puntoA = transform.position;
        puntoB = puntoA + desplazamiento;

        // Tiempo que tarda en ir de A a B
        tiempoViaje = desplazamiento.magnitude / velocidad;

        // Invoke programa el primer cambio de dirección
        Invoke("CambiarDireccion", tiempoViaje);
    }

    void FixedUpdate()
    {
        Vector3 anterior = transform.position;

        // El progreso sube o baja según la dirección, siempre entre 0 y 1
        progreso += direccion * Time.fixedDeltaTime / tiempoViaje;
        progreso = Mathf.Clamp01(progreso);

        transform.position = Vector3.Lerp(puntoA, puntoB, progreso);
        movimiento = transform.position - anterior;
    }

    void CambiarDireccion()
    {
        direccion = -direccion;
        Debug.Log(gameObject.name + " cambió de dirección");

        // Programa el siguiente cambio
        Invoke("CambiarDireccion", tiempoViaje);
    }

    // Si el jugador está parado arriba, viaja con la plataforma
    void OnCollisionStay(Collision c)
    {
        if (c.gameObject.CompareTag("Player"))
            c.transform.position += movimiento;
    }
}
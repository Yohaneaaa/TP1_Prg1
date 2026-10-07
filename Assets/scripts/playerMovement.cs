using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Variables
    public float velCaminar = 10f;
    public float velCorrer = 15f;

    public float fuerza1 = 8f;
    public float fuerzaAire = 7f;
    public int maxSaltos = 2;

    // Gravedad extra para que el salto se sienta más ágil y menos flotante
    public float gravedadExtra = 2f;

    private int saltos = 0;
    private Rigidbody rb;

    [HideInInspector] public float fuerza1Original;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fuerza1Original = fuerza1;

        // Congelar rotación para que el cuerpo no se caiga rodando
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        Mover();
        Saltar();
    }

    void FixedUpdate()
    {
        // Cuando el jugador cae, la gravedad es más fuerte
        if (rb.linearVelocity.y < 0f)
        {
            rb.AddForce(Physics.gravity * gravedadExtra, ForceMode.Acceleration);
        }
    }

    // Funciones propias
    void Mover()
    {
        float velActual = Input.GetKey(KeyCode.LeftShift) ? velCorrer : velCaminar;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Evita que en diagonal vaya más rápido
        Vector3 direccion = Vector3.ClampMagnitude(new Vector3(x, 0f, z), 1f);

        rb.linearVelocity = new Vector3(
            direccion.x * velActual,
            rb.linearVelocity.y,
            direccion.z * velActual
        );
    }

    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && saltos < maxSaltos)
        {
            // El primer salto usa fuerza1 y el segundo (en el aire) usa fuerzaAire
            float fuerza = (saltos == 0) ? fuerza1 : fuerzaAire;

            rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerza, rb.linearVelocity.z);
            saltos++;
        }
    }

    // Colisiones
    void OnCollisionEnter(Collision c)
    {
        foreach (ContactPoint contacto in c.contacts)
        {
            // Si lo que tocó está por debajo, es el suelo: se reinician los saltos
            if (contacto.normal.y > 0.6f)
            {
                saltos = 0;
                break;
            }
        }
    }
}
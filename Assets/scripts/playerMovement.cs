using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float velocidad = 30f;
    public float fuerzaSalto = 20f;
    public float fuerzaDobleSalto = 24f;
    public int maxSaltos = 2;

    private Rigidbody rb;
    private Transform cam;
    private int saltos = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 adelante = cam.forward;
        Vector3 derecha = cam.right;
        adelante.y = 0;
        derecha.y = 0;

        Vector3 dir = adelante.normalized * z + derecha.normalized * x;
        rb.linearVelocity = new Vector3(dir.x * velocidad, rb.linearVelocity.y, dir.z * velocidad);

        if (Input.GetKeyDown(KeyCode.Space) && saltos < maxSaltos)
        {
            float fuerza = (saltos == 0) ? fuerzaSalto : fuerzaDobleSalto;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerza, rb.linearVelocity.z);
            saltos++;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        foreach (ContactPoint punto in c.contacts)
        {
            if (punto.normal.y > 0.5f)
            {
                saltos = 0;
                break;
            }
        }
    }
}
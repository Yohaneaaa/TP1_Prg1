using UnityEngine;

public class camaraSigue : MonoBehaviour
{

    public Transform objetivo;
    public float velocidadGiro = 3f;
    public float velocidadTeclas = 100f;

    private float distancia;
    private float giroX;
    private float giroY;

    void Start()
    {
        
        distancia = Vector3.Distance(transform.position, objetivo.position);
        giroX = transform.eulerAngles.y;
        giroY = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
      
        if (Input.GetMouseButton(1))
        {
            giroX += Input.GetAxis("Mouse X") * velocidadGiro;
            giroY -= Input.GetAxis("Mouse Y") * velocidadGiro;
        }

   
        if (Input.GetKey(KeyCode.Z)) giroX -= velocidadTeclas * Time.deltaTime;
        if (Input.GetKey(KeyCode.X)) giroX += velocidadTeclas * Time.deltaTime;


        giroY = Mathf.Clamp(giroY, 5f, 80f);

        Quaternion rotacion = Quaternion.Euler(giroY, giroX, 0f);
        transform.position = objetivo.position - rotacion * Vector3.forward * distancia;
        transform.LookAt(objetivo.position);
    }
}
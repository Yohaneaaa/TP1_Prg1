using UnityEngine;

public class agarrarObjeto : MonoBehaviour
{
    public Transform objeto;
    public Transform puntoTransporte;
    public float distanciaRecoger = 8f;

    private Rigidbody rbObjeto;
    private Collider colObjeto;
    private Collider colJugador;
    private bool llevandoObjeto = false;
    private Vector3 posicionInicial;

    void Start()
    {
        rbObjeto = objeto.GetComponent<Rigidbody>();
        colObjeto = objeto.GetComponent<Collider>();
        colJugador = GetComponent<Collider>();
        posicionInicial = objeto.position;
        Physics.IgnoreCollision(colJugador, colObjeto);
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.E) && !llevandoObjeto)
        {
            float distancia = Vector3.Distance(transform.position, objeto.position);
            if (distancia <= distanciaRecoger)
            {
                Recoger();
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && llevandoObjeto)
        {
            Soltar();
        }

        if (!llevandoObjeto && objeto.position.y < -30f)
        {
            objeto.position = posicionInicial;
            rbObjeto.linearVelocity = Vector3.zero;
        }
    }

    void Recoger()
    {
        llevandoObjeto = true;
        rbObjeto.isKinematic = true;
        colObjeto.enabled = false;
        objeto.SetParent(puntoTransporte);
        objeto.localPosition = Vector3.zero;
        objeto.localRotation = Quaternion.identity;
    }

    void Soltar()
    {
        objeto.SetParent(null);

    
        Vector3 adelante = Camera.main.transform.forward;
        adelante.y = 0;
        objeto.position = transform.position + adelante.normalized * 2f;

        rbObjeto.isKinematic = false;
        rbObjeto.linearVelocity = Vector3.zero;
        rbObjeto.angularVelocity = Vector3.zero;
        colObjeto.enabled = true;

    
        Physics.IgnoreCollision(colJugador, colObjeto);

        llevandoObjeto = false;
    }
}
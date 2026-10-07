using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject piedra;
    public float primerDelay = 2f;
    public float intervalo = 5f;
    public float vida = 15f;
    public float velocidadInicial = 30f;

    void Start()
    {
        InvokeRepeating("CrearPiedra", primerDelay, intervalo);
    }

    void CrearPiedra()
    {
        GameObject nueva = Instantiate(piedra, transform.position, Quaternion.identity);

        Rigidbody rbPiedra = nueva.GetComponent<Rigidbody>();
        rbPiedra.linearVelocity = transform.forward * velocidadInicial;

        Destroy(nueva, vida);
    }
}
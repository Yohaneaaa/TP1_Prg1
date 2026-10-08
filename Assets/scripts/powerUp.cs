using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplicador = 1.7f;   
    public float duracion = 5f;         
    public float recarga = 8f;         

   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Activar(other.GetComponent<playerMovement>()));
        }
    }

    
    IEnumerator Activar(playerMovement jugador)
    {
       
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        float saltoOriginal = jugador.fuerzaSalto;
        jugador.fuerzaSalto = saltoOriginal * multiplicador;
        Debug.Log("Power-up activado");

        yield return new WaitForSeconds(duracion);

       
        jugador.fuerzaSalto = saltoOriginal;
        Debug.Log("Power-up terminado");

        yield return new WaitForSeconds(recarga);

      
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
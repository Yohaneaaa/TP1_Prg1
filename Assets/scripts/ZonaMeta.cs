using UnityEngine;

public class ZonaMeta : MonoBehaviour
{

    public GameObject objeto;           
    public Material materialVictoria; 

    private bool ganado = false;

 
    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject == objeto && !ganado)
        {
            ganado = true;
            Debug.Log("¡GANASTE!");
            GetComponent<Renderer>().material = materialVictoria;
        }
    }

   
    void OnGUI()
    {
        if (ganado)
        {
            GUI.skin.label.fontSize = 60;
            GUI.Label(new Rect(Screen.width / 3, Screen.height / 3, 800, 200), "¡GANASTE!");
        }
    }
}
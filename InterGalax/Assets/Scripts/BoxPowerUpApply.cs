using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPowerUpApply : MonoBehaviour
{
    [SerializeField] AudioClip clip;   // Clip de audio que se reproduce cuando el jugador interactúa con la caja.
    [SerializeField] GameObject dustExpl; // Prefab de la explosión de polvo que se instancia cuando se destruye la caja.

    GameManager Score; // Referencia al GameManager que maneja el puntaje


    void DestroyBox()
    {
        // Llamamos al método AddScore del GameManager para añadir puntos según la etiqueta de la caja.'gameObject.tag' obtiene la etiqueta de la caja.
        GameManager.GetInstance().AddScore(gameObject.tag);

        Instantiate(dustExpl, transform.position, Quaternion.identity); // Instanciamos el efecto de explosión de polvo en la posición actual de la caja.

        Destroy(gameObject);// Destruimos el objeto de la caja.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // Si el objeto que colisiona tiene la etiqueta "Player"
        {

            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position); // Reproducimos el clip de audio 


            DestroyBox(); // Llamamos al método DestroyBox para destruir la caja y aplicar los puntos.


        }
    }
}

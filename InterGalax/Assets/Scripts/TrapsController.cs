using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsController : MonoBehaviour
{
    [SerializeField] AudioClip clip; // Clip de audio que se reproduce cuando el jugador entra en contacto con la trampa.

    
    // Método para añadir puntos al jugador, dependiendo de la etiqueta de la trampa.
    void restPoints()
    {
        GameManager.GetInstance().AddScore(gameObject.tag);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos si el puntaje del jugador es mayor o igual a 50 antes de ejecutar la acción.

        if (GameManager.GetInstance().getScore() >=50) {

            // Si el objeto que colisiona con la trampa es el jugador (tag "Player").

            if (collision.gameObject.tag == "Player")
            {
                restPoints(); // Añadimos puntos al jugador (llama al método restPoints).

                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position); // Reproducimos el sonido de la trampa
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.GetInstance().getScore() >= 50)
        {

            if (collision.gameObject.tag == "Player")
            {
                restPoints();
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalassPowerUpApply : MonoBehaviour
{
    [SerializeField] AudioClip clip; // Clip de audio que se reproduce cuando el jugador recoge el power-up.
    GameManager Score; // Referencia al GameManager, que maneja los puntos


    void DestroyGlass() // método que destruye los cristales
    {
        GameManager.GetInstance().AddScore(gameObject.tag); // Llama al método AddScore del GameManager, pasando la etiqueta del objeto para determinar los puntos.

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // Si el objeto que colisiona tiene la etiqueta "Player".reproduce el sonido y destruye el objeto ( cristal )
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            DestroyGlass();
        }
    }
}

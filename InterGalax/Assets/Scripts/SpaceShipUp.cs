using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipUp : MonoBehaviour
{
    
    [SerializeField] Vector3 endPosition;// La posición final a la que se moverá el objeto (nave).
    [SerializeField] float duration; // Duración del movimiento, el tiempo que tarda en ir desde la posición inicial a la final.



    void Start()
    {

        StartCoroutine("StartPlayer");// Inicia la corrutina "StartPlayer", que maneja el movimiento de la nave
    }


    // Corrutina que maneja el movimiento del objeto.
    IEnumerator StartPlayer()
    {
        Collider2D collider = GetComponent<Collider2D>(); // Desactivamos el collider del objeto para evitar interacciones durante el movimiento.

        collider.enabled = false;
        Vector3 initialPosition = transform.position; // Guardamos la posición inicial del objeto para poder interpolar entre la posición inicial y final.
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;

            // Interpolamos la posición entre la inicial y la final usando Lerp
            // El valor de t / duration va de 0 a 1, lo que permite que el objeto se mueva desde la posición inicial hasta la final
            Vector3 newPosition = Vector3.Lerp(initialPosition, endPosition, t / duration);
            transform.position = newPosition;
            yield return null;

        }


    }


}

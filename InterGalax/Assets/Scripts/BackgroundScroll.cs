using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] float speed;   // La velocidad con la que se mueve el fondo
    float heigth; // La altura del sprite del fondo

    void Start()
    {
        // Extraemos la altura del sprite del fondo usando el componente SpriteRenderer que contiene la información del sprite. 'bounds.size.y' da la altura.

        heigth = GetComponent<SpriteRenderer>().bounds.size.y; 
    }

    void Update()
    {
        // Desplazamos el fondo hacia abajo multiplicando la dirección 'down' por la velocidad y el tiempo transcurrido.'Time.deltaTime' asegura que el movimiento sea independiente de la tasa de frames por segundo (FPS).
        transform.Translate(Vector3.down * speed * Time.deltaTime);


        // Comprobamos si la posición 'y' del fondo es menor que la negativa de su altura,es decir, si el fondo ya ha salido completamente de la pantalla por abajo.
        if (transform.position.y < -heigth)
        {
            // Si el fondo ha salido de la pantalla, lo desplazamos hacia arriba un valor que es el doble de su altura para que se repita el ciclo de desplazamiento de manera continua.
            transform.Translate(Vector3.up * 2 * heigth); // quiere saltar el doble de la altura
        }

    }


}

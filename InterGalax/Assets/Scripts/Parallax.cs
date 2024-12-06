using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float parallax;  // Factor que determina la velocidad del parallax, se ajusta desde el inspector.

    Material mat; // Material del sprite al que se le aplicar� el parallax.
    Transform cam; // Referencia a la c�mara principal para obtener su posici�n.
    Vector3 initialPosition; // Posici�n inicial del objeto, usada para mantener la referencia de su ubicaci�n original.
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;  // Obtener el material del componente SpriteRenderer para manipular el parallax en la textura.
        cam = Camera.main.transform; // Referencia de la c�mara principal.
        initialPosition = transform.position; // Guardar la posici�n inicial del objeto para mantener su posici�n en el eje Y y Z.
    }


    void Update()
    {
        transform.position = new Vector3(cam.position.x, initialPosition.y, initialPosition.z);// Actualizar la posici�n del objeto, movi�ndolo en el eje X de acuerdo con la posici�n de la c�mara.
        // La posici�n Y y Z se mantienen constantes para evitar que se mueva vertical o hacia el fondo.

        mat.mainTextureOffset = new Vector2(cam.position.x * parallax, 0);

        // Aplicar un desplazamiento en la textura para crear el efecto de parallax en el fondo.
        // Se ajusta la textura en funci�n de la posici�n X de la c�mara y el factor 'parallax' para controlar la velocidad.


    }
}

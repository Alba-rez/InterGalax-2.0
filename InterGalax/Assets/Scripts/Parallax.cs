using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float parallax;  // Factor que determina la velocidad del parallax, se ajusta desde el inspector.

    Material mat; // Material del sprite al que se le aplicará el parallax.
    Transform cam; // Referencia a la cámara principal para obtener su posición.
    Vector3 initialPosition; // Posición inicial del objeto, usada para mantener la referencia de su ubicación original.
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;  // Obtener el material del componente SpriteRenderer para manipular el parallax en la textura.
        cam = Camera.main.transform; // Referencia de la cámara principal.
        initialPosition = transform.position; // Guardar la posición inicial del objeto para mantener su posición en el eje Y y Z.
    }


    void Update()
    {
        transform.position = new Vector3(cam.position.x, initialPosition.y, initialPosition.z);// Actualizar la posición del objeto, moviéndolo en el eje X de acuerdo con la posición de la cámara.
        // La posición Y y Z se mantienen constantes para evitar que se mueva vertical o hacia el fondo.

        mat.mainTextureOffset = new Vector2(cam.position.x * parallax, 0);

        // Aplicar un desplazamiento en la textura para crear el efecto de parallax en el fondo.
        // Se ajusta la textura en función de la posición X de la cámara y el factor 'parallax' para controlar la velocidad.


    }
}

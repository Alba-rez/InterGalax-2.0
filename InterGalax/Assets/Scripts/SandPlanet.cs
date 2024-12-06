using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandPlanet : MonoBehaviour
{

   [SerializeField] float rotationSpeed; // Velocidad de rotaci�n

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
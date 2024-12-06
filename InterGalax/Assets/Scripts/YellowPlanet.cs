using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlanet : MonoBehaviour
{
    [SerializeField] float rotationSpeed; // Velocidad de rotación

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}

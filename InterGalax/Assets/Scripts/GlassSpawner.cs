using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GlassSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefb;
    [SerializeField] Transform[] spawnPoints;// puntos de spawneo ( localización de las cajas )
    [SerializeField] float delay;

    private GameObject Crystal = null;
    private List<Transform> availableSpawnPoints; // listado de los puntos de spawneo

    void Start()
    {
        // Ordenar los puntos de spawn en el eje X de menor a mayor
        availableSpawnPoints = spawnPoints.OrderBy(sp => sp.position.x).ToList();

        StartCoroutine("Spawn"); // llama a la corrutina Spawn para instanciar los cristales
    }


    // Corrutina que se encarga de instanciar los cristales en los puntos de spawneo.

    IEnumerator Spawn()
    {
        while (true)
        {

            if (Crystal == null && availableSpawnPoints.Count > 0) // si no hay cristales instanciados y los puntos de spawneo son más que 0
            {
                yield return new WaitForSeconds(delay); // espera los segundos indicados

                // Seleccionar el primer punto disponible (con menor X) y eliminarlo de la lista
                Transform spawnPoint = availableSpawnPoints[0];
                availableSpawnPoints.RemoveAt(0);

                // Instanciar el cristal en el punto seleccionado
                Crystal = Instantiate(prefb, spawnPoint.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.5f);

            if(availableSpawnPoints.Count == 0) 
            {
                ResetSpawnPoints();
            }
        }
    }

    // Método para reiniciar los puntos de spawn
    private void ResetSpawnPoints()
    {
        // Restablecer la lista de puntos disponibles
        availableSpawnPoints = spawnPoints.OrderBy(sp => sp.position.x).ToList();

        // Instanciar inmediatamente un nuevo cristal desde el primer spawn point:
        if (availableSpawnPoints.Count > 0)
        {
            Transform spawnPoint = availableSpawnPoints[0];
            availableSpawnPoints.RemoveAt(0);
            Crystal = Instantiate(prefb, spawnPoint.position, Quaternion.identity);
        }
    }
}

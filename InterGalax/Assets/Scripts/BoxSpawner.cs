using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform[] spawnPoints; // Array de puntos de spawn
    [SerializeField] float delay;

    GameObject boxPowerUp = null;
    private List<Transform> availableSpawnPoints; // Lista de puntos disponibles

    void Start()
    {
        // Ordenar los puntos de spawn por posición en el eje X de menor a mayor
        availableSpawnPoints = spawnPoints.OrderBy(sp => sp.position.x).ToList();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            // Solo instanciar si no hay caja presente y si hay puntos de spawn disponibles
            if (boxPowerUp == null && availableSpawnPoints.Count > 0)
            {
                yield return new WaitForSeconds(delay);

                // Obtener el primer punto disponible y eliminarlo de la lista
                Transform spawnPoint = availableSpawnPoints[0];
                availableSpawnPoints.RemoveAt(0);

                // Instanciar la caja en el punto seleccionado
                boxPowerUp = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.5f);

            // Verificar si la caja se ha destruido y no quedan puntos disponibles
            if (boxPowerUp == null && availableSpawnPoints.Count == 0)
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

        // Solo instanciar una nueva caja si la lista tiene puntos disponibles
        if (availableSpawnPoints.Count > 0)
        {
            Transform spawnPoint = availableSpawnPoints[0];
            availableSpawnPoints.RemoveAt(0);
            boxPowerUp = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
    }

    // Método para destruir la caja y eliminarla de la escena
    public void DestroyBox()
    {
        if (boxPowerUp != null)
        {
            Destroy(boxPowerUp);
            boxPowerUp = null; // Restablecer la referencia
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    // referencia al GameManager
    private GameManager gManager;
    [SerializeField] AudioClip sfxCutter; // sonido de las sierras

    void Start()
    {
        // Inicializa la referencia al GameManager
        gManager = GameManager.GetInstance();
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona es el Player
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sfxCutter, new Vector3(0, -10,0),1f);
            // Llama al método para aplicar Game Over
            gManager.GameOver();
        }
    }
}

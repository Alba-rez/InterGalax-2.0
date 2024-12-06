using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeOff : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] AudioClip sfxTakeOff;
    GameManager manager;
    GameObject player;

    void Awake()
    {
        // Recuperar la referencia al GameManager
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Recuperar referencia al jugador
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && manager != null)
        {
            // Comprobar si el jugador ha atravesado la nave y si los puntos son suficientes
            if (manager.getScore() >= 500)
            {
                anim.SetTrigger("takeOff");// Activamos el trigger de animaci�n "takeOff", lo que inicia una animaci�n de despegue.

                player.SetActive(false); // Desactivamos el objeto del jugador para que no sea visible

                AudioSource.PlayClipAtPoint(sfxTakeOff, Camera.main.transform.position); // sonido del despegue
                Invoke("NextLevel", 2); // invoca al m�todo NextLevel con un retardo de 2 segundos
            }
        }
    }



    void NextLevel()
    {
        int nextId = SceneManager.GetActiveScene().buildIndex + 1;// Obtenemos el �ndice de la escena activa actual (la escena en la que estamos).
        if (nextId < SceneManager.sceneCountInBuildSettings)  // Comprobamos si el �ndice de la siguiente escena est� dentro de los l�mites de las escenas disponibles en el build.

        {
            SceneManager.LoadScene(nextId); // Si hay una escena siguiente, la cargamos.
        }
        else
        {
            // Si es la �ltima escena, cargar la primera
            SceneManager.LoadScene(0);
        }
    }
}

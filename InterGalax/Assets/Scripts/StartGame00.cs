using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame00 : MonoBehaviour
{
   

    [SerializeField] Text msg1; // texto para "PRESS ANY KEY TO START"
    [SerializeField] Text msg2; // texto para "PRESS <ESC> TO QUIT
    [SerializeField] AudioClip sfx; // Sonido para pasar a la pantalla del juego
    [SerializeField] float delayBeforeNext; // retardo para pasar a la siguiente pantalla

    private bool gameStarted = false;

    
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) &&!gameStarted) // si le das a cualquier tecla, no le das a escape y el juego no ha empezado
        {
            AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position); // aplicamos el sonido para pasar de la escena del how to play a la de la fase 1
            gameStarted = true;   // activamos el flag gameStarted       
            StartCoroutine(StartNextLevel()); // llamamos a la corrutina para pasar a la siguiente pantalla
        }

        if(Input.GetKeyDown(KeyCode.Escape) ) // si le damos a escape, desactiva los mensajes y sal de la app
            {
            msg1.enabled = false;
            msg2.enabled = false;
            Application.Quit();
            
           
        }
    }

    IEnumerator StartNextLevel()
    {
        yield return new WaitForSeconds(delayBeforeNext); // después del tiempo indicado, carga la escena 2 ( fase 1 )
        SceneManager.LoadScene(2);
    }
}




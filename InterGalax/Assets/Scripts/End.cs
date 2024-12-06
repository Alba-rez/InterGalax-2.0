using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{

    [SerializeField] Text msg1; // texto winner
    [SerializeField] Text msg2; // texto quieres repetir ?
    [SerializeField] Text msg3; // texto presiona escape para salir
    [SerializeField] AudioClip sfx;
    [SerializeField] float delayBeforeNext; // retardo 
    [SerializeField] float blinkSpeed = 1f; // parpadeo


    private bool isBlinking = true;  // Para controlar el estado del parpadeo

    void Start()
    {
        // Llamamos a la coroutine que hace parpadear el texto
        StartCoroutine(BlinkText(msg1));
    }

    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape)) // si le das a cualquier tecla y no le das a esc
        {
            AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position); // realiza el sonido
            
            StartCoroutine(StartNextLevel()); // empieza la corrutina para pasar a la pantalla indicada
        }
        if (Input.GetKeyDown(KeyCode.Escape)) // si le das a esc, deshabilitar todos los mensajes y salir app
        {
            msg1.enabled = false;
            msg2.enabled = false;
            msg3.enabled = false;
            Application.Quit();


        }
    }

    IEnumerator StartNextLevel()
    {
        yield return new WaitForSeconds(delayBeforeNext); // retardo establecido en el motor 
        SceneManager.LoadScene(0); // pasar a la escena 0-> inicio del juego
    }

    // Corutina para hacer parpadear el mensaje con el Lerp
    IEnumerator BlinkText(Text message)
    {
        while (isBlinking)
        {
            // Calcula el valor de 'lerpTime' usando Mathf.PingPong, lo que genera un valor que oscila entre 0 y 1.
            // 'Time.time' proporciona el tiempo transcurrido desde el inicio del juego.
            // 'blinkSpeed' controla la rapidez con la que parpadea el texto.Esto permite que el valor de 'lerpTime' suba y baje continuamente, creando el efecto de parpadeo.
            
            float lerpTime = Mathf.PingPong(Time.time * blinkSpeed, 1);

            // Creamos un nuevo color con los valores de RGB del color actual del texto, pero modificando la componente alfa (transparencia) para que varíe entre 0 y 1.
            Color lerpedColor = new Color(message.color.r, message.color.g, message.color.b, lerpTime);

            message.color = lerpedColor; // Asigna el color calculado al texto para que su transparencia cambie con el tiempo.

            yield return null; // Espera el siguiente frame
        }
    }
}



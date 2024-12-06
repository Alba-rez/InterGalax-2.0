using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    
    [SerializeField] float speed; // velocidad del disparo
    [SerializeField] float temp; // temporizador para que se destruya el disparo
    [SerializeField] AudioClip sfxLife; // sonido del disparo
    
    GameManager gmanager; // ref al Game Manager

   
    private Vector3 direction = Vector3.right; // Dirección a la ue va el disparo, por defecto, hacia la derecha

    void Start()
    {
        gmanager = GameManager.GetInstance();
     
    }

    void Update()
    {
        // Actualizamos temporizador 
        temp -= Time.deltaTime;
        if (temp < 0)
        {
            Destroy(gameObject); // si el temporizador está x debajo de 0, destruye el disparo
        }

        // Actualizamos la posición usando la dirección definida
        transform.Translate(direction * speed * Time.deltaTime);
    }


    // Método para establecer la dirección del disparo según la dirección del robot.
    public void SetDirection(int robotDirection)
    {
        // Asigna la dirección del disparo según la dirección del robot
        direction = robotDirection == 1 ? Vector3.right : Vector3.left;

        // Invertir la escala si va hacia la izquierda
        if (robotDirection == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Invertir en el eje X
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1); // Normal
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (gmanager.isGameOver()) // Comprobar si el juego ha terminado antes de hacer cualquier acción
        {
            Destroy(gameObject);
            return; // Salir de la función si el juego ha terminado
        }

        Destroy(gameObject);
       
         if (other.gameObject.CompareTag("Player"))
        {
            
            gmanager.LoseLive();// Solo se destruye el disparo después de afectar al jugador

            StopAllRobots(); // Desactiva los robots
            Destroy(gameObject); // Destruye el disparo
            
           
        }

        if (other.gameObject.CompareTag("Cave"))
        {
            Destroy(gameObject);
        }



    }

   

    private void StopAllRobots()
    {
        RobotController[] robots = FindObjectsOfType<RobotController>(); // Encuentra todos los robots en la escena
        foreach (RobotController robot in robots)
        {
            robot.StopShooting(); // Llama a tu método para detener el disparo del robot
            
        }
    }








}


        




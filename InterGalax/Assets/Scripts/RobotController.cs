using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField] GameObject shoot; // referencia al disparo
    [SerializeField] float shootDelay; // retardo del disparo ( entre disparo y disparo ) 
    [SerializeField] AudioClip sfxShoot; // audio
   

    GameManager gManager;

    public float speed; // Velocidad del robot
    private int direction = 1; // Dirección del movimiento: 1 para derecha, -1 para izquierda

    public Transform player; // Referencia al transform del jugador





    private void Start()
    {
        gManager = GameManager.GetInstance(); // Inicializa gManager
     
        StartCoroutine("Shoot"); // llama a la corrutina Shoot que hace disparar a los robots
    }

    void Update()
    {
        
            // Movimiento del robot
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Si el robot choca con el terreno (Terrain), cambiamos su dirección
        if (other.gameObject.CompareTag("Terrain"))
        {
            direction *= -1; // Cambiamos la dirección del movimiento

            // Cambiamos la escala en el eje X para voltear el sprite
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x) * direction; // Invierte el signo de la escala X
            transform.localScale = newScale;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            gManager.LoseLive();
           
        }
    }

   
    public void StopShooting()
    {
        StopCoroutine("Shoot");
    }
   

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDelay); // Esperar un tiempo determinado antes de continuar con la corutina

            // Calcular la distancia al jugador
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);



            // Verificar si el disparo debe ocurrir según la distancia
            if (distanceToPlayer <= 12f) // La distancia deseada (12 metros)
            {

                // Instanciar el disparo en la posición del robot
                GameObject newShoot = Instantiate(shoot, transform.position, Quaternion.identity);

                // Pasar la dirección al ShootController del disparo instanciado
                ShootController shootController = newShoot.GetComponent<ShootController>();
                if (shootController != null)
                {
                    shootController.SetDirection(direction);
                }

                // Añadir sonido
                AudioSource.PlayClipAtPoint(sfxShoot, new Vector3(0,0,-1),1);
            }
        }
    }

   
}

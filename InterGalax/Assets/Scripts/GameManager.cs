using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Text txtScore; // está desactivado
    [SerializeField] Text txtMessage; // Texto para mensajes como "Game Over" o "Paused"
    [SerializeField] Image[] imgLives; // Imágenes que representan las vidas del jugador
    [SerializeField] AudioClip sfxGameOver; // Sonido para "Game Over"
    [SerializeField] AudioClip sfxMaxScore; // Sonido para alcanzar el puntaje máximo
    [SerializeField] AudioClip sfxPenaltySound;// Sonido para penalización
    [SerializeField] AudioClip sfxLife; // Sonido cuando el jugador pierde una vida





    GameObject player;
    GameObject spaceShip; // Referencia a la nave (si fuera necesario)


    const int SCORE_BOX = 70; // puntos cajas
    const int REST_SCORE = -50; // puntos trampas
    const int SCORE_GLASS = 30; // puntos cristales
    const int LIVES = 3; // vidas iniciales



    public Image barOfFuel; // Referencia a la barra de vida
    public int maxScore; // Define el puntaje máximo para llenar la barra
    public int score; // al final se usa solo para pruebas

    int lives = LIVES;
    int sceneId;
    bool gameover;
    bool paused = false;
    bool hasPlayedMaxScoreSound = false; // Variable booleana para controlar el sonido
    bool hasPlayedPenaltySound = false;


    // Referencias a las imágenes
    Image[] imgLivesRefs;


    // Singleton: Obtiene la instancia del GameManager
    public static GameManager GetInstance()
    {
        return instance;
    }

    // Método Awake para configurar el patrón Singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);// No destruir el GameManager entre escenas



        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destruir el GameManager si ya existe una instancia
        }


    }

    // Suscribirse al evento de cambio de escena
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Desuscribirse al evento de cambio de escena
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    // Método llamado cuando una escena se ha cargado
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Guardar la escena anterior antes de cambiar
        PlayerPrefs.SetInt("PreviousScene", sceneId);
        PlayerPrefs.Save();

        // Si se carga la escena 0 (inicio) o 6 (final), destruir el GameManager
        if (scene.buildIndex == 0|| scene.buildIndex== 6)
        {
            // Destruir el GameManager cuando se carga la escena 0
            Destroy(gameObject);
        }

        InitializeGameUI();

        LoadPlayerData();// Carga los datos del jugador (vidas, puntaje)


        // Actualiza el ID de la escena
        if (scene.buildIndex != 0 && scene.buildIndex != 1 && scene.buildIndex!=6)
        {
            sceneId = scene.buildIndex;
        }

        OnGUI(); // Actualizar UI
    }
    void Start()
    {
        sceneId = SceneManager.GetActiveScene().buildIndex;

        lives = LIVES; // establece las vidas a 3

        // Recuperar referencia al jugador
        player = GameObject.FindGameObjectWithTag("Player");



    }

    // Método para añadir puntos basado en la etiqueta del objeto
    public void AddScore(string tag)
    {
        int pts = 0;

        switch (tag)
        {
            case "Box":
                pts = SCORE_BOX;
                break;
            case "Traps":
                pts = REST_SCORE;
                break;
            case "Glass":
                pts = SCORE_GLASS;
                break;
                

        }
        score += pts; // añadir los puntos a la variable score ( sumar) 
        OnGUI(); // Actualizar la UI


    }
    public int getScore() // obtener la puntuación
    {
        return score;
    }

    public void setLives(int numLives) // establecer las vidas
    {
        lives = numLives;
    }


    public int getLives() // obtener las vidas
    {
        return lives;
    }
    public bool isGameOver()
    {
        return gameover;
    }


    public bool isGamePaused()
    {
        return paused;
    }



    public void LoseLive()
    {

        if (lives <= 0) return; // Evitar perder vidas si ya está en 0

        lives--;  // Disminuir vidas



        // Guardar el nuevo valor de vidas en PlayerPrefs
        PlayerPrefs.SetInt("CurrentLives", lives);
        PlayerPrefs.Save();

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {           

            // Reproduce el sonido de vida perdida antes de recargar la escena

            AudioSource.PlayClipAtPoint(sfxLife, Camera.main.transform.position);
            StartCoroutine(ReloadSceneAfterDelay(0.5f)); // Espera 0.5 segundos antes de recargar la escena
        }

        
    }

    // Recargar la escena actual después de un retraso
    private IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OnGUI();
    }


    private void InitializeGameUI()
    {
        // Solo inicializa la UI si no estamos en la escena 0 (presentación) o 1 o 6 ( final ) 
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 6)
        {

            // inicializa los objetos que buscará el GameManager entre escenas

            txtMessage = GameObject.Find("Message")?.GetComponent<Text>();
            player = GameObject.FindGameObjectWithTag("Player");
            spaceShip = GameObject.FindGameObjectWithTag("Ship");
            barOfFuel = GameObject.Find("barOfFuel")?.GetComponent<Image>();

            // Aquí restablecemos los sonidos cuando se carga una nueva escena

            hasPlayedMaxScoreSound = false; // Restablece el sonido de maxScore
            hasPlayedPenaltySound = false; // Restablece el sonido de penalización

            imgLivesRefs = new Image[LIVES]; // Inicializa el array de vidas
            for (int i = 0; i < LIVES; i++)
            {
                string lifeName = "Life" + (i + 1);
                GameObject lifeObject = GameObject.Find(lifeName);
                if (lifeObject != null)
                {
                    imgLivesRefs[i] = lifeObject.GetComponent<Image>();
                }
            }
        }
        else
        {
            // Si estamos en la escena 0 o 1, restablece las referencias de la UI
            txtMessage = null;
            player = null;
            spaceShip = null;
            barOfFuel = null;
            imgLivesRefs = null; // Restablecer referencias
        }
    }

    private void LoadPlayerData()  
    {
        // Comprobar la escena anterior
        int previousScene = PlayerPrefs.GetInt("PreviousScene", -1); // -1 si no hay escena previa

        // Si venimos de la escena 0 o 1, establecer vidas a 3
        if (SceneManager.GetActiveScene().buildIndex == 2 && (previousScene == 0 || previousScene == 1))
        {
            lives = LIVES; // Reiniciar vidas a 3
        }
        else
        {
            // Cargar vidas desde PlayerPrefs
            lives = PlayerPrefs.GetInt("CurrentLives", LIVES); // Cargar vidas guardadas
        }

        score = 0; // Restablecer el puntaje si es necesario
        gameover = false; // Reiniciar el estado del juego
    }
    public void GameOver()
    {
        gameover = true;
        Time.timeScale = 1; // Detener el tiempo del juego
        AudioSource.PlayClipAtPoint(sfxGameOver, Camera.main.transform.position);
        txtMessage.text = "GAME OVER \n PRESS <RET> TO START";
        player.SetActive(false); // desactivar al player
        StopRobotShooting(); // parar los disparos de los robots


    }

    void StopRobotShooting()
    {
        // Busca todos los robots y llama a su método para detener el disparo

        RobotController[] robots = FindObjectsOfType<RobotController>();
        foreach (RobotController robot in robots)
        {
            robot.StopShooting();
        }
    }


    private void OnGUI()
    {


        if (txtMessage != null)
        {
            if (gameover)

                txtMessage.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabla1", "013"); // Clave para "GAME OVER \n PRESS <RET> TO START"

            else if (paused)

                txtMessage.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabla1", "014"); // Clave para "PAUSED \nPRESS <P> TO RESUME"
                
            else
                txtMessage.text = "";
        }

        if (imgLivesRefs == null)
        {
            imgLivesRefs = new Image[imgLives.Length];

            for (int i = 0; i < imgLives.Length; i++)
            {
                imgLivesRefs[i] = imgLives[i];
            }
        }

        // Actualizar las imágenes de las vidas según el número de vidas restantes

        for (int i = 0; i < imgLivesRefs.Length; i++)
        {
            if (imgLivesRefs[i] != null)
                imgLivesRefs[i].enabled = i < lives; // Mostrar las vidas restantes
        }



    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Application.Quit();
        }
        else if (!gameover)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (paused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }



        }

        if (lives <= 0)
        {
            gameover = true;// El juego ha terminado
        }

        if (gameover)
        {
            BlinkText(txtMessage); // Hacer que el texto parpadee mientras esté en estado de Game Over
        }

        if (gameover && Input.GetKeyUp(KeyCode.Return))
        {
            // Reiniciar el número de vidas a 3     
            lives = LIVES;
            txtMessage.text = "";


            // Guardar el nuevo valor de vidas en PlayerPrefs
            PlayerPrefs.SetInt("CurrentLives", lives);

            if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
            {
                SceneManager.LoadScene(2); // tiene que cargar la escena 2 y volver a empezar
            }

            if(SceneManager.GetActiveScene().buildIndex == 5)
            {
                SceneManager.LoadScene(3); // tiene que cargar la escena 3 
            }

        }


        barOfFuel.fillAmount = (float)score / maxScore;  // Actualizar la barra de combustible según el puntaje

        MaxScore();  // Verificar si se alcanzó el puntaje máximo


    }

    void MaxScore()
    {
        // Verifica si el puntaje es igual o superior a maxScore
        if (getScore() >= maxScore && !hasPlayedMaxScoreSound)
        {

            AudioSource.PlayClipAtPoint(sfxMaxScore, Camera.main.transform.position);
            hasPlayedMaxScoreSound = true; // Marca que el sonido se ha reproducido
            hasPlayedPenaltySound = false; // Resetea el sonido de penalización

        }


        // Verifica si el puntaje es menor a maxScore

        if (getScore() < maxScore)
        {
            // Reproduce el sonido de penalización solo si ha sonado el MaxScore antes y no se ha reproducido la penalización
            if (hasPlayedMaxScoreSound && !hasPlayedPenaltySound)
            {
                AudioSource.PlayClipAtPoint(sfxPenaltySound, Camera.main.transform.position);
                hasPlayedPenaltySound = true; // Marca que el sonido de penalización se ha reproducido
                hasPlayedMaxScoreSound = false;
            }
        }


    }



    void PauseGame()
    {

        paused = true;
        Camera.main.GetComponent<AudioSource>().Stop();
        txtMessage.text = "PAUSED \nPRESS <P> TO RESUME";
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        paused = false;
        Camera.main.GetComponent<AudioSource>().Play();
        txtMessage.text = "";
        Time.timeScale = 1;

    }

    // Función para hacer parpadear el texto de Game Over
    void BlinkText(Text text)
    {
        float alpha = Mathf.PingPong(Time.time, 1);// Oscilar el valor de alpha
        Color color = text.color;
        color.a = alpha; // Ajustar la opacidad del texto
        text.color = color;
    }
}
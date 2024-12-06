
## Dificultades : 

Nesta nova versión de InterGalaxies, o xogador e os robots interactúan de maneira directa: cando colisionan, prodúcese unha reacción que simula o impacto entre ambos. Esta funcionalidade non estaba presente na versión 1, xa que temía que puidese complicar o movemento dos inimigos na escena. Ao implementalo, enfronteime a un gran desafío: cando os robots chocaban co xogador, perdían o rumbo e non conseguía que retomasen a súa traxectoria inicial.

Nun primeiro intento, decidín paralizalos tras a colisión, pero iso provocaba que, unha vez o xogo iniciaba, os robots xa non se movían máis. Posteriormente, tratei de facer que regresasen á súa posición inicial, pero seguían comportándose de forma errática: conseguían completar unha ida correctamente, pero non eran quen de volver.

Finalmente, optei por reiniciar a escena desde o comezo cada vez que o personaxe perdese unha vida. Isto implicaba recargar a escena ao completo, unha solución que tamén trouxo os seus propios retos. Por exemplo, tiven problemas para manter o número de vidas de fase en fase: incluso despois de completar o xogo, ao regresar á fase inicial, as vidas non se reiniciaban a 3 como correspondía. En lugar diso, o xogador comezaba a fase 1 coas mesmas vidas que lle quedaban na fase 4.

Resolver este problema levoume aproximadamente unha semana. A solución pasou por implementar un sistema que gardase o número de escena e, dependendo de se o xogador accedía á fase 1 desde a escena inicial (0) ou directamente dende a fase 1, as vidas reiniciábanse automaticamente a 3.

Ademais, apliquei esta regra a cada perda de vida, xa fose por colisión cun robot ou por recibir un disparo. Agora, tras unha interacción que implique a perda de vida, o robot desaparece da escena e todo se reinicia correctamente. Finalmente, esta solución funcionou perfectamente.

Polo tanto as seguintes áreas poderían ser as que máis problemas me deron:


1. **Xestión das vidas e puntuación (GameManager):**
   - **Problemas comúns**: O manexo das vidas e a puntuación acumulada pode ser difícil de depurar se non se actualizan correctamente no 
                             momento adecuado. Os métodos como `LoseLife()` e `AddScore()` dependen de eventos específicos (como colisións cos inimigos ou recoller obxectos) e deben manexarse coidadosamente para evitar inconsistencias no estado do xogo.


1. **Xestión da Colisión cos inimigos**
   - **Problemas comúns**: As interaccións entre o xogador e os inimigos poden derivar en comportamentos inesperados. 
                        Por exemplo, cando se produce unha colisión, os robots poden perder a súa traxectoria ou quedar paralizados, 
                        afectando negativamente á dinámica do xogo. Ademais, se as colisións non están vinculadas correctamente coa perda de vidas 
                        ou co reinicio da escena, poden xurdir inconsistencias no progreso.
   


**Resumo:**
- A xestión das interaccións co inimigo e a persistencia de datos entre escenas foron retos significativos. 
A implementación dun sistema que reinicia as escenas ao perder unha vida, sincronizando as vidas co número de escena, 
foi clave para superar os problemas. Isto permite unha experiencia de xogo máis fluída e coherente, mesmo cando se producen colisións ou 
perdas de vidas.

Código GameManager.cs : 

```csharp

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Text txtScore; // est� desactivado
    [SerializeField] Text txtMessage; // Texto para mensajes como "Game Over" o "Paused"
    [SerializeField] Image[] imgLives; // Imaxes que representan as vidas do jxogador
    [SerializeField] AudioClip sfxGameOver; // Sonido para "Game Over"
    [SerializeField] AudioClip sfxMaxScore; // Sonido para alcanzar el puntaje m�ximo
    [SerializeField] AudioClip sfxPenaltySound;// Sonido para penalizaci�n
    [SerializeField] AudioClip sfxLife; // Sonido cuando el jugador pierde una vida





    GameObject player;
    GameObject spaceShip; // Referencia a la nave (si fuera necesario)


    const int SCORE_BOX = 70; // puntos cajas
    const int REST_SCORE = -50; // puntos trampas
    const int SCORE_GLASS = 30; // puntos cristales
    const int LIVES = 3; // vidas iniciales



    public Image barOfFuel; // Referencia a la barra de vida
    public int maxScore; // Define el puntaje m�ximo para llenar la barra
    public int score; // al final se usa solo para pruebas

    int lives = LIVES;
    int sceneId;
    bool gameover;
    bool paused = false;
    bool hasPlayedMaxScoreSound = false; // Variable booleana para controlar el sonido
    bool hasPlayedPenaltySound = false;


    // Referencias a las im�genes
    Image[] imgLivesRefs;


    // Singleton: Obtiene la instancia del GameManager
    public static GameManager GetInstance()
    {
        return instance;
    }

    // M�todo Awake para configurar el patr�n Singleton
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


    // M�todo llamado cuando una escena se ha cargado
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

        LoadPlayerData();// Carga los datos del jugador (vidas, puntuación)


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

    // M�todo para a�adir puntos basado en la etiqueta del objeto
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
        score += pts; // a�adir los puntos a la variable score ( sumar) 
        OnGUI(); // Actualizar la UI


    }
    public int getScore() // obtener la puntuaci�n
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



    public void LoseLife()
    {

        if (lives <= 0) return; // Evitar perder vidas si ya est� en 0

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

    // Recargar la escena actual despu�s de un retraso
    private IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OnGUI();
    }


    private void InitializeGameUI()
    {
        // Solo inicializa la UI si no estamos en la escena 0 (presentaci�n) o 1 o 6 ( final ) 
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 6)
        {

            // inicializa los objetos que buscar� el GameManager entre escenas

            txtMessage = GameObject.Find("Message")?.GetComponent<Text>();
            player = GameObject.FindGameObjectWithTag("Player");
            spaceShip = GameObject.FindGameObjectWithTag("Ship");
            barOfFuel = GameObject.Find("barOfFuel")?.GetComponent<Image>();

            // Aqu� restablecemos los sonidos cuando se carga una nueva escena

            hasPlayedMaxScoreSound = false; // Restablece el sonido de maxScore
            hasPlayedPenaltySound = false; // Restablece el sonido de penalizaci�n

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
        // Busca todos los robots y llama a su m�todo para detener el disparo

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

        // Actualizar las im�genes de las vidas seg�n el n�mero de vidas restantes

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
            BlinkText(txtMessage); // Hacer que el texto parpadee mientras est� en estado de Game Over
        }

        if (gameover && Input.GetKeyUp(KeyCode.Return))
        {
            // Reiniciar el n�mero de vidas a 3     
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


        barOfFuel.fillAmount = (float)score / maxScore;  // Actualizar la barra de combustible seg�n el puntaje

        MaxScore();  // Verificar si se alcanz� el puntaje m�ximo


    }

    void MaxScore()
    {
        // Verifica si el puntaje es igual o superior a maxScore
        if (getScore() >= maxScore && !hasPlayedMaxScoreSound)
        {

            AudioSource.PlayClipAtPoint(sfxMaxScore, Camera.main.transform.position);
            hasPlayedMaxScoreSound = true; // Marca que el sonido se ha reproducido
            hasPlayedPenaltySound = false; // Resetea el sonido de penalizaci�n

        }


        // Verifica si el puntaje es menor a maxScore

        if (getScore() < maxScore)
        {
            // Reproduce el sonido de penalizaci�n solo si ha sonado el MaxScore antes y no se ha reproducido la penalizaci�n
            if (hasPlayedMaxScoreSound && !hasPlayedPenaltySound)
            {
                AudioSource.PlayClipAtPoint(sfxPenaltySound, Camera.main.transform.position);
                hasPlayedPenaltySound = true; // Marca que el sonido de penalizaci�n se ha reproducido
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

    // Funci�n para hacer parpadear el texto de Game Over
    void BlinkText(Text text)
    {
        float alpha = Mathf.PingPong(Time.time, 1);// Oscilar el valor de alpha
        Color color = text.color;
        color.a = alpha; // Ajustar la opacidad del texto
        text.color = color;
    }
}

```


# Solucións implementadas no `GameManager.cs`

Este código do **GameManager.cs** soluciona varios dos problemas mencionados na xestión das vidas, a puntuación, a interacción cos robots e a transición entre escenas. Aquí están as solucións específicas que resolve:

## 1. Xestión de vidas ao longo das escenas
- **Problema resolto:**  
  As vidas non se reiniciaban correctamente ao iniciar unha nova partida despois de pasar por diferentes fases. Ao finalizar o xogo e volver comezar, as vidas quedaban gardadas do estado da partida anterior, salvo nos casos de **Game Over**, onde si se reiniciaban correctamente a 3.

- **Solución no código:**  
  - Implementouse un sistema para gardar e recuperar as vidas usando `PlayerPrefs`.  
  - Ao comezar unha nova partida desde a escena inicial (0 ou 1), o método `LoadPlayerData()` establece explicitamente as vidas a 3.  
  - Isto evita que o xogador inicie cun número incorrecto de vidas herdadas da partida anterior.

---

## 2. Reinicio da escena tras perder unha vida
- **Problema resolto:**  
  O robot perdía o rumbo tras colisionar e non retomaba o comportamento esperado.

- **Solución no código:**  
  - Cando o xogador perde unha vida, chámase a unha corutina (`ReloadSceneAfterDelay`) que reinicia a escena actual despois dun pequeno atraso. Isto asegura que todos os obxectos volven ao seu estado inicial.  
  - Este enfoque tamén elimina a necesidade de tentar "corrixir" con implementacións extra o comportamento do robot, xa que a escena se carga completamente de novo.

---

## 3. Transicións suaves entre escenas
- **Problema resolto:**  
  As vidas ou o estado do xogador non se restauraban correctamente ao pasar dunha escena a outra.

- **Solución no código:**  
  - O patrón Singleton (`DontDestroyOnLoad`) permite que o `GameManager` persista entre escenas, gardando os datos necesarios (vidas, puntuación, escena previa).  
  - No método `OnSceneLoaded()`, o `GameManager` inicializa a UI e recupera o estado do xogador (como vidas e puntuación) segundo a escena cargada.  
  - Ademais, as vidas reinícianse correctamente a 3 ao entrar na escena 3 (fase 1) dende o menú ou dende unha partida anterior.

---

## 4. Game Over e reinicio
- **Nota:**  
  O **Game Over** nunca presentou problemas. Era o único momento onde as vidas se reiniciaban correctamente a 3. Ao reiniciar unha nova partida tras un Game Over, o xogador comezaba co número correcto de vidas.

---

## 5. Resolución de erros de comportamento dos robots
- **Problema resolto:**  
  Os robots non regresaban ao seu comportamento normal despois de colisionar co xogador.

- **Solución no código:**  
  - O método `ReloadSceneAfterDelay` asegura que a escena completa se recarga, restaurando a posición e o comportamento dos robots. Isto elimina o problema de "perda de rumbo".


## Reflexión : 


O desenvolvemento de **InterGalax** foi unha experiencia enriquecedora tanto a nivel técnico como persoal. Comecei con ideas simples, pero co tempo e os desafíos que enfrontei, o proxecto converteuse nunha lección de aprendizaxe continua. 
Durante este proceso, aprendín a importancia de planificar, depurar e ser paciente cando as cousas non saen como esperaba.

### Os desafíos: 

Un dos maiores retos foi a xestión das vidas e a súa persistencia entre escenas. Ao principio, parecía algo sinxelo, pero de seguido me decatei 
de que pequenos detalles, como non reiniciar correctamente as vidas ao comezar unha nova partida, podían complicar moito o xogo. 
Resolver este problema levou tempo, pero deume a oportunidade de mellorar a miña capacidade para xestionar datos entre escenas e reforzar 
o uso de ferramentas como `PlayerPrefs`.

Outro desafío importante foi conseguir que os robots interactuaran co xogador sen perder o seu comportamento esperado. 
A solución que atopei —reiniciar a escena tras unha colisión— ensinoume que ás veces é mellor simplificar e reconstruír unha solución 
desde o principio que tratar de parchear un sistema roto.


A pesar dos retos, conseguir que todo funcionase correctamente foi extremadamente gratificante. 
Ver como cada peza se encaixa no xogo, desde o sistema de puntuación ata as animacións e os efectos sonoros, reforzou a miña confianza 
como desenvolvedora. Ademais, traballar cun estilo visual de **pixel art** e incorporar elementos como o **parallax** e a **xestión de idiomas** fíxome reflexionar sobre a importancia de equilibrar a estética coa funcionalidade.

### Aprendizaxes para futuros proxectos

Se algo aprendín, é que cada decisión no desenvolvemento conta. Aquí deixo algunhas aprendizaxes clave:

- **Prototipar sempre:** Antes de implementar funcionalidades complexas, probar versións máis simples pode aforrar moito tempo e frustración.
- **Planificar o comportamento global:** O uso de patróns como Singleton foi fundamental para xestionar o estado do xogo e garantir a coherencia entre escenas.
- **Testar en cada etapa:** Moitos problemas non se detectaron ata fases avanzadas porque non fixen suficientes probas en estados intermedios do xogo.
- **Aceptar os erros como parte do proceso:** Cada problema técnico que enfrontei converteuse nunha oportunidade para mellorar as miñas habilidades.

## O futuro de InterGalax

Agora que teño unha versión funcional e divertida do xogo, o meu obxectivo é melloralo aínda máis, incorporando novos niveis, inimigos máis desafiantes 
e características que enriquezan a experiencia do xogador. 

O desenvolvemento de **InterGalax** ensinoume que o máis importante non é chegar ao final, senón desfrutar do camiño e aprender todo o posible no proceso.

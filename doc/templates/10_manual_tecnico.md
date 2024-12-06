# **Manual Técnico de InterGalax**

## **1. Introdución**
**InterGalax** é un xogo de plataformas 2D desenvolvido en Unity, que combina elementos de pixel art, mecánicas de xogo baseadas en colisións e animacións, e un sistema multilingüe. Este manual técnico describe a configuración, as estruturas principais e os compoñentes que fan funcionar o xogo.

---

## **2. Requisitos Técnicos**

### **Hardware**
- Procesador: Intel Core i3 ou superior.
- Memoria RAM: 4 GB ou máis.
- Espazo en disco: 500 MB.
- Gráficos: Tarxeta compatible con DirectX 10 ou superior.

### **Software**
- **Motor de xogo:** Unity 2023.1 ou superior.
- **Linguaxe de programación:** C#.
- **Outras ferramentas:**
  - **Photoshop/Aseprite:** Para creación e edición de sprites.
  - **GitLab:** Para control de versións e distribución.
  - **Localization Package:** Para xestión multilingüe.

---

## **3. Configuración Inicial**

### **Instalación de Dependencias**
1. Instalar Unity Hub e a versión compatible de Unity.
2. Descargar o proxecto desde GitLab:  
   `git clone <https://gitlab.iessanclemente.net/damd/a22albaaa.git>`
3. Abrir a carpeta clonada no Unity Hub -> Open -> Add Project from Disk.

### **Configuración de SceneManager**
As escenas están configuradas no Build Settings para garantir a navegación correcta entre fases.

**Scenes Incluídas:**
- 0. Pantalla de Inicio.
- 1. "How to play"
- 2. Fase 1: Planeta Árido.
- 3. Fase 2: Planeta Vexetal.
- 4. Fase 3: Planeta Xeado.
- 5. Fase 4: Planeta Mineiro.
- 6. Pantalla Final.

### **Estrutura do Proxecto**

#### **Carpetas Principais**
- **Assets:** Inclúe AddressableAssetsData, Localization, Animations, Materials, Music, Prefabs, Scripts, Scenes e Tilesets.
- **Sprites/:** Fondos, personaxes, obxectos e elementos de interface.
- **Scripts/:** Código fonte en C#.
- **Animations/:** Controladores de animación.
- **Localization/:** Táboas de localización para galego e inglés.
- **Scenes:** Cada unha das escenas do xogo.
- **Prefabs:** Obxectos configurados reutilizables, como robots, caixas, disparos, movemento das serras, trampas láser, efecto explosión.
- **Audio:** Clips de son para efectos e música.

#### **Scripts Principais**

##### **StartGame.cs**
A clase **StartGame** xestiona a introdución e a transición ao xogo, amosando mensaxes no principio e permitindo ao xogador seleccionar o idioma antes de empezar. O xogo tamén reproduce sons e controla a navegación entre as escenas.

**Atributos Principais**
- **msg1, msg2, msg3, msg4:** Mensaxes que se mostran ao xogador, configuradas no editor.
- **languageButtons:** Obxectos de interface (como as bandeiras) para seleccionar o idioma.
- **typingSpeed:** Velocidade co que se mostra o texto nas mensaxes.
- **sfxTyping:** Sonido que se reproduce ao escribir as mensaxes.
- **msgSelect:** Mensaxe para indicar que se seleccione un idioma.
- **gameStarted:** Flag que indica se o xogo comezou ou non.

**Métodos Principais**
1. **Start():** Inicializa os mensaxes como desactivados e configura os botóns de idioma.
2. **Update():**
   - Espera a que o xogador presione calquera tecla ou a barra espaciadora para comezar o xogo ou cambiar de escena.
   - Se todos os mensaxes foron amosados, permite saír do xogo ao presionar Escape.
3. **OnLanguageSelected():** Cambia o idioma e comeza a escribir os mensaxes de forma localizable.
4. **TypeLocalizedMessage():** Método que escribe os mensaxes carácter por carácter, simulando a escritura mecanografiada, e reproduce un son cada vez que se engade un carácter.
5. **StartNextLevel():** Comeza a seguinte escena despois dun pequeno atraso.



```csharp
public class StartGame : MonoBehaviour
{
    AudioSource sfxTyping;
    [SerializeField] Text msg1; // breve historia de Astro
    [SerializeField] Text msg2; // texto "presiona tecla"
    [SerializeField] Text msg3; // texto presiona "espacio" para ir a how to play
    [SerializeField] Text msg4; // texto para salir del juego
    [SerializeField] Text msgSelect; // texto para seleccionar idioma
    [SerializeField] float typingSpeed; // velocidad de typeo
    [SerializeField] float delayBeforeNextMessage; // retardo entre msg1 y los dem�s mensajes
    [SerializeField] float msg1DisplayTime; // tiempo que tarda en escribirse el msg1
    [SerializeField] AudioClip sfx;
    [SerializeField] GameObject languageButtons; // Las banderas para seleccionar idioma

   // Flags para los mensajes
    private bool message2Complete = false;
    private bool message3Complete = false;
    private bool message4Complete = false;
    private bool gameStarted = false;


    void Start()
    {

        // mensajes desactivados al incio del juego
        msg1.enabled = false;
        msg2.enabled = false;
        msg3.enabled = false;
        msg4.enabled = false;

        languageButtons.SetActive(true); // activa los botones bandera
        sfxTyping = GetComponent<AudioSource>();
        sfxTyping.Stop(); //el sonido del typeo se cancela hasta que empieza a escribirse el mensaje

    }

    void Update()
    {


        // Verificar si se ha completado el segundo mensaje y si el jugador presiona cualquier tecla
        if (message2Complete && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && !Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position);
            msg2.enabled = false;
            msg3.enabled = false;
            msg4.enabled = false;
            gameStarted = true;
            StartCoroutine(StartNextLevel());
        }

        // Si se ha completado el segundo mensaje y el jugador presiona espacio, ir a la siguiente escena
        if (message2Complete && Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Escape) && !gameStarted)
        {
            SceneManager.LoadScene(1);
        }

        // Si se han completado todos los mensajes y el jugador presiona Escape, cerrar el juego
        if (message2Complete && message3Complete && message4Complete && Input.GetKeyDown(KeyCode.Escape))
        {
            msg2.enabled = false;
            msg3.enabled = false;
            msg4.enabled = false;
            Application.Quit();
        }
    }

    // Cambiar el idioma y activar la escritura de los mensajes
    public void OnLanguageSelected(string languageCode)
    {
        // Cambiar idioma basado en el c�digo seleccionado (ejemplo: "en", "gl-ES")
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales.Find(locale => locale.Identifier.Code == languageCode);

        languageButtons.SetActive(false);
        msgSelect.enabled = false;


        
        // Iniciar el proceso de escritura de los mensajes
        StartCoroutine(TypeLocalizedMessage(msg1, "001"));
        msg1.enabled = true;

    }

    IEnumerator TypeLocalizedMessage(Text messageText, string localizedStringKey)
    {
        // Asegura de que el texto est� vac�o antes de escribir
        messageText.text = "";

        // Usar el LocalizedString para obtener la traducci�n
        LocalizedString localizedMessage = new LocalizedString { TableReference = "Tabla1", TableEntryReference = localizedStringKey };
        yield return localizedMessage.GetLocalizedStringAsync();

        // Asegura de que el texto est� vac�o antes de escribir
        messageText.text = "";

        // Reproducir el sonido de typing cuando empieza el tipo de mensaje
        sfxTyping.Play();

        foreach (char letter in localizedMessage.GetLocalizedString())
        {
            messageText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Cuando termine el tipo de mensaje
        if (messageText == msg1)
        {
            sfxTyping.Stop();
            yield return new WaitForSeconds(msg1DisplayTime);
            messageText.enabled = false;

            sfxTyping.Play();
            StartCoroutine(TypeLocalizedMessage(msg2, "002"));
            msg2.enabled = true;

            StartCoroutine(TypeLocalizedMessage(msg3, "004"));
            msg3.enabled = true;

            StartCoroutine(TypeLocalizedMessage(msg4, "003"));
            msg4.enabled = true;
        }
        else if (messageText == msg2)
        {
            message2Complete = true;
        }
        else if (messageText == msg3)
        {
            message3Complete = true;
        }
        else if (messageText == msg4)
        {
            message4Complete = true;
            sfxTyping.Stop();
        }
    }

    IEnumerator StartNextLevel()
    {
        yield return new WaitForSeconds(delayBeforeNextMessage);
        SceneManager.LoadScene(2);
    }
}

```

**Fluxo do Xogo**
- O xogador selecciona un idioma e os mensaxes de introdución se amosan de forma gradual, utilizando a función de escritura simulada (`TypeLocalizedMessage`).
- Dependendo da interacción do xogador, o xogo pode pasar a outra escena ou pecharse.
- O proceso de escritura de mensaxes é dinámico e basease na localización seleccionada.

**Interaccións Clave**
- O xogo permite ao xogador seleccionar un idioma, e os mensaxes se presentan segundo a configuración local.
- A interacción principal para avanzar no xogo é a presión de teclas como **Espacio** para ir á pantalla de como xogar, **Escape** para saír ou calque tecla para ir directamente á partida.

##### **GameManager.cs**  
Descrición: Controla o estado global do xogo, incluíndo vidas, puntuación e transicións de nivel, así como a interacción coa UI (interfaz de usuario).

**Atributos Principais**
- **score:** Puntaxe acumulada polo xogador que se transforman en combustible na barra de progreso.
- **lives:** Número de vidas do xogador.
- **gameover:** Flag que indica se o xogo rematou.
- **paused:** Flag que indica se o xogo está pausado.
- **barOfFuel:** Barra de combustible, que se enche segundo a puntaxe.
- **sfx:** Sons para eventos como Game Over, puntuación máxima, baixar da puntuación máxima, penalización e perder vidas.

**Métodos Importantes**
1. **Awake():** Inicializa o GameManager como único na escena, evitando duplicados.
2. **OnSceneLoaded():** Xestiona a transición entre escenas e garda datos como a puntaxe e as vidas.
3. **AddScore():** Aumenta o puntaxe segundo o obxecto interactuado (caixas, trampas, etc.).
4. **LoseLive():** Reduce as vidas e recarga a escena se o xogador perde unha vida.
5. **GameOver():** Activa o estado de "Game Over" e detén as accións do xogo.
6. **OnGUI():** Actualiza a interface de usuario (UI), amosando a barra de progreso e as vidas restantes.
7. **MaxScore():** Reproduce sons cando se alcanza o puntaxe máximo ou cando se baixa desa puntaxe máxima.
8. **PauseGame() / ResumeGame():** Xestiona a pausa e a reanudación do xogo.


```csharp

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Text txtScore; // est� desactivado
    [SerializeField] Text txtMessage; // Texto para mensajes como "Game Over" o "Paused"
    [SerializeField] Image[] imgLives; // Im�genes que representan las vidas del jugador
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
        score += pts; // añadir los puntos a la variable score ( sumar) 
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
            for (int i = 0; i < LIFES; i++)
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


##### **PlayerController.cs**  
A clase **PlayerController** xestiona os movementos do xogador, como camiñar, saltar e xirar. Controla tamén as animacións do personaxe (como camiñar e saltar) e a súa posición. A clase tamén inclúe a capacidade de reiniciar a posición do xogador.

**Atributos Principais**
- **speed:** A velocidade de movemento do xogador.
- **jumpSpeed:** A forza do salto do xogador.
- **startPosition:** A posición inicial do xogador, que se almacena cando comeza a partida.
- **rb:** Referencia ao `Rigidbody2D` do xogador, utilizado para aplicar físicas.
- **col:** Referencia ao `Collider2D` do xogador para detectar colisións.
- **anim:** Referencia ao `Animator` do xogador para controlar as animacións.
- **jump:** Flag que indica se o xogador está a saltar ou non.
- **movex:** Valor que representa a dirección de movemento horizontal (dereita/esquerda).

**Métodos Principais**
1. **Start():** Inicializa os compoñentes necesarios como `Rigidbody2D`, `Collider2D` e `Animator`. Tamén garda a posición inicial do xogador.
2. **Update():** Controla a entrada do xogador (movemento horizontal e salto). Se o xogador presiona o botón de salto, establece a variable `jump` como verdadeira.
3. **FixedUpdate():** Chama aos métodos de movemento (`Walk()`), xiro (`Flip()`) e salto (`Jump()`) de forma fixa para asegurar un control suave do xogador.
4. **Walk():** Controla o movemento horizontal do xogador, axustando a velocidade do `Rigidbody2D` e activando ou desactivando a animación de camiñar.
5. **Flip():** Controla o xiro do xogador dependendo da dirección do movemento horizontal, cambiando a escala do personaxe.
6. **Jump():** Controla o salto do xogador. Se o xogador non está a saltar, non fai nada, pero se está en contacto co chan ou plataformas, aplica unha forza para saltar e activa a animación de salto.



```csharp

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed; // Velocidad de movimiento del jugador
    [SerializeField] float jumpSpeed; // Velocidad del salto

    Rigidbody2D rb; // Componente para la f�sica 2D
    Collider2D col; // Componente para detectar colisiones
    Animator anim; // Componente para manejar las animaciones del jugador
    bool jump; // Flag para controlar si el jugador debe saltar
    float movex; // Variable para almacenar la entrada del movimiento horizontal

    // Referencia a la posici�n inicial del jugador
    public Vector3 startPosition;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

        // Guardar la posici�n inicial del jugador para poder reiniciar
        startPosition = transform.position;

    }

    void FixedUpdate()
    {
        Walk(); // caminar con el jugador
        Flip(); // cambiar de direcci�n
        Jump(); // saltar
    }


    void Update()
    {
        movex = Input.GetAxisRaw("Horizontal"); // Obtiene la entrada del jugador para el movimiento horizontal
        if (!jump && Input.GetButtonDown("Jump"))  // Si el jugador no est� saltando y presiona el bot�n de salto, activa el salto

        {
            jump = true;
        }

    }
    void Walk()
    {
        Vector2 vel = new Vector2(movex * speed * Time.fixedDeltaTime, rb.velocity.y); // Calcula la velocidad horizontal con la entrada del jugador, y mantiene la velocidad vertical actual

        rb.velocity = vel;
        if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon) // Si el jugador se est� moviendo, activa la animaci�n de caminar

        {

            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);

        }

    }

    void Flip() // M�todo que maneja la rotaci�n del jugador para que mire en la direcci�n del movimiento

    {
        float vx = rb.velocity.x;
        if (Mathf.Abs(vx) > Mathf.Epsilon) // Si el jugador se est� moviendo, gira el sprite para que mire hacia la direcci�n del movimiento

        {
            transform.localScale = new Vector2(Mathf.Sign(vx), 1); // Invierte el eje X si es necesario
        }
    }
    void Jump()
    {
        if (!jump) return;// Si no se debe saltar, salimos del m�todo


        jump = false; // Reseteamos la bandera de salto

        if (!col.IsTouchingLayers(LayerMask.GetMask("Terrain", "Platform","Traps"))) // Si el jugador no est� tocando el terreno, las plataformas o las trampas, no puede saltar

            return;

        rb.velocity += new Vector2(0, jumpSpeed); // Si est� tocando el suelo o una plataforma, le damos velocidad en el eje Y para hacer el salto

        anim.SetTrigger("isJumping");// Activa la animaci�n de salto
    }

    


}


```


**Fluxo do Xogo**
- O xogador pode mover ao personaxe cara á esquerda ou dereita utilizando as teclas de movemento e tamén pode saltar se está no chan ou nunha plataforma.
- As animacións de camiñar e saltar son controladas automaticamente en función do estado do xogador.
- O xogador tamén ten a capacidade de xirar dependendo da dirección de movemento.

##### **RobotController.cs**  
A clase **RobotController** xestiona o movemento, os disparos e a interacción dos robots no xogo. Permite que os robots se desplacen de xeito automático, disparen ao xogador cando este se atopa nunha distancia determinada e cambien de dirección ao tocar co terreo. Tamén xestiona as colisións co xogador, facendo que este perda vidas.

**Atributos Principais**
- **shoot:** Prefab do disparo que o robot instanciará cando dispare.
- **shootDelay:** Tempo de espera entre cada disparo.
- **sfxShoot:** Sonido que se reproduce cando o robot dispara.
- **speed:** Velocidade do movemento do robot.
- **direction:** Dirección do movemento do robot (1 para dereita, -1 para esquerda).
- **player:** Referencia ao transform do xogador para saber a súa posición e disparar cando este estea cerca.

**Métodos Principais**
1. **Start():** Inicializa o `GameManager` e comeza a corutina de disparo.
2. **Update():** Xestiona o movemento do robot. O robot móvese continuamente de acordo coa súa dirección e velocidade.
3. **OnCollisionEnter2D():** Xestiona as colisións do robot:
   - Se toca co terreo (obxecto con tag "Terrain"), cambia de dirección e voltea o sprite do robot.
   - Se toca co xogador, desactiva o robot e chama ao método `LoseLive()` no `GameManager`.
4. **StopShooting():** Detén a corutina de disparo.
5. **Shoot():** Corutina que xestiona o disparo do robot. Despois dun retraso determinado, verifica a distancia entre o robot e o xogador, e se está dentro do rango, dispara unha bala na dirección correcta.


```csharp

public class RobotController : MonoBehaviour
{
    [SerializeField] GameObject shoot; // referencia al disparo
    [SerializeField] float shootDelay; // retardo del disparo ( entre disparo y disparo ) 
    [SerializeField] AudioClip sfxShoot; // audio
   

    GameManager gManager;

    public float speed; // Velocidad del robot
    private int direction = 1; // Direcci�n del movimiento: 1 para derecha, -1 para izquierda

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
        // Si el robot choca con el terreno (Terrain), cambiamos su direcci�n
        if (other.gameObject.CompareTag("Terrain"))
        {
            direction *= -1; // Cambiamos la direcci�n del movimiento

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



            // Verificar si el disparo debe ocurrir seg�n la distancia
            if (distanceToPlayer <= 12f) // La distancia deseada (12 metros)
            {

                // Instanciar el disparo en la posici�n del robot
                GameObject newShoot = Instantiate(shoot, transform.position, Quaternion.identity);

                // Pasar la direcci�n al ShootController del disparo instanciado
                ShootController shootController = newShoot.GetComponent<ShootController>();
                if (shootController != null)
                {
                    shootController.SetDirection(direction);
                }

                // A�adir sonido
                AudioSource.PlayClipAtPoint(sfxShoot, new Vector3(0,0,-1),1);
            }
        }
    }

   
}


```


**Fluxo do Xogo**
- O robot movease de forma automática en horizontal e cambia de dirección cando toca co terreo.
- Os robots disparan ao xogador se este se atopa a menos de 12 unidades de distancia.
- Se o robot toca ao xogador, este perde unha vida.

##### **TakeOff.cs**  
A clase **TakeOff** xestiona a mecánica de despegue da nave no xogo. Controla a transición ao seguinte nivel cando o xogador alcanza unha certa puntaxe e interactúa coa nave. Tamén reproduce sons e anima a transición ao próximo nivel ou á pantalla de inicio se o xogador xa se atopa na última escena.

**Atributos Principais**
- **anim:** Referencia ao `Animator` para activar a animación de despegue.
- **sfxTakeOff:** Sonido que se reproduce cando a nave despega.
- **manager:** Referencia ao `GameManager` para comprobar o puntaxe do xogador.
- **player:** Referencia ao xogador para desactivalo cando este atravesa a nave.

**Métodos Principais**
1. **Awake():** Inicializa as referencias ao `GameManager` e ao xogador ao inicio do xogo.
2. **OnTriggerEnter2D():** Detecta cando o xogador entra na zona da nave:
   - Se o xogador ten un puntaxe maior ou igual a 500, activa a animación de despegue e desactiva o xogador.
   - Reproduce o son do despegue e chama ao método `NextLevel()` despois de 2 segundos.
3. **NextLevel():** Carga a seguinte escena no orde, ou se o xogador está na última escena, carga a pantalla final.


```csharp
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
            if (manager.getScore() >= 0)
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



```


**Fluxo do Xogo**
- O xogador debe ter unha puntaxe de 500 ou máis puntos de combustible para activar o despegue da nave.
- Ao alcanzar a nave, o xogador é desactivado e a animación de despegue é reproducida.
- Despois do despegue, o xogo transita ao seguinte nivel ou pantalla final.

##### **ShootController.cs**
A clase **ShootController** xestiona o comportamento dos disparos no xogo, incluíndo a súa velocidade, dirección e interacción co xogador ou outros obxectos. Tamén controla o tempo de vida do disparo e as accións a realizar cando o disparo toca con diferentes obxectos, como o xogador ou as paredes.

**Atributos Principais**
- **speed:** Velocidade do disparo.
- **temp:** Tempo que dura o disparo antes de ser destruído.
- **sfxLife:** Sonido que se reproduce cando o disparo afecta ao xogador.
- **gmanager:** Referencia ao `GameManager` para controlar o estado do xogador.
- **direction:** Dirección do disparo (por defecto, cara á dereita).

**Métodos Principais**
1. **Start():** Inicializa a referencia ao `GameManager`.
2. **Update():**
   - Actualiza o temporizador (`temp`) para destruir o disparo despois dun certo tempo.
   - Move o disparo na dirección definida, actualizando a súa posición.
3. **SetDirection():** Configura a dirección do disparo segundo a dirección do robot que o disparou (dereita ou esquerda). Tamén inverte a escala do disparo se se move cara á esquerda.
4. **OnTriggerEnter2D():**
   - Controla as colisións do disparo.
   - Se o disparo toca ó xogador, chama a `LoseLive()` no `GameManager` e detén os disparos dos robots.
   - Se toca cun obxecto co tag "Cave", tamén destrúe o disparo.
   - Se o xogo está rematado, destrúe o disparo inmediatamente.
5. **StopAllRobots():** Detén os disparos de tódolos robots na escena.


```csharp

public class ShootController : MonoBehaviour
{
    
    [SerializeField] float speed; // velocidad del disparo
    [SerializeField] float temp; // temporizador para que se destruya el disparo
    [SerializeField] AudioClip sfxLife; // sonido del disparo
    
    GameManager gmanager; // ref al Game Manager

   
    private Vector3 direction = Vector3.right; // Direcci�n a la ue va el disparo, por defecto, hacia la derecha

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
            Destroy(gameObject); // si el temporizador est� x debajo de 0, destruye el disparo
        }

        // Actualizamos la posici�n usando la direcci�n definida
        transform.Translate(direction * speed * Time.deltaTime);
    }


    // M�todo para establecer la direcci�n del disparo seg�n la direcci�n del robot.
    public void SetDirection(int robotDirection)
    {
        // Asigna la direcci�n del disparo seg�n la direcci�n del robot
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
        
        if (gmanager.isGameOver()) // Comprobar si el juego ha terminado antes de hacer cualquier acci�n
        {
            Destroy(gameObject);
            return; // Salir de la funci�n si el juego ha terminado
        }

        Destroy(gameObject);
       
         if (other.gameObject.CompareTag("Player"))
        {
            
            gmanager.LoseLive();// Solo se destruye el disparo despu�s de afectar al jugador

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
            robot.StopShooting(); // Llama a tu m�todo para detener el disparo del robot
            
        }
    }
}

```

**Fluxo do Xogo**
- O disparo viaxa na dirección configurada polo robot e é destruído se colide cun obxecto (como o xogador ou o terreo).
- Se o xogador é golpeado, perde unha vida e os robots deixan de disparar.
- O disparo tamén se destrúe automaticamente se o xogo terminou ou se colide con certos obxectos.


---

## **Localización Multilingüe**

### **Configuración de Idiomas**
- **Paquete Localization:**
  - Engadir idiomas dispoñibles (en, gl-ES).
  - Crear unha táboa de localización para textos.

### **Selección de Idioma:**
- A clase `LanguageManager` controla a selección mediante botóns Canvas (bandeiras).
- O idioma seleccionado persiste durante toda a sesión.

---

### **Gráficos e Animacións**
- **Estilo:** Pixel art.
- **Resolución de Sprites:** Escalados mediante Pixels Per Unit.
- **Parallax:** Fondos configurados en capas con diferentes velocidades para profundidade visual.
- **Animacións:** Frames organizados con controladores Animator.

### **Colisións e Física**
- **Movemento:** Configurado mediante `Rigidbody2D` e `Collider2D`.
- **Plataformas:** Uso de capas como Terrain e Platforms para validar saltos.
- **Trampas:** Comprobación de colisión para restar combustible.
- **Robots:** Comprobación de colisión para restar vidas.
- **Disparos:** Comprobación de colisión para restar vidas.
- **Caixas e cristais:** Comprobación de colisión para sumar combustible.
- **Nave espacial:** Comprobación de colisión co Player para despegar.

### **Navegación entre Pantallas**
A navegación está configurada co sistema `SceneManager`:
- `SceneManager.LoadScene()`: Cambia entre as escenas cando se cumpren condicións específicas.
- As transicións inclúen sons e animacións (como o despeque da nave).

### **Resolución de Problemas Comúns**
- **Problema:** O xogo non inicia.  
  **Solución:** Comprobar que os controladores gráficos están actualizados.
  
- **Problema:** Colisións non detectadas.  
  **Solución:** Verificar que as capas están configuradas correctamente no Inspector.
  
- **Problema:** O idioma non cambia.  
  **Solución:** Comprobar que a táboa de localización inclúe as claves e os textos correctos.

### **Manexo de Recursos**
- **Sprites:** Gardados en formato PNG con transparencia.
- **Son:** Clips en formato WAV/MP3.
- **Prefabs:** Configuración predefinida para obxectos reutilizables.

### **Distribución**
O xogo é distribuído a través de GitLab:
- Compilación do proxecto en Unity para Windows (`Interstellar.exe`).
- Subida ao repositorio GitLab.
- O usuario final descarga a carpeta `Ejecutale`, descomprímela no equipo local e usa o arquivo `Interstellar.exe` para iniciar o xogo.

### **Créditos**
- **Desenvolvemento:** Alba María Álvarez Alonso.
- **Assets:** Asset Store, itch.io, IA.
- **Música e Son:** Recursos libres de dereitos.

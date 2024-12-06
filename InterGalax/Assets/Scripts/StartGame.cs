using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

public class StartGame : MonoBehaviour
{
    AudioSource sfxTyping;
    [SerializeField] Text msg1; // breve historia de Astro
    [SerializeField] Text msg2; // texto "presiona tecla"
    [SerializeField] Text msg3; // texto presiona "espacio" para ir a how to play
    [SerializeField] Text msg4; // texto para salir del juego
    [SerializeField] Text msgSelect; // texto para seleccionar idioma
    [SerializeField] float typingSpeed; // velocidad de typeo
    [SerializeField] float delayBeforeNextMessage; // retardo entre msg1 y los demás mensajes
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
        // Cambiar idioma basado en el código seleccionado (ejemplo: "en", "gl-ES")
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales.Find(locale => locale.Identifier.Code == languageCode);

        languageButtons.SetActive(false);
        msgSelect.enabled = false;


        
        // Iniciar el proceso de escritura de los mensajes
        StartCoroutine(TypeLocalizedMessage(msg1, "001"));
        msg1.enabled = true;

    }

    IEnumerator TypeLocalizedMessage(Text messageText, string localizedStringKey)
    {
        // Asegura de que el texto esté vacío antes de escribir
        messageText.text = "";

        // Usar el LocalizedString para obtener la traducción
        LocalizedString localizedMessage = new LocalizedString { TableReference = "Tabla1", TableEntryReference = localizedStringKey };
        yield return localizedMessage.GetLocalizedStringAsync();

        // Asegura de que el texto esté vacío antes de escribir
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

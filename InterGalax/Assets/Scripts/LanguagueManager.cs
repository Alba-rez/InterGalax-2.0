using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public Button englishButton; // Bot�n para cambiar a ingl�s
    public Button galicianButton; // Bot�n para cambiar a gallego

    void Start()
    {
        // Asignar el evento de clic para cada bot�n
        englishButton.onClick.AddListener(OnEnglishSelected);
        galicianButton.onClick.AddListener(OnGalicianSelected);

        
    }

    // M�todo para cambiar a ingl�s
    public void OnEnglishSelected()
    {
        // Llamar al m�todo OnLanguageSelected del StartGame para cambiar a ingl�s
        FindObjectOfType<StartGame>().OnLanguageSelected("en");
    }

    // M�todo para cambiar a gallego
    public void OnGalicianSelected()
    {
        // Llamar al m�todo OnLanguageSelected del StartGame para cambiar a gallego
        FindObjectOfType<StartGame>().OnLanguageSelected("gl-ES");
    }

   
}

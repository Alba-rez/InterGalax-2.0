using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public Button englishButton; // Botón para cambiar a inglés
    public Button galicianButton; // Botón para cambiar a gallego

    void Start()
    {
        // Asignar el evento de clic para cada botón
        englishButton.onClick.AddListener(OnEnglishSelected);
        galicianButton.onClick.AddListener(OnGalicianSelected);

        
    }

    // Método para cambiar a inglés
    public void OnEnglishSelected()
    {
        // Llamar al método OnLanguageSelected del StartGame para cambiar a inglés
        FindObjectOfType<StartGame>().OnLanguageSelected("en");
    }

    // Método para cambiar a gallego
    public void OnGalicianSelected()
    {
        // Llamar al método OnLanguageSelected del StartGame para cambiar a gallego
        FindObjectOfType<StartGame>().OnLanguageSelected("gl-ES");
    }

   
}

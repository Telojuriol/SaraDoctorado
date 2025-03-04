using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Tooltip("El bot�n que inicia el juego.")]
    public GameObject startButtonObject; // Usar GameObject para el bot�n

    void Start()
    {
        AssignStartButton();
        AddStartButtonListener();
    }

    // Asigna el componente XRSimpleInteractable al bot�n de inicio
    void AssignStartButton()
    {
        if (startButtonObject != null)
        {

        }
        else
        {
            Debug.LogError("El objeto del bot�n de inicio no est� asignado en el Inspector.");
        }
    }

    // A�ade el listener al bot�n de inicio
    void AddStartButtonListener()
    {

    }

    // Evento que se ejecuta al seleccionar el bot�n de inicio


    // Carga la escena del juego
    void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}


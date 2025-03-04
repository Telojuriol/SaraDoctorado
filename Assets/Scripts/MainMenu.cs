using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Tooltip("El botón que inicia el juego.")]
    public GameObject startButtonObject; // Usar GameObject para el botón

    void Start()
    {
        AssignStartButton();
        AddStartButtonListener();
    }

    // Asigna el componente XRSimpleInteractable al botón de inicio
    void AssignStartButton()
    {
        if (startButtonObject != null)
        {

        }
        else
        {
            Debug.LogError("El objeto del botón de inicio no está asignado en el Inspector.");
        }
    }

    // Añade el listener al botón de inicio
    void AddStartButtonListener()
    {

    }

    // Evento que se ejecuta al seleccionar el botón de inicio


    // Carga la escena del juego
    void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}


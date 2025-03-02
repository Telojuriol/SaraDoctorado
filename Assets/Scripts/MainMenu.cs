/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MainMenu : MonoBehaviour
{
    [Tooltip("El botón que inicia el juego.")]
    public GameObject startButtonObject; // Usar GameObject para el botón

    private XRSimpleInteractable startButton;

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
            startButton = startButtonObject.GetComponent<XRSimpleInteractable>();
            if (startButton == null)
            {
                Debug.LogError("No se pudo encontrar el componente XRSimpleInteractable en el objeto del botón.");
            }
        }
        else
        {
            Debug.LogError("El objeto del botón de inicio no está asignado en el Inspector.");
        }
    }

    // Añade el listener al botón de inicio
    void AddStartButtonListener()
    {
        if (startButton != null)
        {
            startButton.selectEntered.AddListener(OnStartButtonSelected);
        }
    }

    // Evento que se ejecuta al seleccionar el botón de inicio
    private void OnStartButtonSelected(SelectEnterEventArgs args)
    {
        LoadGameScene();
    }

    // Carga la escena del juego
    void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}

*/
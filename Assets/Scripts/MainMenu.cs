/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MainMenu : MonoBehaviour
{
    [Tooltip("El bot�n que inicia el juego.")]
    public GameObject startButtonObject; // Usar GameObject para el bot�n

    private XRSimpleInteractable startButton;

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
            startButton = startButtonObject.GetComponent<XRSimpleInteractable>();
            if (startButton == null)
            {
                Debug.LogError("No se pudo encontrar el componente XRSimpleInteractable en el objeto del bot�n.");
            }
        }
        else
        {
            Debug.LogError("El objeto del bot�n de inicio no est� asignado en el Inspector.");
        }
    }

    // A�ade el listener al bot�n de inicio
    void AddStartButtonListener()
    {
        if (startButton != null)
        {
            startButton.selectEntered.AddListener(OnStartButtonSelected);
        }
    }

    // Evento que se ejecuta al seleccionar el bot�n de inicio
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
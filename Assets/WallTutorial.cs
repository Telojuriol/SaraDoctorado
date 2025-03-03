using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WallTutorial : MonoBehaviour
{
    public enum ELanguage
    {
        English,
        Spanish
    }

    public ELanguage Language;

    public TextMeshProUGUI text;

    void Start()
    {
        switch (Language)
        {
            case ELanguage.English:
                text.text = "Dear painter, There is a message hidden behind the canvas. To discover it, you will have to unpaint the line of the corresponding color with each brush: blue, yellow, pink, green, and white. \r\n\r\nTip: For the colors to disappear and show the secret message, you will have to make a movement with your arm from bottom to top across the canvas and HOLD 10 seconds at your maximum level. ";
                break;
            case ELanguage.Spanish:
                text.text = "Querido pintor / pintora / pintore, Hay un mensaje escondido detrás del lienzo. Para descubrirlo tendrás que despintar con cada brocha la linia del color correspondiente: El azul, el amarillo, el rosa, el verde, y el blanco. \r\n\r\nConsejo: Para que los colores desaparezcan y muestren el mensaje secreto, tendrás que realizar un movimiento con el brazo de abajo a arriba por el lienzo y AGUANTAR  10 segundos en tu máximo nivel.  ";
                break;
        }
    }
}
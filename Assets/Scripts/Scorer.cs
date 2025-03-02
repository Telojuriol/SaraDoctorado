using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public enum EColor{
        Blue,
        Yellow,
        Magenta,
        Green,
        White,
        None
    }

    public EColor brushColor = EColor.White;
    
    // Asigno el mensaje cuando colisionen brochas dentro del Trigger de los Cubos
    public int hits = 0;

    public void TileRemoved(){
        hits++;
    }

}

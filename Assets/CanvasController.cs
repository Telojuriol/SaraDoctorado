using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public delegate void OnTileInteracted(bool entered, EraseColor tile);

    public static event OnTileInteracted onTileInteracted;

    public static float timeToRemoveTiles = 3f;

    public static float maxAlphaValueWhenInteracted = 0.9f;
    public static float minAlphaValueWhenInteracted = 0.1f;

    public static void OnTileInteractedEvent(bool entered, EraseColor tile)
    {
        onTileInteracted?.Invoke(entered, tile);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintColumnController : MonoBehaviour
{
    public List<EraseColor> columnTiles;

    private bool removingTiles = false;

    private bool AllTilesRemoved = false;

    private float currentAlpha = CanvasController.maxAlphaValueWhenInteracted;

    private void Update()
    {
        if (!AllTilesRemoved && AllTilesInteracted())
        {
            if (LastTileBeingBrushed())
            {               
                removingTiles = true;
                currentAlpha -= (CanvasController.maxAlphaValueWhenInteracted - CanvasController.minAlphaValueWhenInteracted) * Time.deltaTime / CanvasController.timeToRemoveTiles;
                SetAllTilesAlpha(currentAlpha);
                if(currentAlpha < CanvasController.minAlphaValueWhenInteracted)
                {
                    currentAlpha = 0;
                    SetAllTilesAlpha(currentAlpha);
                    AllTilesRemoved = true;
                }
            }
            else
            {
                if (removingTiles)
                {
                    currentAlpha = CanvasController.maxAlphaValueWhenInteracted;
                    SetAllTilesAlpha(currentAlpha);
                    removingTiles = false;
                }              
            }
        }
    }

    private bool AllTilesInteracted()
    {
        bool allInteracted = true;
        for (int i = 0; i < columnTiles.Count;i++)
        {
            allInteracted = allInteracted && columnTiles[i].HasBeenInteracted();
        }
        return allInteracted;
    }

    private bool LastTileBeingBrushed()
    {
        return columnTiles[columnTiles.Count - 1].GetIsBrushInside();
    }

    private void SetAllTilesAlpha(float alpha)
    {
        for (int i = 0; i < columnTiles.Count; i++)
        {
            columnTiles[i].SetTileTouchedAlpha(alpha);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CanvasController;

public class paintColumnController : MonoBehaviour
{
    public List<EraseColor> columnTiles;

    private bool removingTiles = false;

    private bool AllTilesRemoved = false;

    private float currentAlpha = CanvasController.maxAlphaValueWhenInteracted;

    public int brushPosition = -1;

    private int previousBrushPosition = -1;

    public Scorer.EColor columnColor;

    private bool interactionStarted = false;

    private void OnEnable()
    {
        CanvasController.onTileInteracted += OnTileInteractedEvent;
    }

    private void OnDisable()
    {
        CanvasController.onTileInteracted -= OnTileInteractedEvent;
    }

    private void Update()
    {
        if(columnColor != Scorer.EColor.Blue) return;

        if (!AllTilesRemoved && interactionStarted)
        {
            if (!BrushOutsideColumns())
            {
                brushPosition = SetBrushPosition();
                if (BrushPositionStable())
                {
                    currentAlpha -= (CanvasController.maxAlphaValueWhenInteracted - CanvasController.minAlphaValueWhenInteracted) * Time.deltaTime / CanvasController.timeToRemoveTiles;
                    SetTilesUnderIndexAlpha(brushPosition,currentAlpha);
                    if (currentAlpha < CanvasController.minAlphaValueWhenInteracted)
                    {
                        currentAlpha = 0;
                        SetTilesUnderIndexAlpha(brushPosition, currentAlpha);
                        AllTilesRemoved = true;
                    }
                }
                else
                {
                    currentAlpha = 1;
                    SetAllTilesAlpha(1);
                }
            }
            else
            {
                SetAllTilesAlpha(1);
                currentAlpha = 1;
                brushPosition = -1;
                previousBrushPosition = -1;
                interactionStarted = false;
            }
        }
        return;
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

    private bool BrushPositionStable()
    {
        bool brushPositionStable = brushPosition == previousBrushPosition;
        previousBrushPosition = brushPosition;
        return brushPositionStable;
    }

    private void OnTileInteractedEvent(bool entered, EraseColor tile)
    {
        if(tile.tileColor == columnColor && entered)
        {
            if (brushPosition == -1 && columnTiles.IndexOf(tile) == 0)
            {
                brushPosition = 0;
                previousBrushPosition = 0;
                interactionStarted = true;
            }
        }
    }

    private int SetBrushPosition()
    {
        for (int i = columnTiles.Count-1; i >= 0; i--)
        {
            if (columnTiles[i].GetIsBrushInside())
            {
                return i;
            }
        }
        return -1;
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

    private bool BrushOutsideColumns()
    {
        bool brushOutside = true;
        for (int i = 0; i < columnTiles.Count; i++)
        {
            brushOutside = brushOutside && !columnTiles[i].GetIsBrushInside();
        }
        return brushOutside;
    }

    private void SetAllTilesAlpha(float alpha)
    {
        for (int i = 0; i < columnTiles.Count; i++)
        {
            columnTiles[i].SetTileTouchedAlpha(alpha);
        }
    }

    private void SetTilesUnderIndexAlpha(int index, float alpha)
    {
        for (int i = 0; i <= index; i++)
        {
            columnTiles[i].SetTileTouchedAlpha(alpha);
        }
    }
}

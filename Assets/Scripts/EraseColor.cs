using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EraseColor : MonoBehaviour
{
    // Asignar el color de todos los cubos también en el inspector
    public Scorer.EColor tileColor = Scorer.EColor.White;

    private Renderer _renderer;
    private MaterialPropertyBlock mpb;

   
    private bool hasBeenInteracted = false;
    private bool isLastTile = false;
    [SerializeField]private bool isBrushInside = false;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();
    }

    public void SetTileTouchedAlpha(float alpha)
    {
        // Obtener los valores actuales del material
        _renderer.GetPropertyBlock(mpb);

        // Modificar solo la propiedad del color (incluyendo alpha)
        Color color = _renderer.sharedMaterial.color;
        color.a = alpha; // Cambia el alpha a 50%
        mpb.SetColor("_Color", color);

        // Aplicar los cambios al material del objeto
        _renderer.SetPropertyBlock(mpb);
    }

    public void IsLastTile(bool status)
    {
        isLastTile = status;
    }

    public bool HasBeenInteracted()
    {
        return hasBeenInteracted;
    }

    public bool GetIsBrushInside()
    {
        return isBrushInside;
    }

    void OnTriggerEnter(Collider other) 
    {
        Scorer brushScorer = other.GetComponent<Scorer>();
        // Verificar que el cubo con el que colisiona la brocha tiene el mismo color
        if (brushScorer != null && brushScorer.brushColor == tileColor)
        {
            isBrushInside = true;
            if (!hasBeenInteracted)
            {
                hasBeenInteracted = true;
                SetTileTouchedAlpha(CanvasController.maxAlphaValueWhenInteracted);
            }
            //gameObject.SetActive(false);
            //brushScorer.TileRemoved();
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        Scorer brushScorer = other.GetComponent<Scorer>();
        // Verificar que el cubo con el que colisiona la brocha tiene el mismo color
        if (brushScorer != null && brushScorer.brushColor == tileColor)
        {
            isBrushInside = false;
            //gameObject.SetActive(false);
            //brushScorer.TileRemoved();
        }
    }
}
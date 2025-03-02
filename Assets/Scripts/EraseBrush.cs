using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EraseBrush : MonoBehaviour
{
    // Asigno el color de todas brochas también en el inspector
    public Color brushblue = Color.blue;
    public Color brushyellow = Color.yellow;
    public Color brushpink = Color.magenta;
    public Color brushgreen = Color.green;
    public Color brushwhite = Color.white;

    // Asigno el color de los cubos
    public GameObject[] cubeblue;
    public GameObject[] cubeyellow;
    public GameObject[] cubepink;
    public GameObject[] cubegreen;
    public GameObject[] cubewhite;
    

    // Asigno el comportamiento de la brocha cuando toca el cubo (desaparece la malla)
    void OnTriggerEnter(Collider other)
    {
        // Asigno la brocha AZUL como colisionador
        if (other.gameObject.GetComponent<Renderer>().material.color == brushblue)
        {
            // Todos los cubos tocados se desactivan su Mesh Renderer si son azules
            foreach (GameObject brushblue in cubeblue)
            {
                if (brushblue.GetComponent<Renderer>().material.color == Color.blue)
                {
                    brushblue.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }

        // Asigno la brocha AMARILLA como colisionador
        if (other.gameObject.GetComponent<Renderer>().material.color == brushyellow)
        {
            // Todos los cubos tocados se desactivan su Mesh Renderer si son amarillos
            foreach (GameObject brushyellow in cubeyellow)
            {
                if (brushyellow.GetComponent<Renderer>().material.color == Color.yellow)
                {
                    brushyellow.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }

        // Asigno la brocha ROSA como colisionador
        if (other.gameObject.GetComponent<Renderer>().material.color == brushpink)
        {
            // Todos los cubos tocados se desactivan su Mesh Renderer si son rosas
            foreach (GameObject brushpink in cubepink)
            {
                if (brushpink.GetComponent<Renderer>().material.color == Color.magenta)
                {
                    brushpink.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }

        // Asigno la brocha VERDE como colisionador
        if (other.gameObject.GetComponent<Renderer>().material.color == brushgreen)
        {
            // Todos los cubos tocados se desactivan su Mesh Renderer si son verdes
            foreach (GameObject brushgreen in cubegreen)
            {
                if (brushgreen.GetComponent<Renderer>().material.color == Color.green)
                {
                    brushgreen.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        
        // Asigno la brocha BLANCA como colisionador
        if (other.gameObject.GetComponent<Renderer>().material.color == brushwhite)
        {
            // Todos los cubos tocados se desactivan su Mesh Renderer si son blancos
            foreach (GameObject brushwhite in cubewhite)
            {
                if (brushwhite.GetComponent<Renderer>().material.color == Color.white)
                {
                    brushwhite.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    } 
    }
}


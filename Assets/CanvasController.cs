using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public delegate void OnTileInteracted(bool entered, EraseColor tile);

    public static event OnTileInteracted onTileInteracted;

    public static float timeToRemoveTiles = 3f;

    public static float maxAlphaValueWhenInteracted = 0.9f;
    public static float minAlphaValueWhenInteracted = 0.1f;

    public int blueScore = 0;
    public int yellowScore = 0;
    public int magentaScore = 0;    
    public int greenScore = 0;
    public int whiteScore = 0;

    public GameObject EndCanvas;
    public TextMeshProUGUI blueScoreText;
    public TextMeshProUGUI greenScoreText;
    public TextMeshProUGUI whiteScoreText;
    public TextMeshProUGUI magentaScoreText;
    public TextMeshProUGUI yellowScoreText;

    public static CanvasController instance;
    
    private bool gamended = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }          
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(!gamended &&blueScore > 0 && yellowScore > 0 && magentaScore > 0 && greenScore > 0 && whiteScore > 0)
        {
            gamended = true;
            SetGameEndingScores();
            Debug.Log("Game Ended");
        }
    }

    private void SetGameEndingScores()
    {
        EndCanvas.SetActive(true);
        blueScoreText.text = "Blue Score: " + blueScore.ToString() + "/10";
        yellowScoreText.text = "Yellow Score: " + yellowScore.ToString() + "/10";
        magentaScoreText.text = "Magenta Score: " + magentaScore.ToString() + "/10";
        greenScoreText.text = "Green Score: " + greenScore.ToString() + "/10";
        whiteScoreText.text = "Blue Score: " + whiteScore.ToString() + "/10";
    }

    public static void OnTileInteractedEvent(bool entered, EraseColor tile)
    {
        onTileInteracted?.Invoke(entered, tile);
    }
}

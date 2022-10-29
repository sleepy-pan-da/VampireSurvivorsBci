using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChangerBasedOnConcentration : MonoBehaviour
{
    public LSLInput lslInput;
    public float concentrationThreshold;
    public ScoreController scoreController;

    private Renderer gameObjectRenderer;
    private Color colourChange = new Color(0.001f, 0.001f, 0.001f);

    // Start is called before the first frame update
    void Start()
    {
        gameObjectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lslInput.streamInlet != null && lslInput.latestExtractedData != null)
        {
            UpdateColourBasedOn(lslInput.latestExtractedData.ConcentrationRatio);
        }
    }

    private void UpdateColourBasedOn(float concentrationRatio)
    {
        if (concentrationRatio == 0) return;

        Color currentColour = gameObjectRenderer.material.color;

        if (concentrationRatio > concentrationThreshold)
        {
            //Debug.Log("Concentrating!");
            currentColour += colourChange;
        }
        //else
        //{
        //    //Debug.Log("Relaxing!");
        //    currentColour -= colourChange;
        //}

        currentColour = new Color(Mathf.Clamp(currentColour.r, 0, 1), Mathf.Clamp(currentColour.g, 0, 1), Mathf.Clamp(currentColour.b, 0, 1));
        if (currentColour == Color.white)
        {
            scoreController.AddScore();
            currentColour = Color.black;
        }

        //float colourMultiplier = Mathf.Min(concentrationRatio, 1); // from 0-1
        //Color newColour = new Color(colourMultiplier, colourMultiplier, colourMultiplier);
        gameObjectRenderer.material.color = currentColour;
        //Debug.Log(gameObjectRenderer.material.color);
    }
}

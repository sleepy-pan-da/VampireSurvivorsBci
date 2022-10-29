using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;


public class TextController : MonoBehaviour
{
    public LSLInput lslInput;

    private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lslInput.streamInlet != null && lslInput.latestExtractedData != null)
        {
            ExtractedDataFromRawEeg latestExtractedData = lslInput.latestExtractedData;
            string newText = FormStringFromRawEegExtractedData(latestExtractedData);
            UpdateText(newText);
        }
        else UpdateText("No data from lsl");
    }

    private string FormStringFromRawEegExtractedData(ExtractedDataFromRawEeg extractedData)
    {
        return string.Format($"Delta: {extractedData.Delta}" +
            $"\nTheta: {extractedData.Theta}" +
            $"\nAlpha: {extractedData.Alpha}" +
            $"\nBeta: {extractedData.Beta}" +
            $"\nConcentration ratio: {extractedData.ConcentrationRatio}");
    }

    private void UpdateText(string newText)
    {
        textMeshPro.text = newText;
    }
}

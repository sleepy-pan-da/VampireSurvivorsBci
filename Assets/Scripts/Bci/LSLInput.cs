using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LSL;

public class LSLInput : MonoBehaviour
{
    public bool IsPullingDataFromStreamInlet = false;
    // We need to find the stream somehow. You must provide a StreamName in editor or before this object is Started.
    public string StreamName;

    [HideInInspector]
    public ExtractedDataFromRawEeg latestExtractedData = new ExtractedDataFromRawEeg();
    public static event Action<ExtractedDataFromRawEeg> OnPullEEGData;

    //public float[] latestFrequencyBandsData = new float[5]; // Delta, Theta, Alpha, Beta, Concentration ratio (Beta/Theta)

    public StreamInlet streamInlet;
    private StreamInfo[] streamInfos;

    private float[] sample;
    private int channelCount = 0;


    void Update()
    {
        if (IsPullingDataFromStreamInlet)
        {
            if (streamInlet == null)
            {

                //streamInfos = LSL.LSL.resolve_streams();

                streamInfos = LSL.LSL.resolve_stream("name", StreamName, 1, 10.0);
                if (streamInfos.Length > 0)
                {
                    streamInlet = new StreamInlet(streamInfos[0]);
                    //Debug.Log(streamInlet.info().name());
                    //Debug.Log(streamInlet.info().type());
                    //Debug.Log(streamInlet.info().hostname());
                    channelCount = streamInlet.info().channel_count();
                    //Debug.Log(channelCount.ToString());
                    //Debug.Log(streamInlet.info().nominal_srate().ToString());
                    streamInlet.open_stream();
                }
            }

            if (streamInlet != null)
            {
                sample = new float[channelCount];
                double lastTimeStamp = streamInlet.pull_sample(sample, 0.0f);
                if (lastTimeStamp != 0.0)
                {
                    ProcessData(sample, lastTimeStamp);
                    OnPullEEGData?.Invoke(latestExtractedData);
                    while ((lastTimeStamp = streamInlet.pull_sample(sample, 0.0f)) != 0)
                    {
                        ProcessData(sample, lastTimeStamp);
                        OnPullEEGData?.Invoke(latestExtractedData);
                    }
                }
            }
        }
        
        transform.Rotate(10 * Time.deltaTime, 10 * Time.deltaTime, 10 * Time.deltaTime);
    }
    void ProcessData(float[] frequencyBands, double timeStamp)
    {
        //Debug.Log("Delta: " + frequencyBands[0].ToString());
        //Debug.Log("Theta: " + frequencyBands[1].ToString());
        //Debug.Log("Alpha: " + frequencyBands[2].ToString());
        //Debug.Log("Beta: " + frequencyBands[3].ToString());

        //latestFrequencyBandsData = frequencyBands;

        latestExtractedData.Delta = frequencyBands[0];
        latestExtractedData.Theta= frequencyBands[1];
        latestExtractedData.Alpha= frequencyBands[2];
        latestExtractedData.Beta = frequencyBands[3];

        if (latestExtractedData.Theta <= 0) latestExtractedData.Theta = 0.1f;
        // latestExtractedData.ConcentrationRatio = (latestExtractedData.Beta * 1.2f) / (latestExtractedData.Theta);
        latestExtractedData.ConcentrationRatio = (latestExtractedData.Beta * 1f) / (latestExtractedData.Theta);

    }
}
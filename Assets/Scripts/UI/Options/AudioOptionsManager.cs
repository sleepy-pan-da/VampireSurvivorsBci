using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioOptionsManager : MonoBehaviour
{
    public float musicVol {get; private set;}
    public float sfxVol {get; private set;}
    public static Action<float> OnChangedMusicVol;
    public static Action<float> OnChangedSfxVol;

    public void OnMusicSliderValueChanged(float value)
    {
        musicVol = value;
        OnChangedMusicVol?.Invoke(musicVol);
    }

    public void OnSfxSliderValueChanged(float value)
    {
        sfxVol = value;
        OnChangedSfxVol?.Invoke(sfxVol);
    }
}

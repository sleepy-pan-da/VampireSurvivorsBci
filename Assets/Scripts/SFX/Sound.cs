using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public enum AudioTypes {sfx, music};
    public AudioTypes audioType;
    public string name;
    public AudioClip clip;
    
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool isLoop;
    public bool cannotBeInterrupted;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;

}

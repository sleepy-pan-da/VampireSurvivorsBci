using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Aura : MonoBehaviour
{
    private Light2D aura; 
    [SerializeField]
    private Color unfocusedColor;
    [SerializeField]
    private Color focusedColor;

    private void Awake()
    {
        Debug.Log("aura is awake");
        aura = GetComponent<Light2D>();
        gameObject.SetActive(false);
    }

    public void UpdateAura(float concentrationRatio)
    {
        Debug.Log(aura);
        aura.intensity = 2f*concentrationRatio + 0.7f; // y = 2.3x + 0.7
        if (concentrationRatio < 1) aura.color = unfocusedColor;
        else aura.color = focusedColor;
    }
}

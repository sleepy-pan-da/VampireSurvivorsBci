using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ExpBar : MonoBehaviour
{
    private Slider expBarSlider;
    private TextMeshProUGUI levelText;

    private void Awake()
    {
        expBarSlider = GetComponent<Slider>();
        levelText = transform.Find("Level").GetComponent<TextMeshProUGUI>();
    }

    public void Initialise(PlayerStats curStats)
    {
        expBarSlider.maxValue = curStats.ExpNeededToLevel;
        UpdateExp(0);
        UpdateLvlText(curStats.Level);
    }

    public void UpdateExp(int newValue)
    {
        expBarSlider.value = newValue;
    }

    private void UpdateLvlText(int newLevel)
    {
        levelText.text = $"LVL {newLevel.ToString()}";
    }
}

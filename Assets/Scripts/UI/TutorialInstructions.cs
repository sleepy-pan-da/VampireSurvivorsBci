using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TutorialInstructions : MonoBehaviour
{
    private RectTransform rectTransform;
    private TextMeshProUGUI textMeshPro;
    private Color origColor;
    private Color fadeoutColor;
    private bool toReset = false;

    private void Start()
    {
        rectTransform = transform.Find("Text").GetComponent<RectTransform>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        LSLInput.OnHookedUpBci += UpdateBciTutorial;
        UpgradeUI.OnSelectedFirstSkill += Show;
        SetUpColors();
        gameObject.SetActive(false);
        toReset = true;
    }

    private void OnDisable()
    {
        if (toReset)
        {
            LSLInput.OnHookedUpBci -= UpdateBciTutorial;
            UpgradeUI.OnSelectedFirstSkill -= Show;
        } 
    }

    private void UpdateBciTutorial()
    {
        textMeshPro.text = "WASD / Arrow Keys -> Move\nYou can move faster with enough willpower";
    }

    private void SetUpColors()
    {
        origColor = textMeshPro.color;
        fadeoutColor = origColor;
        fadeoutColor.a = 0;
    }

    private void Show()
    {
        gameObject.SetActive(true); 
        var seq = LeanTween.sequence();
        seq.append(LeanTween.scale(rectTransform, new Vector2(1.3f, 1.3f), 1f).setEase(LeanTweenType.easeOutElastic));
        seq.append(5f);
        seq.append(LeanTween.value(gameObject, SetTextAlpha, origColor, fadeoutColor, 2f));
        seq.append(() => {
            gameObject.SetActive(false);
        });
    }

    private void SetTextAlpha(Color val)
    {
        textMeshPro.color = val;
    }
}

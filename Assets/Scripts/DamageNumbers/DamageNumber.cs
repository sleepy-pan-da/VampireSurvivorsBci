using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    private RectTransform rectTransform;
    private TextMeshProUGUI textMeshPro;
    private Color origColor;
    private Color fadeoutColor;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        SetUpColors();
    }

    private void SetUpColors()
    {
        origColor = textMeshPro.color;
        fadeoutColor = origColor;
        fadeoutColor.a = 0;
    }

    public void PopUp(int damage)
    {
        SetDamageNumber(damage);
        rectTransform.localScale = new Vector2(0.1f, 0.1f);
        var seq = LeanTween.sequence();
        seq.append(LeanTween.scale(rectTransform, new Vector2(1.3f, 1.3f), 0.5f).setEase(LeanTweenType.easeOutElastic));
        seq.append(LeanTween.value(gameObject, SetTextAlpha, origColor, fadeoutColor, 0.3f));
        seq.append(() => {
            Destroy(gameObject);
        });
    }

    private void SetDamageNumber(int damage)
    {
        textMeshPro.text = damage.ToString();
    }

    private void SetTextAlpha(Color val)
    {
        textMeshPro.color = val;
    }
}

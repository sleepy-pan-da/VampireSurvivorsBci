using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SkillPanel : MonoBehaviour
{
    public static event Action<string> OnPressedSkillPanel;
    private Image icon;
    private TextMeshProUGUI skillName;
    private TextMeshProUGUI level;
    private TextMeshProUGUI desc;


    private void Awake()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        icon = transform.Find("Portrait/Sprite").GetComponent<Image>();
        skillName = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        level = transform.Find("Level").GetComponent<TextMeshProUGUI>();
        desc = transform.Find("Description").GetComponent<TextMeshProUGUI>();
    }

    public void PopulateContent(Skill skill, int level)
    {
        UpdateIcon(skill.Icon);
        UpdateSkillName(skill.name);
        UpdateLevel(level);
        UpdateDesc(skill.Description[level-1]);
    } 

    private void UpdateIcon(Sprite newSprite)
    {
        icon.sprite = newSprite;
    }

    private void UpdateSkillName(string newName)
    {
        skillName.text = newName;
    }

    private void UpdateLevel(int newLevel)
    {
        if (newLevel == 1)
        {
            level.text = "NEW";
            return;
        }  
        level.text = $"Level: {newLevel}";
    }

    private void UpdateDesc(string description)
    {
        desc.text = description;   
    }

    private void TaskOnClick()
    {
        // Debug.Log($"Clicked on: {skillName.text}");
        OnPressedSkillPanel?.Invoke(skillName.text);
    }
}

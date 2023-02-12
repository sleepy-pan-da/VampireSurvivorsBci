using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeUI : MonoBehaviour
{
    // Contains code for selecting skills upon leveling up via UI
    public static event Action<string> OnSelectedSkill;
    private bool testingSkills = false;
    private CanvasGroup canvasGroup;
    private SkillGenerator skillGenerator;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        skillGenerator = transform.Find("Background/Body").GetComponent<SkillGenerator>();
        SkillPanel.OnPressedSkillPanel += SelectSkill;
        PlayerStats.OnLeveledUp += Open;
        if (testingSkills)
        {
            // for testing purposes
            // StartCoroutine(MockSelectSkillEnumerator("Vitality"));
            // StartCoroutine(MockSelectSkillEnumerator("Determination"));

            for (int i = 0; i < 5; i++)
            {
                
            }
            // StartCoroutine(MockSelectSkillEnumerator("Lightfooted"));
            // StartCoroutine(MockSelectSkillEnumerator("Resilience"));
            // StartCoroutine(MockSelectSkillEnumerator("Magnet"));
            // StartCoroutine(MockSelectSkillEnumerator("Proficiency"));
            // StartCoroutine(MockSelectSkillEnumerator("Intimidation"));
            


            // StartCoroutine(MockSelectSkillEnumerator("Knife"));
            

            // StartCoroutine(MockSelectSkillEnumerator("Firebolt"));
            

            // StartCoroutine(MockSelectSkillEnumerator("Sword"));
            

            StartCoroutine(MockSelectSkillEnumerator("Hammer"));
            

            // StartCoroutine(MockSelectSkillEnumerator("Spear"));
            

            // StartCoroutine(MockSelectSkillEnumerator("Cleaver"));
            
            // StartCoroutine(MockSelectSkillEnumerator("Bone"));
            // StartCoroutine(MockSelectSkillEnumerator("Bone",0.1f));
            // StartCoroutine(MockSelectSkillEnumerator("Bone",0.2f));
            // StartCoroutine(MockSelectSkillEnumerator("Bone",0.3f));
            // StartCoroutine(MockSelectSkillEnumerator("Bone",0.4f));

            ToggleUI(false);
            return;
        }
        
        Open();
    }

    private void Open()
    {
        // Pick 3 skills to choose from
        Time.timeScale = 0;
        skillGenerator.ChooseAvailableSkills();
        ToggleUI(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Open();
    }

    // for testing purposes
    IEnumerator MockSelectSkillEnumerator(string skillName)
    {
        yield return new WaitForFixedUpdate();
        MockSelectSkill(skillName);
    }
    IEnumerator MockSelectSkillEnumerator(string skillName, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        MockSelectSkill(skillName);
    }

    private void MockSelectSkill(string skillName)
    {
        OnSelectedSkill?.Invoke(skillName);
    }

    private void SelectSkill(string skillName)
    {
        OnSelectedSkill?.Invoke(skillName);
        ToggleUI(false);
        Time.timeScale = 1;
    }

    private void ToggleUI(bool isVisible)
    {
        if (isVisible)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
        }
        else
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
        }
    }
}

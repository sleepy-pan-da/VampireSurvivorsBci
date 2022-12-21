using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeUI : MonoBehaviour
{
    // Contains code for selecting skills upon leveling up via UI
    public static event Action<string> OnSelectedSkill;

    private void Start()
    {
        // for testing purposes
        // StartCoroutine(MockSelectSkill("Vitality"));
        // StartCoroutine(MockSelectSkill("Determination"));

        for (int i = 0; i < 5; i++)
        {
            
        }
        // StartCoroutine(MockSelectSkill("Lightfooted"));
        // StartCoroutine(MockSelectSkill("Resilience"));
        // StartCoroutine(MockSelectSkill("Magnet"));
        // StartCoroutine(MockSelectSkill("Proficiency"));
        // StartCoroutine(MockSelectSkill("Intimidation"));
        


        // StartCoroutine(MockSelectSkill("Knife"));
        

        // StartCoroutine(MockSelectSkill("Firebolt"));
        

        // StartCoroutine(MockSelectSkill("Sword"));
        

        // StartCoroutine(MockSelectSkill("Hammer"));
        

        // StartCoroutine(MockSelectSkill("Spear"));
        

        // StartCoroutine(MockSelectSkill("Cleaver"));
        
        StartCoroutine(MockSelectSkill("Bone"));
        // StartCoroutine(MockSelectSkill("Bone",0.1f));
        // StartCoroutine(MockSelectSkill("Bone",0.2f));
        // StartCoroutine(MockSelectSkill("Bone",0.3f));
        // StartCoroutine(MockSelectSkill("Bone",0.4f));
    }

    // for testing purposes
    IEnumerator MockSelectSkill(string skillName)
    {
        yield return new WaitForFixedUpdate();
        SelectSkill(skillName);
    }
    IEnumerator MockSelectSkill(string skillName, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        SelectSkill(skillName);
    }

    private void SelectSkill(string skillName)
    {
        OnSelectedSkill?.Invoke(skillName);
    }
}

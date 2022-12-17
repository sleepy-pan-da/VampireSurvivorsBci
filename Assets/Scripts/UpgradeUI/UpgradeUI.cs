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
        // StartCoroutine(MockSelectSkill("Lightfooted"));
        // StartCoroutine(MockSelectSkill("Resilience"));
        // StartCoroutine(MockSelectSkill("Magnet"));
        // StartCoroutine(MockSelectSkill("Intimidation"));
        // StartCoroutine(MockSelectSkill("Intimidation",0.2f));
        // StartCoroutine(MockSelectSkill("Intimidation",0.4f));
        StartCoroutine(MockSelectSkill("Knife"));
        StartCoroutine(MockSelectSkill("Firebolt"));
        StartCoroutine(MockSelectSkill("Sword"));

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

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
        IEnumerator coroutine = MockSelectSkill("Vitality");
        StartCoroutine(coroutine);
        coroutine = MockSelectSkill("Determination");
        StartCoroutine(coroutine);
        coroutine = MockSelectSkill("Lightfooted");
        StartCoroutine(coroutine);
    }

    // for testing purposes
    IEnumerator MockSelectSkill(string skillName)
    {
        yield return new WaitForEndOfFrame();
        SelectSkill(skillName);
    }

    private void SelectSkill(string skillName)
    {
        OnSelectedSkill?.Invoke(skillName);
    }
}

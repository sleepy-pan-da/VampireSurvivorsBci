using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Stores currently held skills and their corresponding levels
public class Loadout : MonoBehaviour
{
    public static event Action<string, int> OnUpdatedSkillLevel;

    private Dictionary<string, int> skillLevels = new Dictionary<string, int>();

    private void Start()
    {
        UpgradeUI.OnSelectedSkill += UpdateSkillLevels;
    }
    
    private void UpdateSkillLevels(string updatedSkill)
    {
        if (skillLevels.ContainsKey(updatedSkill))
        {
            skillLevels[updatedSkill]++;
        }
        else
        {
            skillLevels.Add(updatedSkill, 1);
        }
        OnUpdatedSkillLevel?.Invoke(updatedSkill, skillLevels[updatedSkill]);
    }
}

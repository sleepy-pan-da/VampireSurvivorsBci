using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Stores currently held skills and their corresponding levels
public class Loadout : MonoBehaviour
{
    public static event Action<string, int> OnUpdatedSkillLevel;
    [SerializeField]
    private SkillDB skillDB;
    private Dictionary<string, int> skillLevels = new Dictionary<string, int>();
    private int maxLoadoutSize = 6;

    private void Start()
    {
        UpgradeUI.OnSelectedSkill += UpdateSkillLevels;
    }
    
    private void OnDisable()
    {
        UpgradeUI.OnSelectedSkill -= UpdateSkillLevels;
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

    public int GetCountOfDict()
    {
        return skillLevels.Count;
    }

    public bool HaveSpace()
    {
        return GetCountOfDict() < maxLoadoutSize;
    }

    public int GetLevelOfSkill(string skillName)
    {
        if (!skillLevels.ContainsKey(skillName)) return 0;
        return skillLevels[skillName];
    }

    private bool SkillReachedMaxLevel(string skill)
    {
        return skillLevels[skill] == skillDB.ReturnSkill(skill).MaxLevel;
    }

    private int GetNumOfUpgradableSkills()
    {
        int res = 0;
        foreach(string skill in skillLevels.Keys)
        {
            if (SkillReachedMaxLevel(skill)) continue;
            res += 1;
        }
        return res;
    }

    public List<String> ReturnRandomHeldSkill(int numberOfSkills)
    {
        List<String> res = new List<String>();
        numberOfSkills = Mathf.Min(GetNumOfUpgradableSkills(), numberOfSkills);
        List<string> heldSkills = new List<string>(skillLevels.Keys);
        
        while (res.Count < numberOfSkills)
        {
            int i = UnityEngine.Random.Range(0, heldSkills.Count);
            if (res.Contains(heldSkills[i]) || SkillReachedMaxLevel(heldSkills[i])) continue;
            res.Add(heldSkills[i]);
        }
        return res;
    }

    public List<String> ReturnHeldSkills()
    {
        List<String> res = new List<String>(); 
        foreach(string skill in skillLevels.Keys)
        {
            res.Add(skill);
        }
        return res;
    }
}

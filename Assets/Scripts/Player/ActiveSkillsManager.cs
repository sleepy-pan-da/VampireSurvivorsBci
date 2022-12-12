using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillsManager : MonoBehaviour
{
    public Dictionary<string, ActiveSpecifications> skillDict = new Dictionary<string, ActiveSpecifications>();
    public void UpdateActiveSkill(string updatedSkill, int skillLevel)
    {
        if (skillDict.ContainsKey(updatedSkill))
        {
            skillDict[updatedSkill].Compute(skillLevel);
        }
    }
}

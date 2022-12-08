using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDB : MonoBehaviour
{
    [SerializeField]
    private Skill[] skills;
    private Dictionary<string, Skill> skillDict = new Dictionary<string, Skill>();

    private void Start()
    {
        foreach (Skill skill in skills) skillDict.Add(skill.Name, skill);
        Loadout.OnUpdatedSkillLevel += SetUpSkill;
    }

    private void SetUpSkill(string updatedSkill, int skillLevel)
    {
        if (!skillDict.ContainsKey(updatedSkill))
        {
            Debug.Log("Skill not in dict");
            return;
        } 

        if (skillDict[updatedSkill].GetType() == typeof(Passive))
        {
            Passive skill = (Passive)skillDict[updatedSkill];
            skill.Specifications.Compute();
            // Compute stats according to PassiveSpecifications
        }
        else
        {
            // Check it's level and perform accordingly
        }
    }
}

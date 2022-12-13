using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets up newly chosen skill based on it's name, skill type and level
public class SkillDB : MonoBehaviour
{
    [SerializeField]
    private Transform activeSkillsHeld;
    [SerializeField]
    private Transform skillInstances;
    private ActiveSkillsManager activeSkillsManager;
    [SerializeField]
    private Skill[] skills;
    private Dictionary<string, Skill> skillDict = new Dictionary<string, Skill>();

    private void Start()
    {
        foreach (Skill skill in skills) skillDict.Add(skill.Name, skill);
        Loadout.OnUpdatedSkillLevel += SetUpSkill;
        activeSkillsManager = activeSkillsHeld.GetComponent<ActiveSkillsManager>();
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
            skill.Specifications.Compute(skillLevel);
        }
        else
        {
            // Check it's level and perform accordingly
            if (skillLevel == 1)
            {
                // instantiate active skill prefab and attach to player gameobject
                Active skill = (Active)skillDict[updatedSkill];
                ActiveSpecifications instance = Instantiate(skill.SkillPrefab, activeSkillsHeld.position, activeSkillsHeld.rotation, activeSkillsHeld);
                activeSkillsManager.skillDict.Add(updatedSkill, instance);
                instance.skillInstances = skillInstances;
            }
            else
            {
                // notify the active skill attached to player of updated level
                // attached active skill will perform according to updated level (higher damage, lower cooldown etc)
                activeSkillsManager.UpdateActiveSkill(updatedSkill, skillLevel);
            }
        }
    }
}

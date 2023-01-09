using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generates skills to appear in upgrade UI based on current loadout and skillDB
public class SkillGenerator : MonoBehaviour
{
    [SerializeField]
    private Loadout loadout;
    [SerializeField]
    private SkillDB skillDB;
    [SerializeField]
    private SkillPanel skillPanel;

    public void ChooseAvailableSkills()
    {
        List<Skill> res;
        Clear();

        if (loadout.GetCountOfDict() == 0)
        {
            // choose only active skills
            res = skillDB.ReturnRandomActiveSkill(3);
        }
        else
        {
            if (loadout.HaveSpace())
            {
                // choose a mix of current held skills and new skills
                // 3 outcomes
                // 1. only new skills
                // 2. 2 new skills, 1 held skill
                // 3. 1 new skill, 2 held skill

                int i = Random.Range(0,3);
                switch(i)
                {
                    case 0:
                        Debug.Log("1. Only new skills");
                        res = skillDB.ReturnNewRandomSkill(3, loadout.ReturnHeldSkills());
                        break;
                    case 1:
                        Debug.Log("2. 2 new skills, 1 held skill");
                        res = skillDB.ReturnNewRandomSkill(2, loadout.ReturnHeldSkills());
                        ChooseHeldSkill(1, res);
                        break;
                    case 2:
                        Debug.Log("3. 1 new skill, 2 held skill");
                        res = skillDB.ReturnNewRandomSkill(1, loadout.ReturnHeldSkills());
                        ChooseHeldSkill(2, res);
                        break;
                    default:
                        Debug.Log("error in skill generator");
                        return;
                }
            }
            else
            {
                // choose only current held skills
                res = new List<Skill>();
                ChooseHeldSkill(3, res);
            }
        }

        foreach(Skill skill in res)
        {
            SkillPanel instance = Instantiate(skillPanel, transform.position, transform.rotation, transform);
            int currLevel = loadout.GetLevelOfSkill(skill.Name);

            instance.PopulateContent(skill, currLevel+1);
        }
    }

    private void ChooseHeldSkill(int numberOfSkills, List<Skill> chosenSkills)
    {
        List<string> temp = loadout.ReturnRandomHeldSkill(numberOfSkills);
        foreach(string skillName in temp)
        {
            Skill skill = skillDB.ReturnSkill(skillName);
            if (!skill) continue;
            chosenSkills.Add(skill);
        }
    }

    private void Clear()
    {
        int childs = transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    public void Back()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}

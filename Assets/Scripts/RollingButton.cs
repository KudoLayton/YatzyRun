using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollingButton : MonoBehaviour
{
    Text text;
    Button button;
    void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
    }

    public void updateChance(bool interactable, int chance)
    {
        if (chance <= 0) {
            button.interactable = false;
            text.text = "0회 남음";
        }
        else
        {
            button.interactable = interactable & true;
            text.text = $"{chance}회 남음";
        }
    }
}

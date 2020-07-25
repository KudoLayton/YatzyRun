using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDiceProp : MonoBehaviour
{
    private Text thisText;
    void Start()
    {
        thisText = GetComponent<Text>();
    }

    public void UpdateText(int i) => thisText.text = $"{i + 1}";
}

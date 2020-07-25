using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceManager : MonoBehaviour
{
    private DiceGroup diceGroup;
    public UnityEvent<int>[] diceImageUpdateEvents = new UnityEvent<int>[5];
    void Start() {
        diceGroup = new DiceGroup();
        for (int i = 0; i < 5; ++i)
            diceImageUpdateEvents[i].Invoke(diceGroup.diceArray[i].value);
    }

    public void selectDice(int idx) => diceGroup.SelectRolledDice(idx);
    public void rollSelectedDice() 
    {
        diceGroup.RollSelectedDice();
        for (int i = 0; i < 5; ++i)
            diceImageUpdateEvents[i].Invoke(diceGroup.diceArray[i].value);
    }

    public int getDiceValue(int idx) => diceGroup.diceArray[idx].value;
    public bool isDiceSelected(int idx) => diceGroup.rollingArray[idx];
}

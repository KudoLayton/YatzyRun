using System.Collections;
using System.Collections.Generic;

public class DiceGroup
{
    public Dice[] diceArray 
    {
        get;
        private set;
    } = new Dice[5];

    public bool[] rollingArray 
    {
        get;
        private set;
    } = new bool[5];

    public DiceGroup()
    {
        for (int i = 0; i < 5; ++i)
        {
            diceArray[i] = new Dice();
            rollingArray[i] = false;
        }
    }

    public void SelectRolledDice(int idx) => rollingArray[idx] = !rollingArray[idx];

    public void RollSelectedDice()
    {
        for(int i = 0; i < 5; ++i)
        {
            if (rollingArray[i])
                diceArray[i].RollDice();
        }
    }
}

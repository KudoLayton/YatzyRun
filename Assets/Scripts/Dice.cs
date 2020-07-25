using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice{
    public Dice() => RollDice();

    public int value 
    {
        get;
        private set;
    }

    public int RollDice()
    {
        value = Random.Range(0, 6);
        return value;
    }
}

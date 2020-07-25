﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class DiceManager : MonoBehaviour
{
    private DiceGroup diceGroup;
    public UnityEvent<int>[] diceImageUpdateEvents = new UnityEvent<int>[5];
    public UnityEvent<int, bool>[] scoreBoardUpdateEvents = new UnityEvent<int, bool>[13];

    public int[] scores 
    {
        get;
        private set;
    } = new int[13];

    public bool[] scoreEnable
    {
        get;
        private set;
    } = new bool[13];

    void Start() {
        diceGroup = new DiceGroup();
        for (int i = 0; i < 5; ++i)
            diceImageUpdateEvents[i].Invoke(diceGroup.diceArray[i].value);
        int[] diceResult = getDiceValueArray();
        for (int i = 0; i < 13; ++i)
        {
            scoreEnable[i] = true;
            scoreBoardUpdateEvents[i].Invoke(ScoreCalculator.calculatorArray[i](diceResult), true);
        }
    }

    public void selectDice(int idx) => diceGroup.SelectRolledDice(idx);
    public void rollSelectedDice() 
    {
        diceGroup.RollSelectedDice();
        for (int i = 0; i < 5; ++i)
        {
            diceImageUpdateEvents[i].Invoke(diceGroup.diceArray[i].value);
        }

        int[] diceResult = getDiceValueArray();
        for (int i = 0; i < 13; ++i)
        {
            if (scoreEnable[i])
                scoreBoardUpdateEvents[i].Invoke(ScoreCalculator.calculatorArray[i](diceResult), true);
            else
                scoreBoardUpdateEvents[i].Invoke(scores[i], false);
        }

    }
    public void fixScore(int idx)
    {
        scores[idx] = ScoreCalculator.calculatorArray[idx](getDiceValueArray());
        scoreEnable[idx] = false;
        scoreBoardUpdateEvents[idx].Invoke(scores[idx], false);
    }
    private int[] getDiceValueArray()
    {
        int[] scores = new int[5];
        for (int i = 0; i < 5; ++i)
        {
            scores[i] = diceGroup.diceArray[i].value + 1;
        }
        return scores;
    }
    public int getDiceValue(int idx) => diceGroup.diceArray[idx].value;
    public bool isDiceSelected(int idx) => diceGroup.rollingArray[idx];
}

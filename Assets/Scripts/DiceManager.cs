﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DiceManager : MonoBehaviour
{
    private DiceGroup diceGroup;
    public UnityEvent<int>[] diceImageUpdateEvents = new UnityEvent<int>[5];
    public UnityEvent<int, bool>[] scoreBoardUpdateEvents = new UnityEvent<int, bool>[13];
    public UnityEvent resetDiceSelectionEvent = new UnityEvent();
    public UnityEvent<string> updateTotalScoreEvent = new UnityEvent<string>();
    public UnityEvent<string> updateZombieScoreEvent = new UnityEvent<string>();
    public UnityEvent<bool, int> updateDiceRollingChanceEvent = new UnityEvent<bool, int>();
    
    public int[] scores 
    {
        get;
        private set;
    } = new int[13];

    [SerializeField]
    private int[] zombieScores = new int[13];
    private int diceChance;

    public int nowRound
    {
        get;
        private set;
    } = 0;

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
            scores[i] = 0;
        }
        updateTotalScoreEvent.Invoke("0");
        updateZombieScoreEvent.Invoke(zombieScores[nowRound].ToString());
        diceChance = 2;
        updateDiceRollingChanceEvent.Invoke(false, diceChance);
    }

    public void selectDice(int idx) { 
        diceGroup.SelectRolledDice(idx); 
        updateDiceRollingChanceEvent.Invoke(isRollEnable(), diceChance);
    }

    public void rollSelectedDice() 
    {
        if (diceChance > 0)
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
            updateDiceRollingChanceEvent.Invoke(isRollEnable(), --diceChance);
        }
    }
    public void fixScore(int idx)
    {
        scores[idx] = ScoreCalculator.calculatorArray[idx](getDiceValueArray());
        scoreEnable[idx] = false;

        int totalScore = 0;
        for(int i = 0; i < 13; ++i)
        {
            totalScore += scores[i];
        }

        if (totalScore <= zombieScores[++nowRound])
        {
            if (zombieScores[nowRound] > 0)
            {
                SceneManager.LoadScene("LoseScene");
                return;
            }
        }

        if (nowRound > 11) 
        {
            SceneManager.LoadScene("WinScene");
            return;
        }
        updateTotalScoreEvent.Invoke(totalScore.ToString());
        updateZombieScoreEvent.Invoke(zombieScores[nowRound].ToString());
        for (int i = 0; i < 5; ++i)
        {
            diceGroup.diceArray[i].RollDice();
            diceImageUpdateEvents[i].Invoke(diceGroup.diceArray[i].value);
        }
        resetDiceSelectionEvent.Invoke();
        diceGroup.resetRolledDice();

        int[] diceResult = getDiceValueArray();
        for (int i = 0; i < 13; ++i)
        {
            if (scoreEnable[i])
                scoreBoardUpdateEvents[i].Invoke(ScoreCalculator.calculatorArray[i](diceResult), true);
            else
                scoreBoardUpdateEvents[i].Invoke(scores[i], false);
        }

        diceChance = 2;
        updateDiceRollingChanceEvent.Invoke(isRollEnable(), diceChance);
    }
    private int[] getDiceValueArray()
    {
        int[] scores = new int[5];
        for (int i = 0; i < 5; ++i)
        {
            scores[i] = diceGroup.diceArray[i].value;
        }
        return scores;
    }
    public int getDiceValue(int idx) => diceGroup.diceArray[idx].value;
    public bool isDiceSelected(int idx) => diceGroup.rollingArray[idx];

    public bool isRollEnable()
    {
        bool result = false;
        for (int i = 0; i < 5; ++i)
        {
            result = result || diceGroup.rollingArray[i];
        }
        return result;
    }
}

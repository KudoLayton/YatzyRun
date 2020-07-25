using System;
using System.Text.RegularExpressions;

class ScoreCalculator{
    public delegate int Calculator(int[] dice);

    static public Calculator[] calculatorArray = new Calculator[]
    {
        new Calculator(Aces),
        new Calculator(Twos),
        new Calculator(Threes),
        new Calculator(Fours),
        new Calculator(Fives),
        new Calculator(Sixes),

        new Calculator(Choice),
        new Calculator(ThreeOfAKind),
        new Calculator(FourOfAKind),
        new Calculator(FullHouse),
        new Calculator(SmallStraight),
        new Calculator(LargeStraight),
        new Calculator(Yahtzee)
    };

    static public int Aces(int[] dice){
        int score = 0;
        for (int i = 0; i < 5; i++)
        {
            if (dice[i] == 1)
                score += dice[i];
        }
        return score;
    }
    static public int Twos(int[] dice){
        int score = 0;
        for (int i = 0; i < 5; i++)
        {
            if (dice[i] == 2)
                score += dice[i];
        }
        return score;
    }
    static public int Threes(int[] dice){
        int score = 0;
        for (int i = 0; i < 5; i++)
        {
            if (dice[i] == 3)
                score += dice[i];
        }
        return score;
    }
    static public int Fours(int[] dice){
        int score = 0;
        for (int i = 0; i < 5; i++)
        {
            if (dice[i] == 4)
                score += dice[i];
        }
        return score;
    }
    static public int Fives(int[] dice){
        int score = 0;
        for (int i = 0; i < 5; i++)
        {
            if (dice[i] == 5)
                score += dice[i];
        }
        return score;
    }
    static public int Sixes(int[] dice){
        int score = 0;
        for (int i = 0; i < 5; i++)
        {
            if (dice[i] == 6)
                score += dice[i];
        }
        return score;
    }
    static public int ThreeOfAKind(int[] dice){
        int score = 0;
        int counter;
        string numOfDice = "";
        Regex reg = new Regex(@"3");
        for (int i = 0; i < 6; i++){
            counter = 0;
            for (int j = 0; j < 5; j++)
                if(dice[j] == i)
                    counter++;
            numOfDice += counter.ToString();
        }
        if (reg.IsMatch(numOfDice)){
            for(int i=0;i<5;i++)
            score+=dice[i];
        }
        return score;
    }
    static int FourOfAKind(int[] dice){
        int score = 0;
        int counter;
        string numOfDice = "";
        Regex reg = new Regex(@"4");
        for (int i = 0; i < 6; i++){
            counter = 0;
            for (int j = 0; j < 5; j++)
                if(dice[j] == i)
                    counter++;
            numOfDice += counter.ToString();
        }
        if (reg.IsMatch(numOfDice)){
            for(int i=0;i<5;i++)
            score+=dice[i];
        }
        return score;
    }
    static int FullHouse(int[] dice){
        int score = 0;
        int counter;
        string numOfDice = "";
        Regex reg = new Regex(@"20*3|30*2");
        for (int i = 0; i < 6; i++){
            counter = 0;
            for (int j = 0; j < 5; j++)
                if(dice[j] == i)
                    counter++;
            numOfDice += counter.ToString();
        }
        if (reg.IsMatch(numOfDice))
            score = 25;
        return score;
    }
    static int SmallStraight(int[] dice){
        int score = 0;
        int counter;
        string numOfDice = "";
        Regex reg = new Regex(@"[12]{4}");
        for (int i = 0; i < 6; i++){
            counter = 0;
            for (int j = 0; j < 5; j++)
                if(dice[j] == i)
                    counter++;
            numOfDice += counter.ToString();
        }
        if (reg.IsMatch(numOfDice))
            score = 30;
        return score;
    }
    static int LargeStraight(int[] dice){
        int score = 0;
        int counter;
        string numOfDice = "";
        Regex reg = new Regex(@"1{5}");
        for (int i = 0; i < 6; i++){
            counter = 0;
            for (int j = 0; j < 5; j++)
                if(dice[j] == i)
                    counter++;
            numOfDice += counter.ToString();
        }
        if (reg.IsMatch(numOfDice))
            score = 40;
        return score;
    }
    static int Choice(int[] dice){
        int score = 0;
        for(int i=0;i<5;i++)
            score+=dice[i];
        return score;
    }
    static int Yahtzee(int[] dice){
        int score = 0;
        int counter;
        string numOfDice = "";
        Regex reg = new Regex(@"5");
        for (int i = 0; i < 6; i++){
            counter = 0;
            for (int j = 0; j < 5; j++)
                if(dice[j] == i)
                    counter++;
            numOfDice += counter.ToString();
        }
        if (reg.IsMatch(numOfDice))
            score += 50;
        return score;
    }
}
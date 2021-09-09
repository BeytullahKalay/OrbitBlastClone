using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty
{
    static int currentScore = 0;
    static float scoresToMaxDifficulty = 10;


    public static float GetDifficultyPercent()
    {
        return Mathf.Clamp01(currentScore / scoresToMaxDifficulty);
    }

    public static void IncreaseCurrentScore()
    {
        currentScore++;
    }

    public static int GetCurrentScore()
    {
        return currentScore;
    }
}

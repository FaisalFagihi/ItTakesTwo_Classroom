using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public TextMeshProUGUI firstDigit;
    public TextMeshProUGUI mathOperatorSign;
    public TextMeshProUGUI secondDigit;
    public TextMeshProUGUI GoalDigit;
    public TextMeshProUGUI result;
    public TextMeshProUGUI levelNumber;
    private MathOperator selectedMathOperator;
    /// <summary>
    /// Generated Level Goal
    /// </summary>
    private int levelGoal;
    public LevelTimer timer;
    public int timerInSeconds = 20;
    private float levelLoadTimeInSeconds = 1.5f;
    private float timeLeft;
    private bool hasWon;
    private System.Array mathOperatorValues;
    private int levelCounter;
    public List<Level> levels;
    // Start is called before the first frame update
    void Start()
    {
        //level timer
        timer.TimerInSeconds = timerInSeconds;
        //transctiom time between levels.
        timeLeft = levelLoadTimeInSeconds;
        //math Opreaterts list it has the baisc oprations: +, -, x and ÷.
        mathOperatorValues = System.Enum.GetValues(typeof(MathOperator));
        //Generate the first level.
        GenerateLevel();
    }
    /// <summary>
    /// Level Generator.
    /// </summary>
    private void GenerateLevel()
    {
        if (++levelCounter >= levels.Count)
        {
            levelCounter = 1;
        }
        result.text = "";
        timer.Reset();
        levelNumber.text = $"{levelCounter}/{levels.Count}";
        //selectedMathOperator = (MathOperator)mathOperatorValues.GetValue(Random.Range(0, mathOperatorValues.Length));
        selectedMathOperator = levels[levelCounter - 1].mathOperator;
        switch (selectedMathOperator)
        {
            case global::MathOperator.plus:
                levelGoal = Random.Range(1, 18);
                mathOperatorSign.text = "+";
                break;
            case global::MathOperator.minus:
                levelGoal = Random.Range(-9, 9);
                mathOperatorSign.text = "-";
                break;
            case global::MathOperator.cross:
                levelGoal = Random.Range(1, 9) * Random.Range(1, 9);
                mathOperatorSign.text = "x";
                break;
            case global::MathOperator.divide:
                levelGoal = Random.Range(1, 4);
                mathOperatorSign.text = "÷";
                break;
            default:
                break;
        }
        GoalDigit.text = levelGoal.ToString();
        timeLeft = levelLoadTimeInSeconds;
        hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player has alraedy won.
        WinningChecker();

        if (CalculateTheAnswer() == levelGoal)
        {
            hasWon = true;
        }
        else if (timer.HasFinished)
        {
            result.color = Color.red;
            result.text = "Lost :(";
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                GenerateLevel();
            }
        }
    }

    /// <summary>
    /// Calculates the ansewr based on the seleced mathOperator and GoalDigit.
    /// </summary>
    /// <returns> Answer in integer </returns>
    private int CalculateTheAnswer()
    {
        switch (selectedMathOperator)
        {
            case global::MathOperator.plus:
                return (int.Parse(firstDigit.text) + int.Parse(secondDigit.text));
            case global::MathOperator.minus:
                return (int.Parse(firstDigit.text) - int.Parse(secondDigit.text));
            case global::MathOperator.cross:
                return (int.Parse(firstDigit.text) * int.Parse(secondDigit.text));
            case global::MathOperator.divide:
                if (!secondDigit.text.Equals("0"))
                {
                    return (int.Parse(firstDigit.text) / int.Parse(secondDigit.text));
                }
                return 0;
        }

        return 0;
    }

    private void WinningChecker()
    {
        if (hasWon)
        {
            result.color = Color.green;
            result.text = "Won :)";
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                GenerateLevel();
            }
        }
    }
}

public enum MathOperator
{
    plus,
    minus,
    cross,
    divide
}

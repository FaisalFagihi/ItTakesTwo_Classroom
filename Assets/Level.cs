using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    public TextMeshProUGUI firstDigit;
    public TextMeshProUGUI secondDigit;
    public TextMeshProUGUI GoalDigit;
    public TextMeshProUGUI result;
    private int levelGoal;
    public LevelTimer timer;
    public int timerInSeconds = 20;
    public Menu menu;
    private float levelLoadTimeInSeconds = 1.5f;
    private float timeLeft;
    private bool hasWon;

    // Start is called before the first frame update
    void Start()
    {
        timer.TimerInSeconds = timerInSeconds;
        timeLeft = levelLoadTimeInSeconds;
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        result.text = "";
        timer.Reset();
        levelGoal = Random.Range(1, 18);
        GoalDigit.text = levelGoal.ToString();
        timeLeft = levelLoadTimeInSeconds;
        hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        WinningChecker();
        if ((int.Parse(firstDigit.text) + int.Parse(secondDigit.text) == levelGoal))
        {
            hasWon = true;
            //menu.gameObject.SetActive(true);
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
        //result.text = (int.Parse(firstDigit.text) + int.Parse(secondDigit.text)).ToString();
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

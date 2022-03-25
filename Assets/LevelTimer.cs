using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI value;
    private float timeLeft;

    public bool HasFinished { get; set; }

    public float TimerInSeconds { get; set; } = 30;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }


    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft >= 0)
        {
            value.text = timeLeft.ToString("0:00");
        }
        else
        {
            HasFinished = true;
        }
    }
    public void Reset()
    {
        HasFinished = false;
        timeLeft = TimerInSeconds;
    }

}


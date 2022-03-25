using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text Title;
    public Button HomeButton;
    public Button RestartButton;
    public Button NextButton;

    public bool IsLast;
    // Start is called before the first frame update
    void Start()
    {
        Title.text = "Level 1 Test"; 
        if (IsLast)
        {
            NextButton.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

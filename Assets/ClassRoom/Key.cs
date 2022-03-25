using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int value;
    public TextMeshProUGUI display;
    // Start is called before the first frame update
    void Start()
    {
        display.text = value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

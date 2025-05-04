using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeIsrRunning = true;
    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeIsrRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsrRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
    }

    void DisplayTime (float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); 
        timeText.text = string.Format("{0:00} : {1:00}", minutes , seconds);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text textTimer;

    private float timer =  0.0f;    
    public bool istimer = false;

    // Update is called once per frame
    public void Update()
    {
        if(istimer)
        {
            timer += Time.deltaTime;
            DisplayTime();
        }
    }
    
    void DisplayTime()
    {
        int minutes =Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
     public void StartTimer()
     {
        istimer = true;
     }
     public void StopTimer()
     {
        istimer = false;
     }
     public void ResetTimer()
     {
        timer = 0.0f;
     }

     
}


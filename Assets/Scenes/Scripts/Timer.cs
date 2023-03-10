using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time_display;
    [SerializeField] private TextMeshProUGUI time_display_menu;
    private GameObject player;
    private float timer;
    void Start()
    {
        ResetTimer();
       player = GameObject.Find("Plane"); 
    }

    void Update()
    {
        if(player != null)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay((int)timer);
            
        } else 
        {
            time_display.enabled = false;
            time_display_menu.enabled = true;
        }
    }
    private void UpdateTimerDisplay(int time)
    {
        time_display.text = time.ToString();
        time_display_menu.text = time.ToString();    
    }
    private void ResetTimer()
    {
        timer = 0f;
        time_display.enabled = true;
    }
}

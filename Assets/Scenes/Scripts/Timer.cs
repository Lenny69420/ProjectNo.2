using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time_display;
    [SerializeField] private TextMeshProUGUI time_display_menu;
    [SerializeField] private GameObject easterEgg;
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
            ShowEasterEgg((int)timer);
        } else 
        {
            time_display.enabled = false;
            time_display_menu.enabled = true;
        }
    }
    public void ShowEasterEgg(int timer)
    {
            if (timer >= 300){easterEgg.SetActive(true);} 
            if (timer >= 302) {easterEgg.SetActive(false);}
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

using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    public TMP_Text timeText;
    public float time = 15;
    public AudioSource audioSource;
    public UnityEvent OnCountdownFinished;
    
    bool counting = false;

    private void Awake()
    {
        timeText.text = Mathf.Round(time).ToString();
    }
    
    public void StartCountdown()
    {
        counting = true;
    }

    private void Update()
    {
        if (!counting) return;

        if (time > 0)
        {
            timeText.text = Mathf.Round(time).ToString();            
        }
        else if (counting)
        {
            counting = false;
            timeText.text = 0.ToString();
            audioSource.Play();
            OnCountdownFinished.Invoke();
        }

        time -= Time.deltaTime;
    }
}

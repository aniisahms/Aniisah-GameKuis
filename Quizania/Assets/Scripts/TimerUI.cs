using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] LevelMessageUI messageUI = null;
    [SerializeField] float timer = 30f;
    [SerializeField] Slider timeBar = null;
    private float timeLeft = 0f;
    private bool timeRunning = true;

    public bool TimeRunning {
        get => timeRunning;
        set => timeRunning = value;
    }

    void Start()
    {
        RestartTimer();
    }

    void Update()
    {
        if (!timeRunning) {
            return;
        }

        timeLeft -= Time.deltaTime;
        timeBar.value = timeLeft/timer;

        if (timeLeft <= 0f) {
            messageUI.Message = "Time has run out.";
            messageUI.gameObject.SetActive(true);
            timeRunning = false;
            return;
        }
    }

    public void RestartTimer() {
        timeLeft = timer;
    }
}

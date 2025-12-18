using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Task Settings")]
    public float taskDuration = 30f;
    public int targetSliceAmount = 100;

    [Header("UI")]
    public Image progressBar;   // Fill type Image
    public Text timerText;

    private float timeLeft;
    private int currentSlices;
    private bool taskActive;

    void Start() {
        StartTask();
    }

    void Update() {
        if (!taskActive) return;

        // TIMER
        timeLeft -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0f) {
            EndTask();
        }

        // BAR GÜNCELLEME
        progressBar.fillAmount = (float)currentSlices / targetSliceAmount;
    }

    public void StartTask() {
        timeLeft = taskDuration;
        currentSlices = 0;
        taskActive = true;
    }

    public void SlicePotato() {
        if (!taskActive) return;

        currentSlices++;

        if (currentSlices >= targetSliceAmount) {
            TaskSuccess();
        }
    }

    void EndTask() {
        taskActive = false;

        if (currentSlices >= targetSliceAmount)
            TaskSuccess();
        else
            TaskFail();
    }

    void TaskSuccess() {
        taskActive = false;
        Debug.Log("GÖREV BAÞARILI: Patatesler dilimlendi");
    }

    void TaskFail() {
        Debug.Log("GÖREV BAÞARISIZ: Süre doldu");
    }
}
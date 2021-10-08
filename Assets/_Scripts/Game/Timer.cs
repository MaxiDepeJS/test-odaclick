using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int seconds = 100;
    private int sec;

    public Text txtTimer;

    public bool isDestroyable;

    private void Start()
    {
        sec = seconds;
        SetTimer(sec);
        Invoke("UpdateTimer", 1);
    }

    public void StopTimer()
    {
        CancelInvoke();
    }

    private void UpdateTimer()
    {
        sec--;
        SetTimer(sec);

        if (sec <= 95 && isDestroyable)
        {
            if (this.gameObject.GetComponent<ObjectGame>().name == "TARGETBRAND")
            {
                ControllerGame.INS.SubtractPoints(10);
                Destroy(this.gameObject);
            }

            if (this.gameObject.GetComponent<ObjectGame>().name == "SHIELD")
            {
                ControllerGame.INS.SubtractPoints(5);
                Destroy(this.gameObject);
            }

            if (!this.gameObject.GetComponent<ObjectGame>().isClicked)
            {
                ControllerGame.INS.SubtractPoints(1);
                Destroy(this.gameObject);
            }
        }

        if (sec < 40 && ControllerGame.INS.points < 100)
        {
            ControllerGame.INS.GameOver("You exceeded 2 minutes to reach 100 points. Game Over!");
            StopTimer();
            return;
        }

        if (sec < 1)
        {
            StopTimer();
            return;
        }

        Invoke("UpdateTimer", 1);
    }

    private void SetTimer(int seconds)
    {
        if (isDestroyable) return;
        txtTimer.text = seconds.ToString();
    }
}

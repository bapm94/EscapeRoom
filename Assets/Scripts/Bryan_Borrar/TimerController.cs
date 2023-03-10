using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeInScreen;
    bool paused;
    [SerializeField] float totalTime = 10*60;
    float timer;
    bool timerOn;
    public GameObject resultScreen;
    public TextMeshProUGUI finalTime;
    public TextMeshProUGUI finalInsight;

    private void Start()
    {
        //LeanTween.reset();
        timer = totalTime;
        timerOn = true;
        //LeanTween.delayedCall(2, () => timerOn = true);
    }


    // Update is called once per frame
    void Update()
    {
        if (timerOn && !paused && timer > 0 && resultScreen.activeSelf == false)
        {
        
            timer -= Time.deltaTime;
            float minutesLeft = Mathf.FloorToInt(timer / 60);
            float secondsLeft = Mathf.FloorToInt(timer % 60);
            timeInScreen.text = string.Format("{0:00} : {1:00}", minutesLeft, secondsLeft);
        }
        if(resultScreen.activeSelf == true)
        {
            SetFinalTime();
        }
    }

    public void SetFinalTime()
    {
        finalTime.text = timeInScreen.text;
        finalInsight.text = CluesController.instance.insigth.ToString();
    }
}

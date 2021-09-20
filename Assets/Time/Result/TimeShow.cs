using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeShow : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Time;
    public Result result;
    public float totalTime;
    private int minute;
    private float seconds;
    private float milli_Sec;
    void Start()
    {

        totalTime = result.Time;

        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;
        milli_Sec = (seconds - (int)seconds * 1) * 100;
        //Time = GameObject.Find("ResultTime").GetComponent<Text>();
        Time.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00") + ":" + ((int)milli_Sec).ToString("00");

    }

    // Update is called once per frame
    void Update()
    {

    }
}

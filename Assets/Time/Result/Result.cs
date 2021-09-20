using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public CountUP result;
    public int count = 0;
    public int ShowObject = 3;
    public float WaitTime = 1;
    public float Time;

    public GameObject GAMEOVER;
    public GameObject YOURTIME;
    public GameObject TIME;
    // Start is called before the first frame update
    void Start()
    {
        Time = result.totalTime;
        Debug.Log(Time);
        Invoke("Text", WaitTime);

    }

    // Update is called once per frame
    void Update()
    {

    }


    void Text()
    {
        count++;
        if (count == 1)
        {
            GAMEOVER.SetActive(true);
            Invoke("Text", WaitTime);
        }
        if (count == 2)
        {
            YOURTIME.SetActive(true);
            Invoke("Text", WaitTime);
        }
        if (count == 3)
        {
            TIME.SetActive(true);

        }
    }
}


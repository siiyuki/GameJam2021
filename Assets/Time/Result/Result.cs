using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public int count = 0;
    public int ShowObject = 3;
    public float WaitTime = 1;
    public float Time;

    public GameObject GAMEOVER;
    public GameObject YOURTIME;
    public GameObject TIME;
    public GameObject Button1;
    public GameObject Button2;

    private Image background;
    private float animartionTime = 0;
    private float alfa = 0.5f;
    private float overalfa = 1f;
    void Start()
    {
        Time = CountUP.totalTime;
        Debug.Log(Time);
        //Invoke("Text", WaitTime);

        background = GameObject.Find("ResultBackground").GetComponent<Image>();
        background.color = new Color(1, 1, 1, 0);
        GAMEOVER.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        YOURTIME.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        TIME.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        background.color = SetColor(background.color.a, alfa, 0.05f);

        animartionTime += UnityEngine.Time.deltaTime;

        if (WaitTime < animartionTime && animartionTime < (WaitTime * 2f))
        {
            GAMEOVER.SetActive(true);
            SetAnimartion(GAMEOVER, overalfa, 0.05f);
        }
        else if ((WaitTime * 2f) < animartionTime && animartionTime < (WaitTime * 3f))
        {
            YOURTIME.SetActive(true);
            SetAnimartion(YOURTIME, overalfa, 0.05f);
        }
        else if((WaitTime * 3f) < animartionTime && animartionTime < (WaitTime * 4f))
        {
            TIME.SetActive(true);
            SetAnimartion(TIME, overalfa, 0.05f);
        }
        else if ((WaitTime * 5f) < animartionTime && animartionTime < (WaitTime * 6f))
        {
            Button1.SetActive(true);
            SetAnimartion(Button1, overalfa, 0f);
            Button2.SetActive(true);
            SetAnimartion(Button2, overalfa, 0f);
        }
    }

    Color SetColor(float a, float b, float f) => new Color(1, 1, 1, Mathf.Lerp(a, b, f));

    void SetAnimartion(GameObject g, float alfa, float val)
    {
        var image = g.GetComponent<Image>();
        image.color = SetColor(image.color.a, alfa, val);
    }

    //void Text()
    //{
    //    count++;
    //    if (count == 1)
    //    {
    //        GAMEOVER.SetActive(true);
    //        Invoke("Text", WaitTime);
    //    }
    //    if (count == 2)
    //    {
    //        YOURTIME.SetActive(true);
    //        Invoke("Text", WaitTime);
    //    }
    //    if (count == 3)
    //    {
    //        TIME.SetActive(true);

    //    }
    //}
}


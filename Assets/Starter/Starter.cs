using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    public int CountDown;
    public int ShowCountMax;
    private Text starterText;
    private Renderer BackgroundBlur;

    private float animartionTime = 0;

    private void Awake()
    {
        GameObject.Find("TimeCanvas").GetComponent<CountUP>().StartTime = CountDown;
        GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().StartTime = CountDown;
        GameObject.Find("StartBase").GetComponent<StartBase>().brakeTime = CountDown + 8f;
        if (CountDown < ShowCountMax)
            Debug.LogError("ShowCountMax cannot be less than CountDown.");
    }

    void Start()
    {
        starterText = GameObject.Find("StarterText").GetComponent<Text>();
        BackgroundBlur = GameObject.Find("StarterBlur").GetComponent<Renderer>();
    }

    void Update()
    {
        animartionTime += Time.deltaTime;
        var time = CountDown - Mathf.RoundToInt(animartionTime);
        starterText.text = time <= ShowCountMax ? time.ToString() : ShowCountMax.ToString();

        if (time <= 0)
        {
            starterText.color = new Color(1, 1, 1, 0);
            var gf = BackgroundBlur.material.GetFloat("_Blur");
            BackgroundBlur.material.SetFloat("_Blur", Mathf.Lerp(gf, 0f, 0.2f));
            if ((Mathf.Round(gf * 100f) / 100f) == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

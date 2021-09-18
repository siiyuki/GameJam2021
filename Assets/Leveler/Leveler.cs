using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leveler : MonoBehaviour
{
    public string Level;
    public GameObject Circle;

    private float InsideCircleSize = 80;
    private float OutsideCircleSize = 130;
    private float TextSize = 0.6f;
    private float RotateSpeed = 100;
    private float AnimationRate = 0.05f;
    private float AnimationLength = 2f;
    private float Transparency = 0.5f;
    private float AnimationDelayLength = 0.1f;

    private GameObject InsideObject;
    private GameObject OutsideObject;

    private GameObject LevelObject;
    private Text LevelText;

    private float InsideMaxSize;
    private float OutsideMaxSize;
    private float TextMaxSize;
    private float RotateTime = 0;
    private float AnimationTime = 0;
    private bool AnimationStartFlug = false;

    void Start()
    {
        LevelObject = GameObject.Find("LevelerText");
        LevelText = LevelObject.GetComponent<Text>();
        TextSize *= 0.01f;
        TextMaxSize = TextSize * 5f;
        LevelText.text = Level;
        LevelText.color = new Color(0, 0, 0, 0);
        LevelObject.transform.localScale = new Vector3(TextMaxSize, TextMaxSize, TextMaxSize);

        InsideMaxSize = InsideCircleSize * 10f;
        OutsideMaxSize = OutsideCircleSize * 10f;
        InsideObject = CircleInitialise(Circle, InsideMaxSize);
        OutsideObject = CircleInitialise(Circle, OutsideMaxSize);
    }

    void Update()
    {
        RotateTime += Time.deltaTime * RotateSpeed;
        AnimationTime += Time.deltaTime;

        InsideObject.transform.eulerAngles = new Vector3(0, 0, RotateTime);
        OutsideObject.transform.eulerAngles = new Vector3(0, 0, -RotateTime);

        var nowSize = InsideObject.GetSize();
        var nowTran = InsideObject.GetTransparency();

        if (AnimationTime < AnimationLength)
        {
            InsideObject.CircleSet(
                Mathf.Lerp(nowSize, InsideCircleSize, AnimationRate), 
                Mathf.Lerp(nowTran, Transparency, AnimationRate));
        }
        else
        {
            InsideObject.CircleSet(
                Mathf.Lerp(nowSize, InsideMaxSize, AnimationRate * 0.1f), 
                Mathf.Lerp(nowTran, 0f, AnimationRate));
        }

        nowSize = OutsideObject.GetSize();
        nowTran = OutsideObject.GetTransparency();
        if (AnimationTime > AnimationDelayLength)
        {
            AnimationStartFlug = true;
            if (AnimationTime < AnimationLength)
            {
                OutsideObject.CircleSet(
                    Mathf.Lerp(nowSize, OutsideCircleSize, AnimationRate), 
                    Mathf.Lerp(nowTran, Transparency, AnimationRate));
            }
            else
            {
                OutsideObject.CircleSet(
                    Mathf.Lerp(nowSize, OutsideMaxSize, AnimationRate * 0.1f), 
                    Mathf.Lerp(nowTran, 0f, AnimationRate));
            }
        }

        nowSize = LevelObject.GetSize();
        nowTran = LevelObject.GetComponent<Text>().color.a;
        if (AnimationTime > AnimationDelayLength)
        {
            if (AnimationTime < AnimationLength)
            {
                LevelObject.TextSet(
                    Mathf.Lerp(nowSize, TextSize, AnimationRate * 0.8f),
                    Mathf.Lerp(nowTran, Transparency, AnimationRate * 0.5f));
            }
            else
            {
                LevelObject.TextSet(
                    Mathf.Lerp(nowSize, TextMaxSize, AnimationRate * 0.1f),
                    Mathf.Lerp(nowTran, 0f, AnimationRate * 0.5f));
            }
        }

        if (RoundTo3Digits(InsideObject.GetTransparency()) == 0 &&
            RoundTo3Digits(OutsideObject.GetTransparency()) == 0 &&
            AnimationStartFlug)
        {
            DestroyObject(transform);
        }
    }

    private GameObject CircleInitialise(GameObject gameObject, float size)
    {
        var g = Instantiate(gameObject);
        g.transform.parent = transform;
        g.transform.localPosition = Vector3.zero;
        g.transform.localScale = new Vector3(size, size, size);
        g.SetTransparency(0);
        return g;
    }
    public static float RoundTo3Digits(float value) =>
        Mathf.Round(value * 1000f) / 1000f;

    public static void DestroyObject(Transform target)
    {
        for (int i = 0; i < target.childCount; ++i)
            Destroy(target.GetChild(i).gameObject);
        Destroy(target.gameObject);
    }
}

public static class Expansion
{
    public static void SetTransparency(this GameObject gameObject, float value) =>
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, value);
    public static float GetSize(this GameObject gameObject) =>
        gameObject.transform.localScale.x;
    public static float GetTransparency(this GameObject gameObject) =>
        gameObject.GetComponent<MeshRenderer>().material.color.a;
    public static void CircleSet(this GameObject gameObject, float size, float transparency)
    {
        gameObject.transform.localScale = new Vector3(size, size, size);
        gameObject.SetTransparency(transparency);
    }
    public static void TextSet(this GameObject gameObject, float size, float transparency)
    {
        gameObject.transform.localScale = new Vector3(size, size, size);
        gameObject.GetComponent<Text>().color = new Color(1f, 1f, 1f, transparency);
    }
} 

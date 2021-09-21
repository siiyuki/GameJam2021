using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundChage : MonoBehaviour
{
    private SpriteRenderer[] ImageSprite;

    private int nowSelected = 0;

    private float AnimationTime = 0;

    private bool AnimartionFlug = false;

    private int TaskNow, TaskNext;
    void Start()
    {
        ImageSprite = GetChildlnSpriteRenderer(GameObject.Find("BackgroundGrounds"));

        for (int i = 0; i < ImageSprite.Length; i++)
            ImageSprite[i].color = new Color(1, 1, 1, 0);

        ImageSprite[GetRandom(ref nowSelected)].color = new Color(1, 1, 1, 1);
    }

    
    void Update()
    {
        if (AnimartionFlug)
        {
            if (AnimationTime == 0)
            {
                TaskNow = nowSelected;
                TaskNext = GetRandom(ref nowSelected);
            }
            AnimationTime += Time.deltaTime;

            ImageSprite[TaskNow].color = new Color(1, 1, 1, Mathf.Lerp(
                ImageSprite[TaskNow].color.a, 0f, 0.01f));
            ImageSprite[TaskNext].color = new Color(1, 1, 1, Mathf.Lerp(
                 ImageSprite[TaskNext].color.a, 1f, 0.01f));

            if (AnimationTime > 10f)
            {
                AnimartionFlug = false;
                AnimationTime = 0;
            }
        }
    }

    public void Switch()
    {
        AnimartionFlug = true;
    }

    private int GetRandom(ref int now)
    {
        int r = 0, max = ImageSprite.Length - 1;
        for (int i = 0; i < 100; i++)
        {
            r = Random.Range(0, max);
            if (r != now) break;
        }
        now = r;
        return r;
    }

    SpriteRenderer[] GetChildlnSpriteRenderer(GameObject parent)
    {
        var c = new SpriteRenderer[parent.transform.childCount];
        for (int i = 0; i < parent.transform.childCount; i++)
            c[i] = parent.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
        return c;
    }
}
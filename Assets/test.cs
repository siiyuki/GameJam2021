using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private float r = 2f;
    private float speed = 100f;
    private float time = 0;

    void Start()
    {

    }
    void Update()
    {
        time += Time.deltaTime * speed;
        var pos = new Vector2(
            Mathf.Sin(time * (Mathf.PI / 180f)) * r,
            Mathf.Cos(time * (Mathf.PI / 180f)) * r
        );
        transform.position = pos;
    }
}

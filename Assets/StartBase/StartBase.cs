using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBase : MonoBehaviour
{
    public float brakeTime;

    private float time;

    private bool Flug = true;
    void Start()
    {
        
    }
    void Update()
    {
        time += Time.deltaTime;

        if (time > brakeTime && Flug)
        {
            gameObject.AddComponent<Rigidbody>();
            Flug = false;
        }
        if (time > brakeTime + 3f)
        {
            Destroy(gameObject);
        }
    }
}

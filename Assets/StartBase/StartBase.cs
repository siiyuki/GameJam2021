using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBase : MonoBehaviour
{
    public float brakeTime;

    private float time;
    void Start()
    {
        
    }
    void Update()
    {
        time += Time.deltaTime;

        if (time > brakeTime)
        {
            gameObject.AddComponent<Rigidbody>();
        }
        if (time > brakeTime + 3f)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBase : MonoBehaviour
{
    private float time;

    private bool Flug = true;
    void Start()
    {
        
    }
    void Update()
    {
        time += Time.deltaTime;

        if (time > GameManager.BrakeGroundTime && Flug)
        {
            gameObject.AddComponent<Rigidbody>();
            Flug = false;
        }
        if (time > GameManager.BrakeGroundTime + 3f)
        {
            Destroy(gameObject);
        }
    }
}

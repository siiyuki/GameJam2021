using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLeveler : MonoBehaviour
{
    public GameObject Leveler;
    public float Cycle;
    public Vector3 localPosition;

    public float Timer { get; private set; }
    public int NowLevel { get; private set; } = 0;

    private float time = 0;
    private float timesum = 0;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        Timer = timesum + time;

        if (time > Cycle)
        {
            var g = Instantiate(Leveler);
            g.GetComponent<Leveler>().Level = ++NowLevel;
            g.transform.parent = transform;
            g.transform.localPosition = localPosition;
            timesum = time;
            time = 0;
        }
        Debug.Log("testLeveler : " + Timer);
    }
}

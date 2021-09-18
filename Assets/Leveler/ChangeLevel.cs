using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public GameObject Leveler;
    public Vector3 localPosition;

    private ObjectSpawner ob;
    private float StartSpawnInterval;
    private float StartObjectDrag;

    public int NowLevel { get; private set; } = 0;

    public void Start()
    {
        ob = GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>();
        StartSpawnInterval = ob.SpawnInterval;
        StartObjectDrag = ob.ObjectDrag;

    }

    public void Switch()
    {
        if(ob.SpawnInterval != 0)
        {
            ob.SpawnInterval = StartSpawnInterval - (NowLevel / 10f);
        }
        ob.ObjectDrag = StartObjectDrag - (NowLevel / 1f);
        var g = Instantiate(Leveler);
        g.GetComponent<Leveler>().Level = ++NowLevel;
        g.transform.parent = transform;
        g.transform.localPosition = localPosition;
    }
}

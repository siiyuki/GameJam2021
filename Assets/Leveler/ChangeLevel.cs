using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public GameObject Leveler;
    public Vector3 localPosition;

    public float SpawnIntervalLevelRate;
    public float ObjectDragLevelRate;

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
        var g = Instantiate(Leveler);
        var sval = StartSpawnInterval - ((StartSpawnInterval / SpawnIntervalLevelRate) * NowLevel);
        ob.SpawnInterval = sval > 0 ? sval : 0.1f;
        ob.ObjectDrag = StartObjectDrag - ((StartObjectDrag / ObjectDragLevelRate) * NowLevel);
        g.GetComponent<Leveler>().Level = (++NowLevel).ToString();
        g.transform.parent = transform;
        g.transform.localPosition = localPosition;
    }
}

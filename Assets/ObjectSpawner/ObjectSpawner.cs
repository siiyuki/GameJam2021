using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float MaxWidth;
    public float SpawnInterval;
    public float DestroyHeight;
    public float ObjectMass;
    public float ObjectDrag;
    public float ObjectAngularDrag;
    public float StartTime;
    public GameObject[] Objects;

    private List<GameObject> spawnObjects = new List<GameObject>();
    private float time = 0;

    void Start()
    {
        time = SpawnInterval - StartTime;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > SpawnInterval)
        {
            var grand = Random.Range(-(MaxWidth / 2f), MaxWidth / 2f);
            Spawn(grand, new Vector3(
                Random.Range(0, 360),
                Random.Range(0, 360),
                Random.Range(0, 360)
                ));
            time = 0;
        }
        Destroy();
    }

    void Spawn(float x, Vector3 angle)
    {
        var grand = Random.Range(0, Objects.Length);
        var g = Instantiate(Objects[grand]);
        var r = g.GetComponent<Rigidbody>();
        r.mass = ObjectMass;
        r.drag = ObjectDrag;
        r.angularDrag = ObjectAngularDrag;
        g.transform.eulerAngles = angle;
        g.transform.position = new Vector2(x, transform.position.y);
        g.transform.parent = transform;
        spawnObjects.Add(g);
    }

    void Destroy()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            if (-DestroyHeight > spawnObjects[i].transform.localPosition.y)
            {
                Destroy(spawnObjects[i]);
                spawnObjects.RemoveAt(i);
            }
        }
    }
}

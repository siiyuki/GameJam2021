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
    public bool RotateX, RotateY, RotateZ;
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
            var harf = MaxWidth / 2f; time = 0;
            Spawn(Random.Range(-harf, harf), new Vector3(randomRad(), randomRad(), randomRad()));
        }
        Destroy();
    }

    float randomRad() => Random.Range(0, 360);

    void Spawn(float x, Vector3 angle)
    {
        var grand = Random.Range(0, Objects.Length);
        var g = Instantiate(Objects[grand]);
        var r = g.GetComponent<Rigidbody>();
        r.mass = ObjectMass;
        r.drag = ObjectDrag;
        r.angularDrag = ObjectAngularDrag;
        g.transform.position = new Vector2(x, transform.position.y);
        g.transform.eulerAngles = new Vector3(
            RotateX ? angle.x : 0,
            RotateY ? angle.y : 0,
            RotateZ ? angle.z : 0);
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

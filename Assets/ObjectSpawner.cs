using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float MaxWidth;
    public float MaxFallSpeed;
    public float DestroyHeight;
    public float ObjectMass;
    public float ObjectDrag;
    public float ObjectAngularDrag;
    public GameObject[] Objects;

    private List<GameObject> spawnObjects = new List<GameObject>();
    private float time = 0;
    private bool SpawnFlug = true;

    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;

        if ((Mathf.Floor(time * 10f) / 10f) % MaxFallSpeed == 0)
        {
            if (SpawnFlug)
            {
                var grand = Random.Range(-(MaxWidth / 2f), MaxWidth / 2f);
                Spawn(grand);
                SpawnFlug = false;
            }
        }
        else
        {
            SpawnFlug = true;
        }
        Destroy();
    }

    void Spawn(float x)
    {
        var grand = Random.Range(0, Objects.Length);
        var g = Instantiate(Objects[grand]);
        var r = g.GetComponent<Rigidbody>();
        r.mass = ObjectMass;
        r.drag = ObjectDrag;
        r.angularDrag = ObjectAngularDrag;
        g.transform.position = new Vector2(x, transform.position.y);
        g.transform.parent = transform;
        spawnObjects.Add(g);
    }

    void Destroy()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            if (DestroyHeight > spawnObjects[i].transform.localPosition.y)
            {
                Destroy(spawnObjects[i]);
                spawnObjects.RemoveAt(i);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float MaxWidth;
    public float MaxFallSpeed;
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
    }

    void Spawn(float x)
    {
        var grand = Random.Range(0, Objects.Length);
        var g = Instantiate(Objects[grand]);
        g.transform.position = new Vector2(x, transform.position.y);
        g.transform.parent = transform;
        spawnObjects.Add(g);
    }
}

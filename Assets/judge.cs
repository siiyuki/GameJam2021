using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judge : MonoBehaviour
{
    public GameObject result;
    public float GameOverHeight = -10f;

    private GameObject player;
    void Start()
    {
        player = GameObject.Find("GamePlayerObject");
    }

    void Update()
    {
        if (player)
        {
            var pos = player.transform.position.y;
            if (pos < GameOverHeight)
            {
                var s = Instantiate(result);
                s.transform.position = Vector3.zero;
                Destroy(player);
            }
        }
    }
}

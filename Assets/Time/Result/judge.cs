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
                result.GetComponent<Result>().Time = CountUP.totalTime;
                result.transform.position = Vector3.zero + new Vector3(0,0,-5f);
                result.GetComponent<Result>().StartFlug = true;
                Destroy(player);
            }
        }
    }
}

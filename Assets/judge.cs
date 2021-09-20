using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judge : MonoBehaviour
{
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
                Debug.Log("GameOver");
                Destroy(player);
            }
        }
    }
}

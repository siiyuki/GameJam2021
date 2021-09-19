using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float LevelUpInterval;
    public float FirstScaffoldingTime;
    private void Awake()
    {
        GameObject.Find("TimeCanvas").GetComponent<CountUP>().Cycle = LevelUpInterval;
        GameObject.Find("StartBase").GetComponent<StartBase>().brakeTime = FirstScaffoldingTime;
    }
}

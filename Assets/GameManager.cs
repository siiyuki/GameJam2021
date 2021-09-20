using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int StartCountdown = 4;
    public int StartCountDownDisplayMax = 3;
    public float LevelUpCycle = 20;
    public float SpawnerWidth = 4;
    public float SpawnInterval = 2.5f;
    public float ObjectDrag = 8;
    public float DestroyHeight = 15;
    public float ObjectMass = 100;
    public float ObjectAngularDrag = 0.05f;
    public bool SpawnRotateX = false;
    public bool SpawnRotateY = false;
    public bool SpawnRotateZ = true;
    public float SpawnIntervalLevelRate = 120;
    public float ObjectDragLevelRate = 100;
    public KeyCode Up = KeyCode.Space;
    public KeyCode Right = KeyCode.D;
    public KeyCode Down = KeyCode.S;
    public KeyCode Left = KeyCode.A;

    private void Awake()
    {
        var s = GameObject.Find("Starter").GetComponent<Starter>();
        s.CountDown = StartCountdown;
        s.ShowCountMax = StartCountDownDisplayMax;
        var tc = GameObject.Find("TimeCanvas").GetComponent<CountUP>();
        tc.Cycle = LevelUpCycle;
        var os = GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>();
        os.MaxWidth = SpawnerWidth;
        os.SpawnInterval = SpawnInterval;
        os.DestroyHeight = DestroyHeight;
        os.ObjectMass = ObjectMass;
        os.ObjectDrag = ObjectDrag;
        os.ObjectAngularDrag = ObjectAngularDrag;
        os.RotateX = SpawnRotateX;
        os.RotateY = SpawnRotateY;
        os.RotateZ = SpawnRotateZ;
        var l = GameObject.Find("Leveler").GetComponent<ChangeLevel>();
        l.SpawnIntervalLevelRate = SpawnIntervalLevelRate;
        l.ObjectDragLevelRate = ObjectDragLevelRate;
        var m = GameObject.Find("GamePlayerObject").GetComponent<Move>();
        m.UP = Up;
        m.Right = Right;
        m.Left = Left;
        m.Down = Down;
    }
}

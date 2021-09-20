using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float LevelUpCycle = 20;
    public static float BrakeGroundTime = 8;
    public static float TimerStartTime = 1;
    public static float SpawnerWidth = 4;
    public static float SpawnInterval = 2.5f;
    public static float ObjectDrag = 8;
    public static float DestroyHeight = 15;
    public static float ObjectMass = 100;
    public static float ObjectAngularDrag = 0.05f;
    public static float SpawnerStartTime = 0;
    public static bool SpawnRotateX = false;
    public static bool SpawnRotateY = false;
    public static bool SpawnRotateZ = true;
    public static float SpawnIntervalLevelRate = 120;
    public static float ObjectDragLevelRate = 100;
    public static KeyCode Up = KeyCode.Space;
    public static KeyCode Right = KeyCode.D;
    public static KeyCode Down = KeyCode.S;
    public static KeyCode Left = KeyCode.A;

    private void Awake()
    {
        GameObject.Find("StartBase").GetComponent<StartBase>().brakeTime = BrakeGroundTime;
        var tc = GameObject.Find("TimeCanvas").GetComponent<CountUP>();
        tc.Cycle = LevelUpCycle;
        tc.StartTime = TimerStartTime;
        var os = GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>();
        os.MaxWidth = SpawnerWidth;
        os.SpawnInterval = SpawnInterval;
        os.DestroyHeight = DestroyHeight;
        os.ObjectMass = ObjectMass;
        os.ObjectDrag = ObjectDrag;
        os.ObjectAngularDrag = ObjectAngularDrag;
        os.StartTime = SpawnerStartTime;
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

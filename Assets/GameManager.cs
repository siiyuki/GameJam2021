using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float レベルアップのインターバル;
    public float 足場が落ちるまでの時間;
    public float タイマー開始時間;
    public float スポナー横幅;
    public float スポナー初めのインターバル;
    public float スポナー初めの抗力;
    public float スポナー削除の縦幅;
    public float スポナーオブジェクトの重さ;
    public float スポナー回転効力;
    public float スポナー開始時間;
    public bool スポナースポーン時回転X; 
    public bool スポナースポーン時回転Y; 
    public bool スポナースポーン時回転Z;
    public float レベラー目標レベル値;
    public float レベラー目標抗力値;
    public KeyCode 操作キー上, 操作キー右, 操作キー下, 操作キー左, 操作キージャンプ;

    private void Awake()
    {
        GameObject.Find("StartBase").GetComponent<StartBase>().brakeTime = 足場が落ちるまでの時間;
        var tc = GameObject.Find("TimeCanvas").GetComponent<CountUP>();
        tc.Cycle = レベルアップのインターバル;
        tc.StartTime = タイマー開始時間;
        var os = GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>();
        os.MaxWidth = スポナー横幅;
        os.SpawnInterval = スポナー初めのインターバル;
        os.DestroyHeight = スポナー削除の縦幅;
        os.ObjectMass = スポナーオブジェクトの重さ;
        os.ObjectDrag = スポナー初めの抗力;
        os.ObjectAngularDrag = スポナー回転効力;
        os.StartTime = スポナー開始時間;
        os.RotateX = スポナースポーン時回転X;
        os.RotateY = スポナースポーン時回転Y;
        os.RotateZ = スポナースポーン時回転Z;
        var l = GameObject.Find("Leveler").GetComponent<ChangeLevel>();
        l.SpawnIntervalLevelRate = レベラー目標レベル値;
        l.ObjectDragLevelRate = レベラー目標抗力値;
    }
}

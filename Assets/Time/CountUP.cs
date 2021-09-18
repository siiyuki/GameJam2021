using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountUP : MonoBehaviour
{
    // Start is called before the first frame update
    //　トータル制限時間
    public float totalTime;
    //　制限時間（分）
    [SerializeField]
    private int minute;
    //　制限時間（秒）
    [SerializeField]
    private float seconds;

    //　制限時間（ミリ）
    //[SerializeField]
    private float milli_Sec;

    //時間切れ前に赤くなる
    public int Redtime;

    //　前回Update時の秒数
    private float oldTime;
    private Text TimerText;

    private float leveltime = 0;
    public float Cycle;
    void Start()
    {
        //totalTime = minute * 60 + seconds;
        totalTime = 0f;
        oldTime = 0f;
        TimerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //　制限時間が0秒以下なら何もしない
        if (totalTime <= 0f)
        {
            TimerText.text = "Time UP!!";
            TimeUP = true;

            return;
        }
        //　一旦トータルの制限時間を計測；
        totalTime = minute * 60 + seconds;
        totalTime -= Time.deltaTime;

        //　再設定
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;
        milli_Sec = (seconds - (int)seconds * 1)*100;

        //　タイマー表示用UIテキストに時間を表示する
        if (milli_Sec != oldTime)
        {

                TimerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00") + ":" + ((int)milli_Sec).ToString("00");
            
        }

        if((int)seconds <= Redtime)
        {
            TimerText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); 
        }


        //oldTime = seconds;//秒が変わっていたら表示を更新するため秒を保存
        oldTime = milli_Sec;


        //level change operation
        leveltime += Time.deltaTime;
        if (leveltime > Cycle)
        {
            GameObject.Find("Leveler").GetComponent<ChangeLevel>().Switch();
            leveltime = 0;
        }
    }
}
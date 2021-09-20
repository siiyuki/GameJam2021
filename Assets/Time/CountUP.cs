using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountUP : MonoBehaviour
{
    // Start is called before the first frame update
    //�@�g�[�^������
    public static float totalTime;
    //�@�������ԁi���j
    [SerializeField]
    private int minute;
    //�@�������ԁi�b�j
    [SerializeField]
    private float seconds;

    //�@�������ԁi�~���j
    //[SerializeField]
    private float milli_Sec;

    //�@�O��Update���̕b��
    private float oldTime;
    private Text TimerText;
    private Text LevelerText;

    private float leveltime = 0;
    public float Cycle;
    private float StartTimeBuffer = 0;
    public float StartTime;
    void Start()
    {
        //totalTime = minute * 60 + seconds;
        totalTime = 0f;
        oldTime = 0f;
        TimerText = GameObject.Find("TimerText").GetComponent<Text>();
        LevelerText = GameObject.Find("LevelerCountText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimeBuffer > StartTime)
        {
            //�@��U�g�[�^���̐������Ԃ��v���G
            totalTime = minute * 60 + seconds;
            totalTime += Time.deltaTime;

            //�@�Đݒ�
            minute = (int)totalTime / 60;
            seconds = totalTime - minute * 60;
            milli_Sec = (seconds - (int)seconds * 1) * 100;

            //�@�^�C�}�[�\���pUI�e�L�X�g�Ɏ��Ԃ�\������
            if (milli_Sec != oldTime)
            {
                TimerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00") + ":" + ((int)milli_Sec).ToString("00");
            }

            //oldTime = seconds;//�b���ς���Ă�����\�����X�V���邽�ߕb��ۑ�
            oldTime = milli_Sec;

            //level change operation
            leveltime += Time.deltaTime;
            LevelerText.text = (Cycle - leveltime).ToString("000.000") + "/s to level up";
            if (leveltime > Cycle)
            {
                GameObject.Find("Leveler").GetComponent<ChangeLevel>().Switch();
                leveltime = 0;
            }
        }
        else
        {
            StartTimeBuffer += Time.deltaTime;
        }
    }
}
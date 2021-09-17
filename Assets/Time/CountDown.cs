using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    //�@�g�[�^����������
    private float totalTime;
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


    //���Ԑ؂ꂩ�ǂ����̔���@���Ԑ؂��true
    public bool TimeUP = false; 

    void Start()
    {
        totalTime = minute * 60 + seconds;
        oldTime = 0f;
        TimerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //�@�������Ԃ�0�b�ȉ��Ȃ牽�����Ȃ�
        if (totalTime <= 0f)
        {
            TimerText.text = "Time UP!!";
            TimeUP = true;

            return;
        }
        //�@��U�g�[�^���̐������Ԃ��v���G
        totalTime = minute * 60 + seconds;
        totalTime -= Time.deltaTime;

        //�@�Đݒ�
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;
        milli_Sec = (seconds - (int)seconds * 1)*100;

        //�@�^�C�}�[�\���pUI�e�L�X�g�Ɏ��Ԃ�\������
        if (milli_Sec != oldTime)
        {
           // if ((int)seconds != (int)oldTime)
           // {
                // TimerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
                TimerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00") + ":" + ((int)milli_Sec).ToString("00");
            //TimerText.text = minute.ToString("00") + ":" + seconds.ToString("00");
            //TimerText.text = minute.ToString("00") + ":" + seconds.ToString("00") + ":" + milli_Sec;
        }

        //oldTime = seconds;//�b���ς���Ă�����\�����X�V���邽�ߕb��ۑ�
        oldTime = milli_Sec;

    }
}
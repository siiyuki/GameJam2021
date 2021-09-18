using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountUP : MonoBehaviour
{
    // Start is called before the first frame update
    //�@�g�[�^����������
    public float totalTime;
    //�@�������ԁi���j
    [SerializeField]
    private int minute;
    //�@�������ԁi�b�j
    [SerializeField]
    private float seconds;

    //�@�������ԁi�~���j
    //[SerializeField]
    private float milli_Sec;

    //���Ԑ؂�O�ɐԂ��Ȃ�
    public int Redtime;

    //�@�O��Update���̕b��
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

                TimerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00") + ":" + ((int)milli_Sec).ToString("00");
            
        }

        if((int)seconds <= Redtime)
        {
            TimerText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); 
        }


        //oldTime = seconds;//�b���ς���Ă�����\�����X�V���邽�ߕb��ۑ�
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
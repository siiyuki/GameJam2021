using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    //�A�j���[�^�[�Ɠ�i�W�����v�p�̎q�I�u�W�F�N�g�̐錾
    Animator animator;
    public GameObject Jump_Sec;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�E�����Ă��邢�Ă���Ƃ�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Right", true);
            animator.SetBool("Walk", true);
        }

        //�������Ă��邢�Ă���Ƃ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("Right", false);
            animator.SetBool("Walk", true);
        }

        //�~�܂��Ă���Ƃ�
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Walk", false);
        }

        //�W�����v�����Ƃ�
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        }

        //���n���ăW�����v�񐔉�
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("Jump", false);
        }


        //��i�ڂ̃W�����v��
        if (Input.GetKeyDown(KeyCode.X))
        {
            Jump_Sec.SetActive(true);

            Invoke("Second_Jump_Effect_OFF", 1);
        }
    }

    void Second_Jump_Effect_OFF()
    {
        Jump_Sec.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb2d;
    public float scroll = 10f;
    public float flap = 1000f;
    float direction = 0f;

    public Jump_hantei J_hantei;//���n����

    private int jumpcount = 0;
   
    bool jump = false;

    private int MaxJump = 2;
    AudioSource JumpSE;

    public KeyCode UP = KeyCode.W;
    public KeyCode Right = KeyCode.D;
    public KeyCode Left = KeyCode.A;
    public KeyCode Down = KeyCode.S;

    //�A�j���[�^�[�Ɠ�i�W�����v�p�̎q�I�u�W�F�N�g�̐錾
    Animator animator;//�A�j���[�V�����p
    public GameObject Jump_Sec;
    public int leavecount=0;
    void Start()
    {
        rb2d = GetComponent<Rigidbody>();
        JumpSE = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();//�A�j���[�V�����p
    }

    void Update()
    {
        
        if(Get.KeyDown(UP))
        {
            if(jumpcount < MaxJump)
            {
                J_hantei.isGround = false;//���n����
                animator.SetBool("Jump", true);
                rb2d.AddForce(Vector2.up * 350f);
                jump = true;
                
                jumpcount++;
                if(leavecount==0 && J_hantei.leave == true)
                {
                    jumpcount++;
                    leavecount++;
                }
                JumpSE.Play();
                if(jumpcount > 1)//�A�j���[�V�����p
                {
                    Jump_Sec.SetActive(true);

                    Invoke("Second_Jump_Effect_OFF", 1);
                }
                
                //jumpcount++;
               
            }
        }
        else if (Get.Key(Right))//���ړ�
        {
            animator.SetBool("Right", true);//�A�j���[�V�����p
            animator.SetBool("Walk", true);//�A�j���[�V�����p
            direction = 1f;
            
            

        }
        else if (Get.Key(Left))
        {
            animator.SetBool("Right", false);//�A�j���[�V�����p
            animator.SetBool("Walk", true);//�A�j���[�V�����p
            direction = -1f;
           

        }

        //���n�ړ��i���ړ��j
        else if (Get.Key(Down))
        {
            rb2d.AddForce(Vector2.down * 5.0f);
        }
        else
        {
            direction = 0f;
        }

        //�~�܂��Ă���Ƃ�
        if (Get.KeyUp(Right) || Get.KeyUp(Left))
        {
            animator.SetBool("Walk", false);//�A�j���[�V�����p
        }

        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);


        if(J_hantei.isGround == true)
        {
            jump = false;
            jumpcount = 0;
            leavecount = 0;
            animator.SetBool("Jump", false);//�A�j���[�V�����p
        }

    }
    //���n������P�̂��߃R�����g��
    /*
    private void OnCollisionEnter(Collision collision)
    {
        jump = false;
        jumpcount = 0;
        animator.SetBool("Jump", false);//�A�j���[�V�����p
    }
    */

    void Second_Jump_Effect_OFF()//�A�j���[�V�����p
    {
        Jump_Sec.SetActive(false);
    }
}

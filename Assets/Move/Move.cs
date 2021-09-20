using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb2d;
    public float scroll = 10f;
    public float flap = 1000f;
    float direction = 0f;
    
    private int jumpcount = 0;
   
    bool jump = false;

    private int MaxJump = 2;
    AudioSource JumpSE;

    

    public KeyCode UP;
    public KeyCode Right;
    public KeyCode Left;
    public KeyCode Down;

    //�A�j���[�^�[�Ɠ�i�W�����v�p�̎q�I�u�W�F�N�g�̐錾
    Animator animator;
    public GameObject Jump_Sec;

    void Start()
    {
        rb2d = GetComponent<Rigidbody>();
        JumpSE = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(UP))
        {
            if(jumpcount <= MaxJump)
            {
                animator.SetBool("Jump", true);
                rb2d.AddForce(Vector2.up * 350f);
                jump = true;
                
                jumpcount++;
                JumpSE.Play();
                
                if(jumpcount > 1)
                {
                    Jump_Sec.SetActive(true);

                    Invoke("Second_Jump_Effect_OFF", 1);
                }
                jumpcount++;
            }
        }
        else if (Input.GetKey(Right))//���ړ�
        {
            animator.SetBool("Right", true);
            animator.SetBool("Walk", true);
            direction = 1f;
            
            

        }
        else if (Input.GetKey(Left))
        {
            animator.SetBool("Right", false);
            animator.SetBool("Walk", true);
            direction = -1f;
           

        }

        //���n�ړ��i���ړ��j
        else if (Input.GetKey(Down))
        {
            rb2d.AddForce(Vector2.down * 5.0f);
        }
        else
        {
            direction = 0f;
        }

        //�~�܂��Ă���Ƃ�
        if (Input.GetKeyUp(Right) || Input.GetKeyUp(Left))
        {
            animator.SetBool("Walk", false);
        }

        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        jump = false;
        jumpcount = 0;
        animator.SetBool("Jump", false);
    }

    void Second_Jump_Effect_OFF()
    {
        Jump_Sec.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb2d;
    public float scroll = 10f;
    public float flap = 1000f;
    float direction = 0f;

    public Jump_hantei J_hantei;//着地判定

    private int jumpcount = 0;
   
    bool jump = false;

    private int MaxJump = 2;
    AudioSource JumpSE;

    public KeyCode UP = KeyCode.W;
    public KeyCode Right = KeyCode.D;
    public KeyCode Left = KeyCode.A;
    public KeyCode Down = KeyCode.S;

    //アニメーターと二段ジャンプ用の子オブジェクトの宣言
    Animator animator;//アニメーション用
    public GameObject Jump_Sec;
    public int leavecount=0;
    void Start()
    {
        rb2d = GetComponent<Rigidbody>();
        JumpSE = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();//アニメーション用
    }

    void Update()
    {
        
        if(Get.KeyDown(UP))
        {
            if(jumpcount < MaxJump)
            {
                J_hantei.isGround = false;//着地判定
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
                if(jumpcount > 1)//アニメーション用
                {
                    Jump_Sec.SetActive(true);

                    Invoke("Second_Jump_Effect_OFF", 1);
                }
                
                //jumpcount++;
               
            }
        }
        else if (Get.Key(Right))//横移動
        {
            animator.SetBool("Right", true);//アニメーション用
            animator.SetBool("Walk", true);//アニメーション用
            direction = 1f;
            
            

        }
        else if (Get.Key(Left))
        {
            animator.SetBool("Right", false);//アニメーション用
            animator.SetBool("Walk", true);//アニメーション用
            direction = -1f;
           

        }

        //着地移動（下移動）
        else if (Get.Key(Down))
        {
            rb2d.AddForce(Vector2.down * 5.0f);
        }
        else
        {
            direction = 0f;
        }

        //止まっているとき
        if (Get.KeyUp(Right) || Get.KeyUp(Left))
        {
            animator.SetBool("Walk", false);//アニメーション用
        }

        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);


        if(J_hantei.isGround == true)
        {
            jump = false;
            jumpcount = 0;
            leavecount = 0;
            animator.SetBool("Jump", false);//アニメーション用
        }

    }
    //着地判定改善のためコメント化
    /*
    private void OnCollisionEnter(Collision collision)
    {
        jump = false;
        jumpcount = 0;
        animator.SetBool("Jump", false);//アニメーション用
    }
    */

    void Second_Jump_Effect_OFF()//アニメーション用
    {
        Jump_Sec.SetActive(false);
    }
}

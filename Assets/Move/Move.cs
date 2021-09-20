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

    public KeyCode UP = KeyCode.W;
    public KeyCode Right = KeyCode.D;
    public KeyCode Left = KeyCode.A;
    public KeyCode Down = KeyCode.S;

    //アニメーターと二段ジャンプ用の子オブジェクトの宣言
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
        
        if(Get.KeyDown(UP))
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
        else if (Get.Key(Right))//横移動
        {
            animator.SetBool("Right", true);
            animator.SetBool("Walk", true);
            direction = 1f;
            
            

        }
        else if (Get.Key(Left))
        {
            animator.SetBool("Right", false);
            animator.SetBool("Walk", true);
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

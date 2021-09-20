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

    private int MaxJump = 1;
    AudioSource JumpSE;

    

    public KeyCode UP;
    public KeyCode Right;
    public KeyCode Left;
    public KeyCode Down;

    //アニメーターと二段ジャンプ用の子オブジェクトの宣言
    Animator animator;
    public GameObject Jump_Sec;

    void Start()
    {
<<<<<<< HEAD
        rb2d = GetComponent<Rigidbody2D>();
        JumpSE = GetComponent<AudioSource>();
        

=======
        rb2d = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
>>>>>>> 83398876c9bbb21b5d77fcafde0cb168965e5674
    }

    void Update()
    {
        if(Input.GetKeyDown(UP))
        {
            if(jumpcount<=MaxJump)
            {
                animator.SetBool("Jump", true);
                rb2d.AddForce(Vector2.up * 350f);
                jump = true;
<<<<<<< HEAD
                
                
                jumpcount++;
                JumpSE.Play();

=======
>>>>>>> 83398876c9bbb21b5d77fcafde0cb168965e5674

                if(jumpcount > 0)
                {
                    Jump_Sec.SetActive(true);

                    Invoke("Second_Jump_Effect_OFF", 1);
                }
                jumpcount++;
            }
        }
        else if (Input.GetKey(Right))//横移動
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

        //着地移動（下移動）
        else if (Input.GetKey(Down))
        {
            rb2d.AddForce(Vector2.down * 5.0f);
        }
        else
        {
            direction = 0f;
        }

        //止まっているとき
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

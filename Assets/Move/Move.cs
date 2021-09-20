using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float scroll = 10f;
    public float flap = 1000f;
    float direction = 0f;
    
    private int jumpcount = 0;
   
    bool jump = false;

    private int MaxJump = 1;

    //アニメーターと二段ジャンプ用の子オブジェクトの宣言
    Animator animator;
    public GameObject Jump_Sec;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(jumpcount<=MaxJump)
            {
                animator.SetBool("Jump", true);
                rb2d.AddForce(Vector2.up * 350f);
                jump = true;
                
                
                if(jumpcount > 0)
                {
                    Jump_Sec.SetActive(true);

                    Invoke("Second_Jump_Effect_OFF", 1);
                }


                jumpcount++;

            }
           

        }


        //横移動
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Right", true);
            animator.SetBool("Walk", true);
            direction = 1f;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("Right", false);
            animator.SetBool("Walk", true);
            direction = -1f;

        }





        //着地移動（下移動）
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.AddForce(Vector2.down * 5.0f);
        }



        
      

        else
        {
            direction = 0f;

        }



        //止まっているとき
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Walk", false);
        }

        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);



    }


    private void OnCollisionEnter2D(Collision2D collision)
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

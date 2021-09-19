using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    //アニメーターと二段ジャンプ用の子オブジェクトの宣言
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
        //右向いてあるいているとき
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Right", true);
            animator.SetBool("Walk", true);
        }

        //左向いてあるいているとき
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("Right", false);
            animator.SetBool("Walk", true);
        }

        //止まっているとき
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Walk", false);
        }

        //ジャンプしたとき
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        }

        //着地してジャンプ回数回復
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("Jump", false);
        }


        //二段目のジャンプ時
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

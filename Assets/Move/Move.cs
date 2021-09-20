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


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(jumpcount<=MaxJump)
            {

                rb2d.AddForce(Vector2.up * 350f);
                jump = true;
                
                
                jumpcount++;

            }
           

        }


        //‰¡ˆÚ“®
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1f;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1f;

        }





        //’…’nˆÚ“®i‰ºˆÚ“®j
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.AddForce(Vector2.down * 5.0f);
        }



        
      

        else
        {
            direction = 0f;

        }


        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = false;
        jumpcount = 0;
    }

}

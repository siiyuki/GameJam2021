using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_hantei : MonoBehaviour
{
    public bool leave = false;
    public bool isGround = true;
    public Move Move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag != "player")
        {
            isGround = true;
            leave = false;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag != "player")
        {
            //isGround = true;
            leave = true;

        }
    }
}

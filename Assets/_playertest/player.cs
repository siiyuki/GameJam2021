using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float JumpForce;
    public float MoveForce;
    public int MaxJumps;

    private Rigidbody PlayerRigidBody;
    private int JumpCount = 0;
    void Start()
    {
        PlayerRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (JumpCount < MaxJumps))
        {
            PlayerRigidBody.AddForce(new Vector3(0f, JumpForce, 0f), ForceMode.Impulse);
            JumpCount++;
        }

        if (Input.GetKey(KeyCode.A))
        {
            PlayerRigidBody.AddForce(new Vector3(-MoveForce, 0f, 0f), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerRigidBody.AddForce(new Vector3(MoveForce, 0f, 0f), ForceMode.Force);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        JumpCount = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 500f;
    static readonly float diagonalModifier = 0.71f;

    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float xSpeed = 0f;
        float ySpeed = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            ySpeed = moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xSpeed = -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            ySpeed = -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xSpeed = moveSpeed * Time.deltaTime;
        }

        if (ySpeed != 0f && xSpeed != 0f)
        {
            ySpeed *= diagonalModifier;
            xSpeed *= diagonalModifier;
        }

        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x + xSpeed, myRigidBody.velocity.y + ySpeed);
    }
}

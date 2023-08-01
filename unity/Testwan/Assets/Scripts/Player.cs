using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 500f;
    public float vertical = Input.GetAxisRaw("Vertical");
    public float horizontal = Input.GetAxisRaw("Horizotal");
    static readonly float diagonalModifier = 0.71f;

    private Rigidbody2D myRigidBody;
    private PlayerSpawn spawn;
    private Killable killable;
    public Animator animator;
    Vector2 movement;

    void Start()
    {
        this.myRigidBody = GetComponent<Rigidbody2D>();
        this.spawn = FindObjectOfType<PlayerSpawn>();
        this.killable = GetComponent<Killable>();
       
        this.killable.SetOnKillHandler(this.OnKilled);

        this.Respawn();
    }

    void Update()
    {
        Move();
    }

    private void OnKilled()
    {
        this.Respawn();
        this.killable.ToFullHealth();
    }

    void Move()
    {
        float xSpeed = 0f;
        float ySpeed = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            ySpeed = moveSpeed * Time.deltaTime;
            Debug.Log(ySpeed);
            animator.SetFloat("Vertical", ySpeed);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Speed", 1);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            xSpeed = -moveSpeed * Time.deltaTime;
            Debug.Log(xSpeed);
            animator.SetFloat("Horizontal", xSpeed);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 1);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            ySpeed = -moveSpeed * Time.deltaTime;
            Debug.Log(ySpeed);
            animator.SetFloat("Vertical", ySpeed);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Speed", 1);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            xSpeed = moveSpeed * Time.deltaTime;
            Debug.Log(xSpeed);
            animator.SetFloat("Horizontal", xSpeed);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 1);
        }

        if (ySpeed != 0f && xSpeed != 0f)
        {
            ySpeed *= diagonalModifier;
            xSpeed *= diagonalModifier;
        }

        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x + xSpeed, myRigidBody.velocity.y + ySpeed);
    }

    public Killable GetKillable()
    {
        return this.killable;
    }

    void Respawn()
    {
        this.transform.position = this.spawn.transform.position;
    }
}

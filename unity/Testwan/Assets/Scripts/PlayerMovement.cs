using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    private static readonly float diagonalModifier = 0.71f;

    [SerializeField] private float speed = 5f;

    private Rigidbody2D rigidBody;
    private PlayerSpawn spawn;
    private Killable killable;
    private Animator animator;

    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.spawn = FindObjectOfType<PlayerSpawn>();
        this.killable = GetComponent<Killable>();
        this.animator = GetComponent<Animator>();
       
        this.killable.SetOnKillHandler(this.OnKilled);

        this.Respawn();
    }

    void FixedUpdate()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float ySpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (ySpeed != 0f && xSpeed != 0f)
        {
            ySpeed *= diagonalModifier;
            xSpeed *= diagonalModifier;
        }

        Vector2 newVelocity = new Vector2(this.rigidBody.velocity.x + xSpeed, this.rigidBody.velocity.y + ySpeed);
        this.rigidBody.velocity = newVelocity;

        animator.SetFloat("Horizontal", newVelocity.x);
        //Making the y slightly smaller than the x will cause the animation to only look horizontally when walking diagonally.
        animator.SetFloat("Vertical", newVelocity.y * 0.99f);
        animator.SetFloat("Speed", newVelocity.sqrMagnitude);
    }

    private void OnKilled()
    {
        this.Respawn();
        this.killable.ToFullHealth();
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
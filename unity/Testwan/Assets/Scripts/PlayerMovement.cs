using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rigidBody;
    private PlayerSpawn spawn;
    private Killable killable;
    private Animator animator;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.spawn = FindObjectOfType<PlayerSpawn>();
        this.killable = GetComponent<Killable>();
       
        this.killable.SetOnKillHandler(this.OnKilled);

        this.Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);
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
        //this.transform.position = this.spawn.transform.position;
    }
}
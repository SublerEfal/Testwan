using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static readonly float speedModifier = 10;

    [SerializeField] float moveSpeed = 20f;

    private GameObject target;
    private Rigidbody2D rigidBody;

    void Start()
    {
        this.target = FindObjectOfType<PlayerMovement>().gameObject;
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            MoveTowards(target);
        }
    }

    protected void MoveTowards(GameObject target)
    {
        float xDistance = target.transform.position.x - this.transform.position.x;
        float xVelocity = (xDistance == 0 ? 0 : (xDistance > 0 ? speedModifier : -speedModifier)) * Time.deltaTime * this.moveSpeed;

        float yDistance = target.transform.position.y - this.transform.position.y;
        float yVelocity = (yDistance == 0 ? 0 : (yDistance > 0 ? speedModifier : -speedModifier)) * Time.deltaTime * this.moveSpeed;

        this.rigidBody.AddForce(new Vector2(xVelocity, yVelocity), ForceMode2D.Force);
    }
}

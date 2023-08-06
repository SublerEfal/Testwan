using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : MonoBehaviour
{
    [SerializeField] float cooldownSeconds = 1f;
    [SerializeField] float currentCooldownSeconds = 0;
    [SerializeField] int damage = 10;


    void Start()
    {
        
    }

    void Update()
    {
        currentCooldownSeconds -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (currentCooldownSeconds > 0) return;
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (!player) return;
        player.GetKillable().TakeDamage(damage);
        currentCooldownSeconds = cooldownSeconds;
    }
}

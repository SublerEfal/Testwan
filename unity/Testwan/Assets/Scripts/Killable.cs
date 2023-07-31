using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField] int maxHitpoints = 100;
    [SerializeField] int healingPerInterval = 0;
    [SerializeField] float healingInterval = 1f;
    [SerializeField] float currentHealingCooldown = 1f;

    int currentHitpoints;

    private Action onKillHandler;

    private void Start()
    {
        this.currentHitpoints = this.maxHitpoints;
    }

    void Update()
    {
        this.CheckHeal();
        this.CheckKilled();
    }

    private void CheckHeal()
    {
        currentHealingCooldown -= Time.deltaTime;
        if (currentHealingCooldown > 0) return;
        currentHitpoints = Math.Min(currentHitpoints + healingPerInterval, maxHitpoints);
        currentHealingCooldown = healingInterval;
    }

    private void CheckKilled()
    {
        if (this.currentHitpoints > 0) return;
        
        if (this.onKillHandler != null)
        {
            this.onKillHandler();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        this.currentHitpoints -= damage;
    }

    public void ToFullHealth()
    {
        this.currentHitpoints = this.maxHitpoints;
    }

    public void SetOnKillHandler(Action onKillHandler)
    {
        this.onKillHandler = onKillHandler;
    }

    public int GetCurrentHitpoints()
    {
        return this.currentHitpoints;
    }

    public int GetMaxHitpoints()
    {
        return this.maxHitpoints;
    }
}

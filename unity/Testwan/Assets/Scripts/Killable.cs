using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField] int maxHitpoints = 100;
    int currentHitpoints;

    private Action onKillHandler;

    private void Start()
    {
        this.currentHitpoints = this.maxHitpoints;
    }

    void Update()
    {
        this.CheckKilled();
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

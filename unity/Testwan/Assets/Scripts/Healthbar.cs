using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Killable killableGameObject;

    void Update()
    {
        float healthPercentage = (float) killableGameObject.GetCurrentHitpoints() / killableGameObject.GetMaxHitpoints();
        this.transform.localScale = new Vector3(Math.Clamp(healthPercentage, 0, 1), this.transform.localScale.y, this.transform.localScale.z);
    }
}

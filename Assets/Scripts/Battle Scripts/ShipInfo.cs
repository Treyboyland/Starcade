using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipInfo : MonoBehaviour
{
    public int CurrentAmmo;
    public int CurrentHealth;
    public int CurrentShields;
    public int MaxAmmo;
    public int MaxHealth;
    public int MaxShields;
    public float Speed;
    public bool IsPlayer;

    public virtual void DamageShip(int amount)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        if (CurrentHealth == 0)
        {
            gameObject.SetActive(false);
        }
    }
}

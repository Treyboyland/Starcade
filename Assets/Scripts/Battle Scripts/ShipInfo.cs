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

    public bool IsShip = true;

    public FactionType Faction;

    [SerializeField]
    protected GameEvent hitEvent = null;

    public IntEvent OnAmmoChanged = new IntEvent();

    public IntEvent OnHealthChanged = new IntEvent();

    public IntEvent OnShieldsChanged = new IntEvent();

    public static ShipDeathParticleController ParticleController;

    protected bool checkedForSpriteRenderer = false;

    protected SpriteRenderer spriteRenderer;

    public virtual void DamageShip(int amount)
    {
        //TODO: Implement shields 2:1 damage?

        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        if (hitEvent != null)
        {
            hitEvent.RaiseEvent();
        }
        OnHealthChanged.Invoke(CurrentHealth);
        if (CurrentHealth == 0)
        {
            SpawnParticle();
            gameObject.SetActive(false);
        }
    }

    protected void SpawnParticle()
    {
        if (ParticleController != null)
        {
            if (!checkedForSpriteRenderer)
            {
                checkedForSpriteRenderer = true;
                spriteRenderer = GetComponent<SpriteRenderer>();
            }
            var color = spriteRenderer != null ? spriteRenderer.color : Color.white;
            ParticleController.OnSpawnAtLocation.Invoke(transform.position, color, IsShip);
        }
    }

    public void SetData(ShipInfo other)
    {
        CurrentAmmo = other.CurrentAmmo;
        CurrentHealth = other.CurrentHealth;
        CurrentShields = other.CurrentShields;
        MaxAmmo = other.MaxAmmo;
        MaxHealth = other.MaxHealth;
        Speed = other.Speed;
        IsPlayer = other.IsPlayer;
    }

    public void FullHeal()
    {
        CurrentAmmo = MaxAmmo;
        CurrentHealth = MaxHealth;
        CurrentShields = MaxShields;
        OnAmmoChanged.Invoke(CurrentAmmo);
        OnHealthChanged.Invoke(CurrentHealth);
        OnShieldsChanged.Invoke(CurrentShields);
    }

    public void DecrementAmmo()
    {
        CurrentAmmo = Mathf.Max(0, CurrentAmmo - 1);
        OnAmmoChanged.Invoke(CurrentAmmo);
    }
}

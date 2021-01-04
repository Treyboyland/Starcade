using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ship : MonoBehaviour
{
    [SerializeField]
    protected ShipDataSO shipData = null;

    public ShipDataSO ShipData
    {
        get
        {
            return shipData;
        }
    }

    [SerializeField]
    bool inDebug = false;

    public int CurrentAmmo;
    public int CurrentHealth;
    public int CurrentShields;

    public float CurrentSpeed;
    public bool IsPlayer;

    public bool IsShip = true;

    [SerializeField]
    protected GameEvent hitEvent = null;

    public IntEvent OnAmmoChanged = new IntEvent();

    public IntEvent OnHealthChanged = new IntEvent();

    public IntEvent OnShieldsChanged = new IntEvent();

    public static ShipDeathParticleController ParticleController;

    protected bool checkedForSpriteRenderer = false;

    protected SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        if (!inDebug)
        {
            FullHeal();
            CurrentSpeed = shipData.Speed;
        }
    }

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

    public void SetData(Ship other)
    {
        CurrentAmmo = other.CurrentAmmo;
        CurrentHealth = other.CurrentHealth;
        CurrentShields = other.CurrentShields;
        this.shipData = other.shipData;
        CurrentSpeed = other.CurrentSpeed;
        IsPlayer = other.IsPlayer;
    }

    public void FullHeal()
    {
        CurrentAmmo = shipData.MaxAmmo;
        CurrentHealth = shipData.MaxHealth;
        CurrentShields = shipData.MaxShields;
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

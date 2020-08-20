﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    ShipInfo ship = null;

    public ShipInfo Ship
    {
        get
        {
            return ship;
        }
        set
        {
            ship = value;
        }
    }

    [SerializeField]
    protected Bullet bulletPrefab = null;

    [SerializeField]
    List<OffsetAndRotation> offsets = new List<OffsetAndRotation>();

    [SerializeField]
    protected bool isPlayer = false;

    public bool IsPlayer
    {
        get
        {
            return isPlayer;
        }
        set
        {
            isPlayer = value;
        }
    }

    [SerializeField]
    protected float fireRate = 0;

    protected float elapsed = 0;

    [SerializeField]
    bool isPlayerControlled = false;

    [SerializeField]
    bool triggerFire = false;

    private void Start()
    {
        if (isPlayer)
        {
            ship = GetComponent<PlayerShip>();
        }
        else
        {
            //Uncomment for enemies that track ammo
            //ship = GetComponent<ShipInfo>();
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        elapsed += Time.deltaTime;
        if (isPlayer && Input.GetButton("Fire"))
        {
            FireWeapon();
        }
    }

    protected virtual void OnEnable()
    {
        elapsed = 0;
    }

    protected virtual bool CanFire()
    {
        if (ship != null && ship.CurrentAmmo <= 0)
        {
            return false;
        }
        if (isPlayerControlled)
        {
            if (triggerFire)
            {
                return Input.GetButtonDown("Fire");
            }
            else
            {
                return elapsed >= fireRate;
            }
        }
        else
        {
            return triggerFire || elapsed >= fireRate;
        }
    }

    public virtual void FireWeapon()
    {
        if (CanFire())
        {
            if (ship != null)
            {
                ship.DecrementAmmo();
            }
            elapsed = 0;
            foreach (var data in offsets)
            {
                Bullet bullet = (Bullet)GamePool.Instance.GetObject(bulletPrefab);
                bullet.IsPlayer = isPlayer;
                //TODO: X Pos is getting coverted into y pos
                // var offset = Vector3.RotateTowards(data.Offset, transform.up, 2 * Mathf.PI, 0);
                // offset.y *= (transform.up == -Vector3.up ? -1 : 1);
                // bullet.transform.position = transform.position +  offset;
                // bullet.transform.rotation = transform.rotation; //Quaternion.AngleAxis(data.Rotation + angle, axis);

                bullet.transform.SetParent(transform);
                bullet.transform.localPosition = data.Offset;
                bullet.transform.rotation = transform.rotation * Quaternion.AngleAxis(data.Rotation, Vector3.forward);
                bullet.transform.SetParent(null);
                bullet.gameObject.SetActive(true);
            }
        }
    }
}

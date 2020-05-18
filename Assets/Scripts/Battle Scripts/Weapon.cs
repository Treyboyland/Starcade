using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected Bullet bulletPrefab = null;

    [SerializeField]
    List<OffsetAndRotation> offsetsEnemy = new List<OffsetAndRotation>();

    [SerializeField]
    List<OffsetAndRotation> offsetsPlayer = new List<OffsetAndRotation>();

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
        return elapsed >= fireRate;
    }

    protected virtual void FireWeapon()
    {
        if (CanFire())
        {
            elapsed = 0;
            foreach (var data in isPlayer ? offsetsPlayer : offsetsEnemy)
            {
                Bullet bullet = (Bullet)GamePool.Instance.GetObject(bulletPrefab);
                bullet.IsPlayer = isPlayer;

                bullet.transform.position = transform.position + Vector3.RotateTowards(data.Offset, transform.up, 2 * Mathf.PI, 0);
                float angle;
                Vector3 axis = Vector3.up;
                transform.rotation.ToAngleAxis(out angle, out axis);
                //Debug.Log(transform.rotation.eulerAngles);
                angle *= transform.rotation.eulerAngles.z < 180 ? 1 : -1;
                bullet.transform.rotation = Quaternion.AngleAxis(data.Rotation + angle, transform.forward);

                bullet.gameObject.SetActive(true);
            }
        }
    }
}

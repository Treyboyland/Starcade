using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineOfSight))]
public class ShootOnSight : MonoBehaviour
{
    [SerializeField]
    List<float> secondsBetweenShots = new List<float>() { 1.0f };

    Weapon weapon;

    LineOfSight lineOfSight;

    bool firing = false;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInParent<Weapon>();
        lineOfSight = GetComponent<LineOfSight>();
        lineOfSight.OnObjectSighted.AddListener(Fire);
    }

    void Fire(bool detected)
    {
        if (detected && !firing)
        {
            //Debug.LogWarning(gameObject.name + " detected player");
            weapon.FireWeapon();
        }
    }

    IEnumerator FireShots()
    {
        firing = true;
        foreach (var interval in secondsBetweenShots)
        {
            weapon.FireWeapon();
            yield return new WaitForSeconds(interval);
        }
        firing = false;
    }
}

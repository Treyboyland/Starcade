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
            StartCoroutine(FireShots());
        }
    }

    IEnumerator FireShots()
    {
        firing = true;
        int count = 0;
        foreach (var interval in secondsBetweenShots)
        {
            count++;
            //Debug.LogWarning(gameObject.name + ": Shot " + count);
            weapon.FireWeapon();
            yield return new WaitForSeconds(interval);
        }
        firing = false;
    }
}

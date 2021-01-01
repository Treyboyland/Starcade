using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Combat/Bullet", order = 10)]
public class BulletDataSO : ScriptableObject
{
    /// <summary>
    /// Amount of damage this bullet should do on impact
    /// </summary>
    [Tooltip("Amount of damage this bullet should do on impact")]
    [SerializeField]
    int damage = 0;

    /// <summary>
    /// Amount of damage this bullet should do on impact
    /// </summary>
    /// <value></value>
    public int Damage
    {
        get
        {
            return damage;
        }
    }


    /// <summary>
    /// How long this bullet should stay active in-game before disappearing
    /// </summary>
    [Tooltip("How long this bullet should live before disappearing")]
    [SerializeField]
    float secondsToLive = 0;

    /// <summary>
    /// How long this bullet should stay active in-game before disappearing
    /// </summary>
    /// <value></value>
    public float SecondsToLive
    {
        get
        {
            return secondsToLive;
        }
    }

    /// <summary>
    /// True if this bullet should not disappear on colliding with an object
    /// </summary>
    [Tooltip("True if this bullet should not disappear on colliding with an object")]
    [SerializeField]
    bool isPiercing = false;

    /// <summary>
    /// True if this bullet should not disappear on colliding with an object
    /// </summary>
    /// <value></value>
    public bool IsPiercing
    {
        get
        {
            return isPiercing;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    BulletDataSO bulletData = null;

    [SerializeField]
    Weapon bulletsOnDisable = null;

    float elapsedSeconds = 0;

    bool isPlayer = false;

    public bool IsPlayer
    {
        get
        {
            return isPlayer;
        }
        set
        {
            isPlayer = value;
            if (bulletsOnDisable != null)
            {
                bulletsOnDisable.IsPlayer = isPlayer;
            }
        }
    }

    Vector3 collisionLocation = new Vector3();

    public static BulletHitParticleController ParticleController = null;

    public static BulletTrailParticleController TrailParticleController = null;

    public EmptyEvent OnBulletDisabled = new EmptyEvent();

    bool trailEventFired = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        elapsedSeconds = 0;
        trailEventFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletData.HasTrail && !trailEventFired && TrailParticleController != null)
        {
            trailEventFired = true;
            TrailParticleController.OnBulletFired.Invoke(this);
        }
        if (IsPlayer)
        {
            elapsedSeconds += Time.deltaTime;
        }
        else if (!IsPlayer && GameConstants.CanEnemiesPassTime)
        {
            elapsedSeconds += Time.deltaTime;
        }
        if (elapsedSeconds >= bulletData.SecondsToLive)
        {
            //TODO: Spawn other bullets if needed
            if (bulletsOnDisable != null)
            {
                bulletsOnDisable.FireWeapon();
            }
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var thing = other.GetComponent<Ship>();
        if (thing != null && thing.IsPlayer != IsPlayer)
        {
            thing.DamageShip(bulletData.Damage);
            collisionLocation = (transform.position + other.transform.position) / 2.0f;
            if (ParticleController != null)
            {
                ParticleController.OnSpawnAtLocation.Invoke(collisionLocation);
            }
            //OnHitAtLocation.Invoke(collisionLocation);
            //Debug.LogWarning("Ship hit!");
            if (!bulletData.IsPiercing)
            {
                OnBulletDisabled.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    int damage = 0;

    [SerializeField]
    float secondsToLive = 0;

    [SerializeField]
    bool isPiercing = false;

    float elapsedSeconds = 0;

    public bool IsPlayer = false;

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
        if (!trailEventFired && TrailParticleController != null)
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
        if (elapsedSeconds >= secondsToLive)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var thing = other.GetComponent<ShipInfo>();
        if (thing != null && thing.IsPlayer != IsPlayer)
        {
            thing.DamageShip(damage);
            collisionLocation = (transform.position + other.transform.position) / 2.0f;
            if (ParticleController != null)
            {
                ParticleController.OnSpawnAtLocation.Invoke(collisionLocation);
            }
            //OnHitAtLocation.Invoke(collisionLocation);
            //Debug.LogWarning("Ship hit!");
            if (!isPiercing)
            {
                OnBulletDisabled.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrailParticleController : MonoBehaviour
{
    [SerializeField]
    BulletTrail trailPrefab = null;

    GamePool pool;

    public BulletEvent OnBulletFired = new BulletEvent();

    // Start is called before the first frame update
    void Start()
    {
        pool = GamePool.Instance;
        Bullet.TrailParticleController = this;
        OnBulletFired.AddListener(SpawnTrail);
    }

    void SpawnTrail(Bullet b)
    {
        var trail = (BulletTrail)pool.GetObject(trailPrefab);
        trail.BulletToTrack = b;
        trail.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletHitParticleController : MonoBehaviour
{
    [SerializeField]
    DisableAfterParticleFinished prefab = null;

    [SerializeField]
    List<Bullet> bulletPrefabs = new List<Bullet>();

    GamePool pool;

    public Vector3Event OnSpawnAtLocation = new Vector3Event();

    // Start is called before the first frame update
    void Start()
    {
        pool = GamePool.Instance;
        OnSpawnAtLocation.AddListener(SpawnParticle);
        Bullet.ParticleController = this;
    }

    void SpawnParticle(Vector3 pos)
    {
        //Debug.LogWarning("Spawning particle at location " + pos);
        var obj = (DisableAfterParticleFinished)pool.GetObject(prefab);
        obj.transform.position = pos;
        obj.gameObject.SetActive(true);
    }
}

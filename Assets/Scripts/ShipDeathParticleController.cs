using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDeathParticleController : MonoBehaviour
{
    [SerializeField]
    DisableAfterParticleFinished shipDeathParticle = null;

    [SerializeField]
    DisableAfterParticleFinished playerDeathParticle = null;

    GamePool pool;

    public DeathEvent OnSpawnAtLocation = new DeathEvent();

    // Start is called before the first frame update
    void Start()
    {
        pool = GamePool.Instance;
        OnSpawnAtLocation.AddListener(SpawnParticle);
        Ship.ParticleController = this;
    }

    void SpawnParticle(Vector3 pos, Color color, bool isPlayer)
    {
        //Debug.Log("Before: " + color);
        //Debug.Log("After: " + color);
        //Debug.LogWarning("Spawning particle at location " + pos);
        var obj = (DisableAfterParticleFinished)pool.GetObject(isPlayer ? playerDeathParticle : shipDeathParticle);

        obj.transform.position = pos;
        obj.SetColor(color);
        obj.gameObject.SetActive(true);
    }
}

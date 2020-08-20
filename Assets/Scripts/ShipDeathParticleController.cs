using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDeathParticleController : MonoBehaviour
{
    [SerializeField]
    DisableAfterParticleFinished prefab = null;

    GamePool pool;

    public DeathEvent OnSpawnAtLocation = new DeathEvent();

    // Start is called before the first frame update
    void Start()
    {
        pool = GamePool.Instance;
        OnSpawnAtLocation.AddListener(SpawnParticle);
        ShipInfo.ParticleController = this;
    }

    void SpawnParticle(Vector3 pos, Color color, bool isShip)
    {
        Debug.Log("Before: " + color);
        color = isShip ? color : Color.white;
        Debug.Log("After: " + color);
        //Debug.LogWarning("Spawning particle at location " + pos);
        var obj = (DisableAfterParticleFinished)pool.GetObject(prefab);

        obj.transform.position = pos;
        obj.SetColor(color);
        obj.gameObject.SetActive(true);
    }
}

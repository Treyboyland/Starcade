using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : ShipInfo
{
    [SerializeField]
    Rigidbody2D rb = null;

    [SerializeField]
    Vector4 velocityRange = new Vector4();

    [SerializeField]
    int spawnCount = 0;

    [SerializeField]
    bool spawnMoreOnDeath = false;

    [SerializeField]
    List<MonoAndInt> asteroidSpawns = new List<MonoAndInt>();

    [SerializeField]
    Vector4 spawnOffset = new Vector4();

    Vector2 velocity;
    GamePool pool;

    private void OnEnable()
    {
        CurrentHealth = MaxHealth;
        pool = GamePool.Instance;
        rb.velocity = new Vector2(UnityEngine.Random.Range(velocityRange.x, velocityRange.y),
            UnityEngine.Random.Range(velocityRange.z, velocityRange.w));
    }

    void SpawnMoreAsteroids(int additionalDamage)
    {
        int damagePerSpawn = additionalDamage != 0 ? Mathf.Max(1, additionalDamage / spawnCount) : 0;
        if (spawnMoreOnDeath)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                var asteroid = (Asteroid)asteroidSpawns.GetRandomMonoBehaviour();
                var spawned = pool.GetObject(asteroid);
                Vector3 offset = new Vector3(UnityEngine.Random.Range(spawnOffset.x, spawnOffset.y),
                    UnityEngine.Random.Range(spawnOffset.z, spawnOffset.w), 0);
                spawned.transform.position = transform.position + offset;
                spawned.gameObject.SetActive(true);
                if (damagePerSpawn != 0)
                {
                    ((Asteroid)spawned).DamageShip(damagePerSpawn);
                }
            }
        }

    }

    public override void DamageShip(int amount)
    {
        int previousHealth = CurrentHealth;
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        if (hitEvent != null)
        {
            hitEvent.RaiseEvent();
        }
        if (CurrentHealth == 0)
        {
            int additionalDamage = amount - previousHealth;
            SpawnParticle();
            SpawnMoreAsteroids(additionalDamage);
            gameObject.SetActive(false);
        }
    }
}

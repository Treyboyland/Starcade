using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Ship
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

    const float SECONDS_TO_WAIT_BEFORE_ATTACK = 0.75f;

    bool canAttack = false;


    private void OnEnable()
    {
        canAttack = false;
        CurrentHealth = shipData.MaxHealth;
        pool = GamePool.Instance;
        rb.velocity = new Vector2(UnityEngine.Random.Range(velocityRange.x, velocityRange.y),
            UnityEngine.Random.Range(velocityRange.z, velocityRange.w));
        StartCoroutine(AttackDelay()); //I think this should be fine...runs once per asteroid per spawn
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(SECONDS_TO_WAIT_BEFORE_ATTACK);
        canAttack = true;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        //TODO: Only damage player, or all normal faction ships as well?
        if (!canAttack)
        {
            return;
        }

        var player = other.collider.gameObject.GetComponent<PlayerShip>();
        if (player != null)
        {
            //Hit player for damage and then die
            player.DamageShip(CurrentHealth);
            DamageShip(CurrentHealth);
        }
    }
}

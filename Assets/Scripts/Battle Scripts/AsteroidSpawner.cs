using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    List<MonoAndInt> asteroids = new List<MonoAndInt>();

    [SerializeField]
    Vector2Int spawnCount = new Vector2Int();

    [SerializeField]
    Vector2 spawnRangeSeconds = new Vector2();

    [SerializeField]
    Vector2 initialWaitRangeSeconds = new Vector2();

    [SerializeField]
    Vector2 quickSpawnRangeSeconds = new Vector2();

    [SerializeField]
    Vector2 xRange = new Vector2();

    GamePool pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = GamePool.Instance;
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnStuff());
    }

    void SpawnAsteriod()
    {
        var asteroid = (Asteroid)asteroids.GetRandomMonoBehaviour();
        var spawned = pool.GetObject(asteroid);

        spawned.transform.position = new Vector3(UnityEngine.Random.Range(xRange.x, xRange.y), transform.position.y, 0);
        spawned.gameObject.SetActive(true);
    }

    IEnumerator SpawnStuff()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(initialWaitRangeSeconds.x, initialWaitRangeSeconds.y));
        while (true)
        {
            int count = UnityEngine.Random.Range(spawnCount.x, spawnCount.y);
            for (int i = 0; i < count; i++)
            {
                SpawnAsteriod();
                yield return new WaitForSeconds(UnityEngine.Random.Range(quickSpawnRangeSeconds.x, quickSpawnRangeSeconds.y));
            }
            yield return new WaitForSeconds(Random.Range(spawnRangeSeconds.x, spawnRangeSeconds.y));
            yield return null;
        }
    }
}

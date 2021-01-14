using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    SpawnDataSO dataSO = null;

    [SerializeField]
    Vector4 spawnOffsets = new Vector4();

    [SerializeField]
    float initalTimeMultiplier = 0.5f;

    float time = 0;

    float newTime = 0;

    public bool CanSpawn { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        newTime = dataSO.SecondsToNextSpawn * initalTimeMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameConstants.CanEnemiesPassTime || !CanSpawn)
        {
            return;
        }

        time += Time.deltaTime;
        var spawns = dataSO.Spawn(transform, spawnOffsets, ref time, newTime, GamePool.Instance);
        if (spawns.Count != 0)
        {
            newTime = dataSO.SecondsToNextSpawn;
            Debug.LogWarning(gameObject.name + " spawned " + spawns.Count);
        }
    }
}

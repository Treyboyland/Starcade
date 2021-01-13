using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnDataSO : ScriptableObject
{
    public abstract float SecondsToNextSpawn { get; }

    public abstract List<MonoBehaviour> Spawn(Transform caller, Vector4 spawnOffset, ref float secondsElapsed, float secondsToNextSpawn, GamePool pool);
}


public class RandomSpawnDataSO<T> : SpawnDataSO where T : MonoBehaviour
{
    [Tooltip("Amount of time between spawns")]
    [SerializeField]
    Vector2 spawnRangeSeconds = new Vector2();

    [Tooltip("How many items may spawn")]
    [SerializeField]
    Vector2Int spawnCountRange = new Vector2Int();

    [Tooltip("Possible objects that may spawn")]
    [SerializeField]
    List<T> objectsToSpawn = new List<T>();

    public override float SecondsToNextSpawn { get { return Random.Range(spawnRangeSeconds.x, spawnRangeSeconds.y); } }

    public override List<MonoBehaviour> Spawn(Transform caller, Vector4 spawnOffset, ref float secondsElapsed, float secondsToNextSpawn, GamePool pool)
    {
        if (objectsToSpawn.Count == 0)
        {
            Debug.LogWarning("Spawner " + name + " has no possible spawn objects");
            return new List<MonoBehaviour>();
        }

        List<MonoBehaviour> toReturn = new List<MonoBehaviour>();

        if (secondsElapsed >= secondsToNextSpawn)
        {
            secondsElapsed = 0;
            int spawnCount = Random.Range(spawnCountRange.x, spawnCountRange.y);
            int selectedIndex = Random.Range(0, objectsToSpawn.Count);
            for (int i = 0; i < spawnCount; i++)
            {
                var x = Random.Range(spawnOffset.x, spawnOffset.y);
                var y = Random.Range(spawnOffset.z, spawnOffset.w);
                Vector3 offset = new Vector3(x, y);
                var newObject = pool.GetObject(objectsToSpawn[selectedIndex]);
                newObject.transform.position = caller.position + offset;
                newObject.gameObject.SetActive(true);

                toReturn.Add(newObject);
            }
        }

        return toReturn;
    }
}





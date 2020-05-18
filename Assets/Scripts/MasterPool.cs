using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    List<T> objectPrefabs = null;

    [SerializeField]
    int initialSize = 0;

    Dictionary<T, List<T>> pools = new Dictionary<T, List<T>>();

    public MonobehaviourEvent OnObjectCreated = new MonobehaviourEvent();

    public virtual void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        foreach (var obj in objectPrefabs)
        {
            for (int i = 0; i < initialSize; i++)
            {
                InstantiateObject(obj);
            }
        }

    }

    T InstantiateObject(T obj)
    {
        T toReturn = Instantiate(obj);
        toReturn.gameObject.SetActive(false);
        if (!pools.ContainsKey(obj))
        {
            pools.Add(obj, new List<T>());
        }
        pools[obj].Add(toReturn);
        OnObjectCreated.Invoke(obj);
        return toReturn;
    }

    public T GetObject(T obj)
    {
        if (!pools.ContainsKey(obj))
        {
            return InstantiateObject(obj);
        }
        foreach (var prefab in pools[obj])
        {
            if (!prefab.gameObject.activeInHierarchy)
            {
                return prefab;
            }
        }

        return InstantiateObject(obj);
    }

    public List<T> GetInitialized(T obj)
    {
        if(pools.ContainsKey(obj))
        {
            return pools[obj];
        }
        return new List<T>();
    }
}

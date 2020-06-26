using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerData))]
public class PlayerDataSingleton : MonoBehaviour
{
    static PlayerDataSingleton _instance;
    public static PlayerDataSingleton Instance
    {
        get
        {
            return _instance;
        }
    }

    PlayerData data;

    public PlayerData Data
    {
        get
        {
            return data;
        }
    }    

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        data = GetComponent<PlayerData>();
    }
}

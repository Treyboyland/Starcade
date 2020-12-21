using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Button))]
public class SaveButtonTest : MonoBehaviour
{
    [SerializeField]
    PlayerDataSO playerData;

    Button button;

    [Serializable]
    public class StringEvent : UnityEvent<string>{ }

    public StringEvent OnGameSaved = new StringEvent();

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SaveGame);
    }

    void SaveGame()
    {
        SaveUtility.SaveGame(playerData);
        OnGameSaved.Invoke(SaveUtility.Error);
    }
}

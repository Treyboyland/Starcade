using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    List<PlayerDataSO> playerSaves = new List<PlayerDataSO>();

    [SerializeField]
    List<SaveDataButtonUI> saveDataButtons = null;

    int maxPages = 1;

    int currentPage = 0;

    public void NextPage()
    {
        currentPage = (currentPage + 1) % maxPages;
        SetCurrentPageData();
    }

    public void PreviousPage()
    {
        currentPage--;
        if (currentPage < 0)
        {
            currentPage = maxPages - 1;
        }
        SetCurrentPageData();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Left"))
        {
            PreviousPage();
        }
        else if (Input.GetButtonDown("Right"))
        {
            NextPage();
        }
    }

    void SetCurrentPageData()
    {
        for (int i = 0; i < saveDataButtons.Count; i++)
        {
            int index = saveDataButtons.Count * currentPage + i;
            var data = index < playerSaves.Count ? playerSaves[index] : null;
            saveDataButtons[i].SetPlayerData(data);
        }
    }

    public void LoadSaves()
    {
        List<PlayerDataSO> saves;
        if (SaveUtility.LoadSaves(out saves))
        {
            maxPages = saves.Count / saveDataButtons.Count + (saves.Count % saveDataButtons.Count != 0 ? 1 : 0);
            if (maxPages == 0)
            {
                maxPages = 1;
            }
            currentPage = 0;
            playerSaves = saves;
            Debug.LogWarning("Save Count: " + playerSaves.Count);
            SetCurrentPageData();
        }
        else
        {
            Debug.LogError(SaveUtility.Error);
        }
    }
}

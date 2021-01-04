using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class SaveUtility
{
    static string PlayerSaveLocation = Application.dataPath + "/../Saves";

    const string SAVE_EXTENSION = ".save";

    public static string Error = "";

    /// <summary>
    /// Saves new game data
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public static bool SaveGameNew(PlayerDataSO player)
    {
        try
        {
            if (!Directory.Exists(PlayerSaveLocation))
            {
                Directory.CreateDirectory(PlayerSaveLocation);
            }
        }
        catch
        {
            Error = "Unable to find save path \"" + PlayerSaveLocation + "\"";
            return false;
        }

        try
        {
            string savePath = PlayerSaveLocation + "/" + DateTime.Now.ToString("yyyy-mm-dd_hh-mm-ss-ffff") + SAVE_EXTENSION;
            if (File.Exists(savePath))
            {
                throw new ArgumentException("Path \"" + savePath + "\" already exists. Please try again.");
            }
            player.LastSaveTime = DateTime.Now;
            var data = JsonUtility.ToJson(player);
            File.WriteAllText(savePath, data);
        }
        catch (Exception e)
        {
            Error = "Unable to write save data to file:\r\n" + e;
            return false;
        }

        Error = "Save successful";
        return true;
    }

    public static bool LoadSaves(out List<PlayerDataSO> saveData)
    {
        try
        {
            if (!Directory.Exists(PlayerSaveLocation))
            {
                Directory.CreateDirectory(PlayerSaveLocation);
                saveData = new List<PlayerDataSO>();
                return true;
            }
        }
        catch
        {
            Error = "Unable to Create Directory at location \"" + PlayerSaveLocation + "\"";
            saveData = new List<PlayerDataSO>();
            return false;
        }

        int unableToBeReadCount = 0;
        int fileCount = 0;

        saveData = new List<PlayerDataSO>();

        foreach (var file in Directory.GetFiles(PlayerSaveLocation, "*" + SAVE_EXTENSION))
        {
            try
            {
                fileCount++;
                string fileData = File.ReadAllText(file);
                Debug.LogWarning("File Data: " + fileData);
                PlayerDataSO data = new PlayerDataSO();
                JsonUtility.FromJsonOverwrite(fileData, data);
                saveData.Add(data);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                unableToBeReadCount++;
                continue;
            }


        }
        Debug.LogWarning("File Count: " + fileCount);

        Error = unableToBeReadCount == 0 ? "Load Successful" : unableToBeReadCount + " files were not able to be loaded";
        Debug.LogWarning(Error);
        return true;
    }

}

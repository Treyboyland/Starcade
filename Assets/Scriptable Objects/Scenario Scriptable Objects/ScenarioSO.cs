using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scenario", menuName = "ScriptableObjects/Scenario", order = 2)]
public class ScenarioSO : ScriptableObject
{
    /// <summary>
    /// Identifier for this scenario
    /// </summary>
    [Tooltip("Identifier for this scenario")]
    public int Id;

    /// <summary>
    /// Flavor text for player on successful completion 
    /// </summary>
    [Tooltip("Flavor text for player on successful completion")]
    [TextArea]
    public string DescriptiveTextSuccess;

    /// <summary>
    /// Flavor text for player on failure
    /// </summary>
    [Tooltip("Flavor text for player on failure")]
    [TextArea]
    public string DescriptiveTextFailure;

    /// <summary>
    /// Text to display for this button if active
    /// </summary>
    [Tooltip("Text to display for this button if active")]
    public string ButtonTextActive;

    /// <summary>
    /// Text to display for this button if inactive
    /// </summary>
    [Tooltip("Text to display for this button if inactive")]
    public string ButtonTextDisabled;

    /// <summary>
    /// Show an option for this scenario, even if the player doesn't meet the
    /// prerequisites
    /// </summary>
    [Tooltip("Show an option for this scenario, even if the player doesn't meet the prerequisites")]
    public bool ShowIfUnableToUse;

    /// <summary>
    /// Checks that the player must pass in order to select this scenario
    /// </summary>
    [Tooltip("Checks that the player must pass in order to select this scenario")]
    public List<AbilityCheckSO> Prerequisites;

    /// <summary>
    /// Checks that the game should run in order to determine if the scenario has succeeded or failed
    /// </summary>
    [Tooltip("Checks that the game should run in order to determine if the scenario has succeeded or failed")]
    public List<AbilityCheckSO> ChecksOnSelection;

    /// <summary>
    /// Scenarios that should be shown on successfully passing this scenario
    /// </summary>
    [Tooltip("Scenarios that should be shown on successfully passing this scenario")]
    public List<ScenarioSO> ActionsSuccess;

    /// <summary>
    /// Scenarios that should be shown on failure of this scenario
    /// </summary>
    [Tooltip("Scenarios that should be shown on failure of this scenario")]
    public List<ScenarioSO> ActionsFailure;

    /// <summary>
    /// Returns true if the player can select this scenario
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public bool CanChoose(PlayerDataSO player)
    {
        foreach (var prerequisite in Prerequisites)
        {
            if (!prerequisite.CheckAbility(player))
            {
                return false;
            }
        }
        return true;
    }

    public bool SelectAction(PlayerDataSO player)
    {
        foreach (var check in ChecksOnSelection)
        {
            if (!check.CheckAbility(player))
            {
                return false;
            }
        }

        return true;
    }
}

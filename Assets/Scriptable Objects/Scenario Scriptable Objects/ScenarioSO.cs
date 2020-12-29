using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains various properties that scenarios use
/// </summary>
public abstract class ScenarioSO : ScriptableObject
{
    /// <summary>
    /// Identifier for this scenario
    /// </summary>
    [Tooltip("Identifier for this scenario")]
    [SerializeField]
    int id = 0;

    /// <summary>
    /// Identifier for this scenario
    /// </summary>
    public virtual int Id { get { return id; } }

    /// <summary>
    /// Show an option for this scenario, even if the player doesn't meet the
    /// prerequisites
    /// </summary>
    [Tooltip("Show an option for this scenario, even if the player doesn't meet the prerequisites")]
    [SerializeField]
    bool showIfUnableToUse = false;

    /// <summary>
    /// Show an option for this scenario, even if the player doesn't meet the
    /// prerequisites
    /// </summary>
    public virtual bool ShowIfUnableToUse
    {
        get
        {
            return showIfUnableToUse;
        }
    }


    /// <summary>
    /// Checks that the player must pass in order to select this scenario
    /// </summary>
    [Tooltip("Checks that the player must pass in order to select this scenario")]
    [SerializeField]
    List<AbilityCheckSO> prerequisites = new List<AbilityCheckSO>();

    /// <summary>
    /// Checks that the player must pass in order to select this scenario
    /// </summary>
    public virtual List<AbilityCheckSO> Prerequisites
    {
        get
        {
            return prerequisites;
        }
    }

    /// <summary>
    /// Text to display for this button if active
    /// </summary>
    [Tooltip("Text to display for this button if active")]
    [SerializeField]
    string buttonTextActive = "";

    /// <summary>
    /// Text to display for this button if active
    /// </summary>
    public virtual string ButtonTextActive
    {
        get
        {
            return buttonTextActive;
        }
    }


    /// <summary>
    /// Text to display for this button if inactive
    /// </summary>
    [Tooltip("Text to display for this button if inactive")]
    [SerializeField]
    string buttonTextDisabled = "";

    /// <summary>
    /// Text to display for this button if inactive
    /// </summary>
    public string ButtonTextDisabled
    {
        get
        {
            return buttonTextDisabled;
        }
    }

    /// <summary>
    /// Flavor text for player on successful completion 
    /// </summary>
    public virtual string DescriptiveTextSuccess { get; }

    /// <summary>
    /// Flavor text for player on failure
    /// </summary>
    public virtual string DescriptiveTextFailure { get; }

    /// <summary>
    /// Checks that the game should run in order to determine if the scenario has succeeded or failed
    /// </summary>
    public virtual List<AbilityCheckSO> ChecksOnSelection { get; }

    /// <summary>
    /// Things that should happen to the player if they pass the scenario
    /// </summary>
    /// <value></value>
    public virtual List<PlayerEventSO> PlayerEventsSuccess { get; }

    /// <summary>
    /// Things that should happen to the player if they fail the scenario
    /// </summary>
    /// <value></value>
    public virtual List<PlayerEventSO> PlayerEventsFailure { get; }

    /// <summary>
    /// Scenarios that should be shown on successfully passing this scenario
    /// </summary>
    public virtual List<ScenarioSO> ActionsSuccess { get; }

    /// <summary>
    /// Scenarios that should be shown on failure of this scenario
    /// </summary>
    public virtual List<ScenarioSO> ActionsFailure { get; }



    /// <summary>
    /// Returns true if the player can select this scenario
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public virtual bool CanChoose(PlayerDataSO player)
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

    /// <summary>
    /// Selects this Scenario/Action. Returns true if the player 
    /// passed all checks (if any), false otherwise
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public virtual bool SelectAction(PlayerDataSO player)
    {
        bool success = true;
        foreach (var check in ChecksOnSelection)
        {
            if (!check.CheckAbility(player))
            {
                success = false;
                break;
            }
        }

        var playerEvents = success ? PlayerEventsSuccess : PlayerEventsFailure;

        foreach (var playerEvent in playerEvents)
        {
            playerEvent.DoActionOnPlayer(player);
        }

        return success;
    }
}

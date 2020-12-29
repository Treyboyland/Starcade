using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalScenario", menuName = "Scenarios/Normal Scenario", order = -1)]
public class NormalScenarioSO : ScenarioSO
{

    /// <summary>
    /// Flavor text for player on successful completion 
    /// </summary>
    [TextArea]
    [Tooltip("Flavor text for player on successful completion")]
    [SerializeField]
    string descriptiveTextSuccess = "";

    /// <summary>
    /// Flavor text for player on successful completion 
    /// </summary>
    public override string DescriptiveTextSuccess
    {
        get
        {
            return descriptiveTextSuccess;
        }
    }

    /// <summary>
    /// Flavor text for player on failure
    /// </summary>
    [Tooltip("Flavor text for player on failure")]
    [TextArea]
    [SerializeField]
    string descriptiveTextFailure = "";

    /// <summary>
    /// Flavor text for player on failure
    /// </summary>
    public override string DescriptiveTextFailure
    {
        get
        {
            return descriptiveTextFailure;
        }
    }

    /// <summary>
    /// Checks that the game should run in order to determine if the scenario has succeeded or failed
    /// </summary>
    [Tooltip("Checks that the game should run in order to determine if the scenario has succeeded or failed")]
    [SerializeField]
    List<AbilityCheckSO> checksOnSelection = new List<AbilityCheckSO>();

    /// <summary>
    /// Checks that the game should run in order to determine if the scenario has succeeded or failed
    /// </summary>
    public override List<AbilityCheckSO> ChecksOnSelection
    {
        get
        {
            return checksOnSelection;
        }
    }

    /// <summary>
    /// Things that should happen to the player if they pass the scenario
    /// </summary>
    [Tooltip("Things that should happen to the player if they pass the scenario")]
    [SerializeField]
    List<PlayerEventSO> playerEventsSuccess = new List<PlayerEventSO>();

    /// <summary>
    /// Things that should happen to the player if they pass the scenario
    /// </summary>
    /// <value></value>
    public override List<PlayerEventSO> PlayerEventsSuccess
    {
        get
        {
            return playerEventsSuccess;
        }
    }

    /// <summary>
    /// Things that should happen to the player if they fail the scenario
    /// </summary>
    [Tooltip("Things that should happen to the player if they fail the scenario")]
    [SerializeField]
    List<PlayerEventSO> playerEventsFailure = new List<PlayerEventSO>();

    /// <summary>
    /// Things that should happen to the player if they fail the scenario
    /// </summary>
    /// <value></value>
    public override List<PlayerEventSO> PlayerEventsFailure
    {
        get
        {
            return playerEventsFailure;
        }
    }

    /// <summary>
    /// Scenarios that should be shown on successfully passing this scenario
    /// </summary>
    [Tooltip("Scenarios that should be shown on successfully passing this scenario")]
    [SerializeField]
    List<ScenarioSO> actionsSuccess = new List<ScenarioSO>();

    /// <summary>
    /// Scenarios that should be shown on successfully passing this scenario
    /// </summary>
    public override List<ScenarioSO> ActionsSuccess
    {
        get
        {
            return actionsSuccess;
        }
    }

    /// <summary>
    /// Scenarios that should be shown on failure of this scenario
    /// </summary>
    [Tooltip("Scenarios that should be shown on failure of this scenario")]
    [SerializeField]
    List<ScenarioSO> actionsFailure = new List<ScenarioSO>();

    /// <summary>
    /// Scenarios that should be shown on failure of this scenario
    /// </summary>
    public override List<ScenarioSO> ActionsFailure
    {
        get
        {
            return actionsFailure;
        }
    }
}

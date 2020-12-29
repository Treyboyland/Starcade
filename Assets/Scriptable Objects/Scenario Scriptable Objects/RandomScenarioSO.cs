using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomScenario", menuName = "Scenarios/Random Scenario", order = -1)]
public class RandomScenarioSO : ScenarioSO
{
    public List<ScenarioSO> ScenariosToSelectFrom;

    public override string DescriptiveTextFailure
    {
        get
        {
            return ScenariosToSelectFrom[selectedIndex].DescriptiveTextFailure;
        }
    }

    public override string DescriptiveTextSuccess
    {
        get
        {
            return ScenariosToSelectFrom[selectedIndex].DescriptiveTextSuccess;
        }
    }

    public override List<AbilityCheckSO> ChecksOnSelection
    {
        get
        {
            return ScenariosToSelectFrom[selectedIndex].ChecksOnSelection;
        }
    }

    public override List<ScenarioSO> ActionsSuccess
    {
        get
        {
            return ScenariosToSelectFrom[selectedIndex].ActionsSuccess;
        }
    }

    public override List<ScenarioSO> ActionsFailure
    {
        get
        {
            return ScenariosToSelectFrom[selectedIndex].ActionsFailure;
        }
    }

    int selectedIndex = 0;

    public override bool SelectAction(PlayerDataSO player)
    {
        selectedIndex = Random.Range(0, ScenariosToSelectFrom.Count);
        return ScenariosToSelectFrom[selectedIndex].SelectAction(player);
    }
}

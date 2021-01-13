using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{

    [SerializeField]
    List<ScenarioSO> randomScenarios = null;

    [SerializeField]
    float scenarioProbability = 0.5f;

    [SerializeField]
    int guaranteedScenarioEveryX = 5;

    [SerializeField]
    PlayerDataSO playerData = null;

    [SerializeField]
    GameEvent scenarioStartEvent = null;

    [SerializeField]
    GameObject scenarioNotification = null;

    [SerializeField]
    ScenarioSOHandler scenarioHandler = null;

    ScenarioSO currentScenario;

    // Start is called before the first frame update
    void Start()
    {
        if (ShouldDoScenario())
        {
            SelectScenario();
        }
    }

    bool ShouldDoScenario()
    {
        return playerData.TotalCycles % guaranteedScenarioEveryX == 0 || Random.Range(0.0f, 1.0f) < scenarioProbability;
    }

    void SelectScenario()
    {
        //More complex logic could go here...
        int index = Random.Range(0, randomScenarios.Count);
        currentScenario = randomScenarios[index];
        scenarioStartEvent.RaiseEvent();
        StartCoroutine(WaitThenStart());
    }

    IEnumerator WaitThenStart()
    {
        while (scenarioNotification.activeInHierarchy)
        {
            yield return null;
        }

        scenarioHandler.OnNewScenario.Invoke(currentScenario);
    }

}

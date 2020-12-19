using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSOTest : MonoBehaviour
{
    [SerializeField]
    ScenarioSOHandler handler = null;

    [SerializeField]
    List<ScenarioSO> scenarios = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestScenario());
    }

    IEnumerator TestScenario()
    {
        yield return new WaitForSeconds(3.0f);
        var index = UnityEngine.Random.Range(0, scenarios.Count);
        handler.OnNewScenario.Invoke(scenarios[index]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioTest : MonoBehaviour
{
    [SerializeField]
    ScenarioHandler handler = null;

    [SerializeField]
    SampleScenarios scenarios = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestScenario());
    }

    IEnumerator TestScenario()
    {
        yield return new WaitForSeconds(3.0f);
        var index = UnityEngine.Random.Range(0, scenarios.scenarios.Count);
        handler.OnNewScenario.Invoke(scenarios.scenarios[index]);
    }
}

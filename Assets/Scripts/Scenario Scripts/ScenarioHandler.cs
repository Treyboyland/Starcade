using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScenarioHandler : MonoBehaviour
{
    [SerializeField]
    List<ScenarioButtonController> buttonControllers = new List<ScenarioButtonController>();

    ScenarioEvent OnNewScenario = new ScenarioEvent();

    IntEvent OnScenarioSelected = new IntEvent();

    private void Awake()
    {
        OnNewScenario.AddListener(StartScenario);    
    }

    void StartScenario(Scenario scenario)
    {
        for(int i = 0; i < buttonControllers.Count; i++)
        {
            bool chosen = i == scenario.Actions.Count;
            buttonControllers[i].gameObject.SetActive(chosen);
            buttonControllers[i].GetComponent<SelectOnButtonPressed>().ShouldRunCheck = chosen;
            if(chosen)
            {
                for(int k = 0; k < buttonControllers[i].Buttons.Length; k ++)
                {
                    var button = buttonControllers[i].Buttons[k];
                    button.OnActionChosen.AddListener((num) => OnScenarioSelected.Invoke(num));
                    button.Description = scenario.Actions[k];
                }
            }
        }
    }
}

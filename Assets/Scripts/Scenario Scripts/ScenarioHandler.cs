using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScenarioHandler : MonoBehaviour
{
    [SerializeField]
    TypeTextReveal scenarioText = null;

    [SerializeField]
    List<ScenarioButtonController> buttonControllers = new List<ScenarioButtonController>();

    public ScenarioEvent OnNewScenario = new ScenarioEvent();

    public IntEvent OnScenarioSelected = new IntEvent();

    ScenarioButtonController scenarioLayout = null;

    private void Awake()
    {
        OnNewScenario.AddListener(StartScenario);
        HideAll();
    }

    void HideAll()
    {
        foreach (var controller in buttonControllers)
        {
            controller.gameObject.SetActive(false);
        }
        scenarioText.Hide();
    }

    void RevealButtons()
    {
        scenarioText.OnRevealComplete.RemoveListener(RevealButtons);
        scenarioLayout.gameObject.SetActive(true);
        scenarioLayout.GetComponentInChildren<SelectOnButtonPressed>().SelectDefaultObject();
    }

    void StartScenario(Scenario scenario)
    {
        scenarioText.Text = scenario.Description;


        for (int i = 0; i < buttonControllers.Count; i++)
        {
            bool chosen = i == scenario.Actions.Count;
            buttonControllers[i].gameObject.SetActive(chosen);
            buttonControllers[i].GetComponent<SelectOnButtonPressed>().ShouldRunCheck = chosen;
            if (chosen)
            {
                scenarioLayout = buttonControllers[i];
                for (int k = 0; k < buttonControllers[i].Buttons.Length; k++)
                {
                    var button = buttonControllers[i].Buttons[k];
                    button.OnActionChosen.AddListener((num) => OnScenarioSelected.Invoke(num));
                    button.Description = scenario.Actions[k];
                }
                scenarioLayout.gameObject.SetActive(false);
            }
        }

        scenarioText.OnRevealComplete.AddListener(RevealButtons);
        scenarioText.StartReveal();
    }
}

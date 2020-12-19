using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScenarioSOHandler : MonoBehaviour
{
    [SerializeField]
    TypeTextReveal scenarioText = null;

    [SerializeField]
    List<ScenarioButtonController> buttonControllers = new List<ScenarioButtonController>();

    public ScenarioSOEvent OnNewScenario = new ScenarioSOEvent();

    public IntEvent OnScenarioSelected = new IntEvent();

    public EmptyEvent OnScenarioComplete = new EmptyEvent();

    ScenarioButtonController scenarioLayout = null;

    ScenarioSO currentScenario;

    private void Start()
    {
        OnNewScenario.AddListener(StartScenario);
        OnScenarioSelected.AddListener(ContinueScenario);
        OnScenarioComplete.AddListener(HideAll);
        HideAll();
    }

    void ContinueScenario(int selected)
    {
        Debug.LogWarning("Selected item: " + selected + " on scenario " + currentScenario.ToString());
        if (currentScenario.ActionsSuccess.Count != 0)
        {
            RemoveButtonListeners();
            StartScenario(currentScenario.ActionsSuccess[selected]);
        }
        else
        {
            OnScenarioComplete.Invoke();
        }
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

    void InvokeScenarioSelectedEvent(int num)
    {
        OnScenarioSelected.Invoke(num);
    }

    void RemoveButtonListeners()
    {
        foreach (var button in scenarioLayout.Buttons)
        {
            button.OnActionChosen.RemoveListener(InvokeScenarioSelectedEvent);
        }
    }

    void StartScenario(ScenarioSO scenario)
    {
        currentScenario = scenario;
        scenarioText.Text = scenario.DescriptiveTextSuccess;


        for (int i = 0; i < buttonControllers.Count; i++)
        {
            bool chosen = i == scenario.ActionsSuccess.Count;
            if (chosen)
            {
                Debug.LogWarning("Chosen: " + i);
            }
            buttonControllers[i].gameObject.SetActive(chosen);
            buttonControllers[i].GetComponent<SelectOnButtonPressed>().ShouldRunCheck = chosen;
            if (chosen)
            {
                scenarioLayout = buttonControllers[i];
                for (int k = 0; k < buttonControllers[i].Buttons.Length; k++)
                {
                    var button = buttonControllers[i].Buttons[k];
                    button.Id = k;
                    button.OnActionChosen.AddListener(InvokeScenarioSelectedEvent);
                    button.Description = scenario.ActionsSuccess.Count != 0 ? scenario.ActionsSuccess[k].ButtonTextActive : "END";
                }
                scenarioLayout.gameObject.SetActive(false);
            }
        }

        scenarioText.OnRevealComplete.AddListener(RevealButtons);
        scenarioText.StartReveal();
    }
}

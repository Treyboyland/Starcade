using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScenarioSOHandler : MonoBehaviour
{
    [SerializeField]
    PlayerDataSO player = null;

    [SerializeField]
    TypeTextReveal scenarioText = null;

    [SerializeField]
    List<ScenarioButtonController> buttonControllers = new List<ScenarioButtonController>();

    public ScenarioSOEvent OnNewScenario = new ScenarioSOEvent();

    public IntEvent OnScenarioSelected = new IntEvent();

    public EmptyEvent OnScenarioComplete = new EmptyEvent();

    ScenarioButtonController scenarioLayout = null;

    ScenarioSO currentScenario;

    /// <summary>
    /// True if currently highlighting selection
    /// </summary>
    bool highlighting = false;

    bool passedScenario = true;

    private void Start()
    {
        OnNewScenario.AddListener(StartScenario);
        OnScenarioSelected.AddListener(ContinueScenario);
        OnScenarioComplete.AddListener(HideAll);
        HideAll();
    }

    void ContinueScenario(int selected)
    {
        if (!highlighting)
        {
            Debug.LogWarning("Selected item: " + selected + " on scenario " + currentScenario.ToString());
            if (currentScenario.ActionsSuccess.Count != 0)
            {
                RemoveButtonListeners();
                StartCoroutine(HighlightSelectedThenUpdateScenario(selected));
            }
            else
            {
                OnScenarioComplete.Invoke();
            }
        }

    }

    IEnumerator HighlightSelectedThenUpdateScenario(int selected)
    {
        highlighting = true;
        scenarioLayout.HideAllButtonsExcept(selected);
        yield return new WaitForSeconds(1.5f);
        StartScenario(passedScenario ? currentScenario.ActionsSuccess[selected] : currentScenario.ActionsFailure[selected]);
        highlighting = false;
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
        passedScenario = currentScenario.SelectAction(player);
        scenarioText.Text = passedScenario ? scenario.DescriptiveTextSuccess : scenario.DescriptiveTextFailure;
        var actions = passedScenario ? scenario.ActionsSuccess : scenario.ActionsFailure;

        for (int i = 0; i < buttonControllers.Count; i++)
        {
            bool chosen = i == actions.Count;
            if (chosen)
            {
                Debug.LogWarning("Chosen: " + i);
            }
            buttonControllers[i].gameObject.SetActive(chosen);
            buttonControllers[i].GetComponent<SelectOnButtonPressed>().ShouldRunCheck = chosen;
            if (chosen)
            {
                scenarioLayout = buttonControllers[i];
                scenarioLayout.ActivateButtons();
                for (int k = 0; k < buttonControllers[i].Buttons.Length; k++)
                {
                    var button = buttonControllers[i].Buttons[k];
                    button.Id = k;
                    button.OnActionChosen.AddListener(InvokeScenarioSelectedEvent);
                    button.Description = actions.Count != 0 ? actions[k].ButtonTextActive : "END";
                }
                scenarioLayout.gameObject.SetActive(false);
            }
        }

        scenarioText.OnRevealComplete.AddListener(RevealButtons);
        scenarioText.StartReveal();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TypeTextReveal : MonoBehaviour
{
    [SerializeField]
    float secondsBetweenReveals = 0;

    TextMeshProUGUI textBox;

    public EmptyEvent OnRevealComplete = new EmptyEvent();

    public string Text
    {
        get
        {
            return textBox.text;
        }
        set
        {
            textBox.text = value;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        Hide();
    }

    public void Hide()
    {
        textBox.maxVisibleCharacters = 0;
    }


    public void StartReveal()
    {
        StartCoroutine(RevealText());
    }

    IEnumerator RevealText()
    {
        int start = textBox.text.Length;
        
        for(int i = 0; i < start; i++)
        {
            textBox.maxVisibleCharacters = i;
            if(i < textBox.text.Length && textBox.text[i] == ' ')
            {
                continue;
            }
            yield return new WaitForSeconds(secondsBetweenReveals);
        }

        textBox.maxVisibleCharacters = start;

        OnRevealComplete.Invoke();
    }
}

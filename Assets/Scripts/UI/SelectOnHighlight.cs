using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectOnHighlight : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    Selectable button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData data)
    {
        button.Select();
    }
}

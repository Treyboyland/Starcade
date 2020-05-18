using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerAction : MonoBehaviour
{
    public UnityEvent OnCompleteAction = new UnityEvent();
    public UnityEvent OnActionCompleted = new UnityEvent();
}

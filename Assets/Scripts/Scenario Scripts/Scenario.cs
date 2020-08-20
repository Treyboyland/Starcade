using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Scenario
{
    public string Description;

    public int Id;

    public List<string> Actions;
}

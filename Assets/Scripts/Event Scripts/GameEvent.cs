﻿/// Shamelessly copied from the Unite Austin 2017 Talk https://youtu.be/raQ3iHhE_Kk?t=2031
/// Full Code for that project can be found here: https://github.com/roboryantron/Unite2017
/// License for this file is as follows 
/* MIT License

Copyright (c) 2018 Ryan Hipple

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

//Minor changes to names have been made, as well as additional comments

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An event that can be fired from anywhere
/// </summary>
[CreateAssetMenu(fileName = "GameEvent", order = -2)]
public class GameEvent : ScriptableObject
{
    /// <summary>
    /// All listeners to this event
    /// </summary>
    /// <typeparam name="GameEventListener"></typeparam>
    /// <returns></returns>
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void RaiseEvent()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}

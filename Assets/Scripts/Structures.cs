using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct MonoAndInt
{
    public MonoBehaviour Mono;
    public int Count;
}


public static class ListExtensions
{
    public static int GetSum(this List<MonoAndInt> list)
    {
        int count = 0;
        foreach (var item in list)
        {
            count += item.Count;
        }

        return count;
    }

    public static MonoBehaviour GetRandomMonoBehaviour(this List<MonoAndInt> list)
    {
        int count = 0;
        int max = list.GetSum();
        int target = UnityEngine.Random.Range(0, max + 1);

        foreach (var item in list)
        {
            count += item.Count;
            if (count >= target)
            {
                return item.Mono;
            }
        }

        return list.Count > 0 ? list[0].Mono : null;
    }
}
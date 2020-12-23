using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum ComparisonTypes
{
    GREATER_THAN,
    LESS_THAN,
    EQUALS,
    GREATER_THAN_OR_EQUALS,
    LESS_THAN_OR_EQUALS,
    NOT_EQUAL
}


public static class Comparator
{
    public static bool Compare<T>(ComparisonTypes comparison, T a, T b) where T : IComparable
    {
        var comparisonValue = a.CompareTo(b);
        switch (comparison)
        {
            case ComparisonTypes.GREATER_THAN:
                return comparisonValue > 1;
            case ComparisonTypes.LESS_THAN:
                return comparisonValue < 1;
            case ComparisonTypes.EQUALS:
                return comparisonValue == 0;
            case ComparisonTypes.GREATER_THAN_OR_EQUALS:
                return comparisonValue >= 0;
            case ComparisonTypes.LESS_THAN_OR_EQUALS:
                return comparisonValue <= 0;
            case ComparisonTypes.NOT_EQUAL:
                return comparisonValue != 0;
            default:
                return false;
        }
    }
}
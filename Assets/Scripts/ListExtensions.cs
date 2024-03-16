using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static T LastElement<T>(this List<T> list) where T : class
    {
        if (list.Count > 0)
        {
            return list[list.Count - 1];
        }
        return null;
    }

    public static T RandomElement<T>(this List<T> list)
    {
        return list[list.RandomIndex()];
    }

    public static int RandomIndex<T>(this List<T> list)
    {
        return Random.Range(0, list.Count);
    }

    public static bool Equals<T>(this List<T> list, List<T> other)
    {
        if (list.Count != other.Count)
        {
            return false;
        }
        foreach (T item in list)
        {
            bool found = false;
            foreach (T otherItem in other)
            {
                if (item.Equals(otherItem))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                return false;
            }
        }
        return true;
    }   
}

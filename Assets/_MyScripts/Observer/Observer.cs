using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    static Dictionary<Enum, List<Action<object[]>>> Listeners = new Dictionary<Enum, List<Action<object[]>>>();
    public static void AddObserver(Enum enumType, Action<object[]> callback)
    {
        if (!Listeners.ContainsKey(enumType))
        {
            Listeners.Add(enumType, new List<Action<object[]>>());
        }
        Listeners[enumType].Add(callback);
    }
    public static void RemoveObserver(Enum enumType, Action<object[]> callback)
    {
        if (Listeners.ContainsKey(enumType)) return;
        Listeners[enumType].Remove(callback);
    }
    public static void Notify(Enum enumType, params object[] datas)
    {
        if (!Listeners.ContainsKey(enumType)) return;
        foreach (var action in Listeners[enumType])
        {
            try
            {
                action?.Invoke(datas);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error on invoke for {enumType}: {e}");
            }
        }
    }
}

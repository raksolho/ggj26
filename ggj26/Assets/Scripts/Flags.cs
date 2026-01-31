using System;
using System.Collections.Generic;
using UnityEngine;

public class Flags : MonoBehaviour
{

    static List<string> flags = new List<string>();
    public delegate void FlagChangeDelegate(List<string> flags);
    public static event FlagChangeDelegate OnFlagChange;
	public static void SetFlag(string flag)
    {
        if (!flags.Contains(flag))
        {
            flags.Add(flag);
            OnFlagChange?.Invoke(flags);
        }
    }

    public static void UnsetFlag(string flag)
    {
        if (flags.Contains(flag))
        {
            flags.Remove(flag);
            OnFlagChange?.Invoke(flags);
        }
    }

    public static bool CheckFlag(string flag)
    {
        return flags.Contains(flag);
    }
}

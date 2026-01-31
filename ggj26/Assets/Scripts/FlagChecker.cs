using System.Collections.Generic;
using UnityEngine;

public class FlagChecker : MonoBehaviour
{
    public List<string> requiredFlags;
    public List<string> forbiddenFlags;
    public GameObject targetObject;

    public void SetFlags(string flag)
    {
        Flags.SetFlag(flag);
    }
    public void UnsetFlags(string flag)
    {
        Flags.UnsetFlag(flag);
    }

    void OnEnable()
    {
        Flags.OnFlagChange += HandleFlagChange;
        HandleFlagChange(Flags.flags);
    }
    void OnDisable()
    {
        Flags.OnFlagChange -= HandleFlagChange;
    }

    void HandleFlagChange(List<string> _)
    {
        bool satisfied = AreFlagsSatisfied();
        targetObject.SetActive(satisfied);
    }

    private bool AreFlagsSatisfied()
    {
        foreach (var flag in requiredFlags)
        {
            if (!Flags.CheckFlag(flag))
            {
                return false;
            }
        }
        foreach (var flag in forbiddenFlags)
        {
            if (Flags.CheckFlag(flag))
            {
                return false;
            }
        }
        return true;
    }
}

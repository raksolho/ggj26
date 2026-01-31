using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagChecker : MonoBehaviour
{
    public List<string> requiredFlags;
    public List<string> forbiddenFlags;
    public UnityEvent onFlagsSatisfied;
    public UnityEvent onFlagsUnsatisfied;
    bool satisfied = false;
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
        bool newSatisfiedState = AreFlagsSatisfied();
        if (newSatisfiedState == satisfied)
        {
            return;
        }
        satisfied = newSatisfiedState;
        if (satisfied)
        {
            onFlagsSatisfied.Invoke();
        }
        else
        {
            onFlagsUnsatisfied.Invoke();
        }
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

using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
public static class ActionsExtensions
{
    public static void SafeInvoke(this Action action)
    {
        if (action is { Target: { } })
        {
            action.Invoke();
        }
    }

    public static void SafeInvoke<T>(this Action<T> action, T arg)
    {
        if (action is { Target: { } })
        {
            action.Invoke(arg);
        }
    }

    public static void SafeInvoke<T, T2>(this Action<T, T2> action, T arg, T2 arg2)
    {
        if (action is { Target: { } })
        {
            action.Invoke(arg, arg2);
        }
    }

    public static void SafeInvoke<T, T2, T3>(this Action<T, T2, T3> action, T arg, T2 arg2, T3 arg3)
    {
        if (action is { Target: { } })
        {
            action.Invoke(arg, arg2, arg3);
        }
    }

    public static void SafeInvoke<T, T2, T3, T4>(this Action<T, T2, T3, T4> action, T arg, T2 arg2, T3 arg3, T4 arg4)
    {
        if (action is { Target: { } })
        {
            action.Invoke(arg, arg2, arg3, arg4);
        }
    }

    public static void SafeInvoke<T>(this Action<IEnumerator<T>> action, IEnumerator<T> arg)
    {
        if (action is { Target: { } })
        {
            action.Invoke(arg);
        }
    }

    public static void SafeInvoke<T>(this Action<T[]> action, T[] arg)
    {
        if (action is { Target: { } })
        {
            action.Invoke(arg);
        }
    }
}
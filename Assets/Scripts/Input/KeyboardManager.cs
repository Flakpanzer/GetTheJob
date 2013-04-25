using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    #region Singleton

    private static KeyboardManager _instance;

    public static KeyboardManager Instance
    {
        get
        {
            return _instance;
        }
    }

    #endregion

    private List<KeyboardEventHandler> eventHandlers = new List<KeyboardEventHandler>();

    public void Start()
    {
        _instance = this;
    }

    public void Update()
    {
        var unbindHandlers = new List<KeyboardEventHandler>();

        foreach (var handler in this.eventHandlers)
        {
            if (handler.Handler())
            {
                unbindHandlers.Add(handler);
            }
        }

        foreach (var handler in unbindHandlers)
        {
            this.eventHandlers.Remove(handler);
        }
    }

    public KeyboardEventHandler OnKeyDown(KeyCode keycode, Action action, bool once = false)
    {
        var handler = new KeyboardEventHandler
        {
            FireOnce = once,
            Handler = () =>
            {
                if (Input.GetKeyDown(keycode))
                {
                    action();
                    return once;
                }

                return false;
            }
        };

        this.eventHandlers.Add(handler);
        return handler;
    }

    public void Unbind(KeyboardEventHandler handler)
    {
        this.eventHandlers.Remove(handler);
    }

    public void Unbind(IEnumerable<KeyboardEventHandler> handlers)
    {
        foreach (var handler in handlers)
        {
            this.eventHandlers.Remove(handler);
        }
    }

    public class KeyboardEventHandler
    {
        public bool FireOnce { get; set; }

        public Func<bool> Handler { get; set; }
    }
}
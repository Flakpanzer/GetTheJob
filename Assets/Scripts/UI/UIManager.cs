using BranchEngine.UI.Context;
using BranchEngine.UI.Elements;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region Global access

    private static UIManager instance = null;

    public static UIManager GetInstance()
    {
        if (instance != null)
        {
            return instance;
        }
        else
        {
            throw new ApplicationException("UIManager is not present in the current scene");
        }
    }

    #endregion

    private List<BaseUIElement> activeComponents = new List<BaseUIElement>();
    private List<BaseUIElement> drawCycleUnregisteredComponents = new List<BaseUIElement>();

    private int lastWindowId = 0;

    #region UnityEvents

    void Start()
    {
        instance = this;
    }

    void OnGUI()
    {
        var context = new DrawingContext
        {
            ContainerHeight = Screen.height,
            ContainerWidth = Screen.width
        };

        foreach (var element in this.activeComponents)
        {
            element.DrawGUI(context);
        }

        this.activeComponents.RemoveAll(ue => this.drawCycleUnregisteredComponents.Contains(ue));
        this.drawCycleUnregisteredComponents.Clear();
    }

    #endregion

    public int NextWindowId()
    {
        return lastWindowId++;
    }

    public void RegisterComponent(BaseUIElement element)
    {
        this.activeComponents.Add(element);
    }

    public void UnregisterComponent(BaseUIElement element)
    {
        this.drawCycleUnregisteredComponents.Add(element);
    }
}

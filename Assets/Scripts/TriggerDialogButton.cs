using UnityEngine;
using System.Collections;
using BranchEngine.UI.Elements;
using BranchEngine.UI.Elements.Menus;
using BranchEngine.Dialog;
using System.Linq;
using BranchEngine.UI.Panels;
using BranchEngine.UI.Elements.Windows;
using BranchEngine.GameUI;
using BranchEngine.Game;
using System.Collections.Generic;

public class TriggerDialogButton : MonoBehaviour {

    public KarlScript script;

    bool active = false;
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            return;
        }

        active = true;

        this.InitializeInventoryPanel();
    }

    private void InitializeGrid()
    {
        var grid = new GridFlowPanel
        {
            MaxHorizontalElements = 10,
            ElementSize = 100
        };

        foreach (var i in Enumerable.Range(0, 2))
        {
            grid.AddChild(new UIButton { Caption = "Item " + i.ToString() });
        }
        

        var window = new UIWindow
        {
            Autosize = true,
            Padding = 5,
            Title = "Grid"
        };
        window.AddChild(grid);

        var container = new CustomAlignmentContainer();
        container.AddChild(window);

        UIManager.GetInstance().RegisterComponent(container);

        Debug.Log(container.GetUIElements().Count());
	}

    private void InitializeDialog()
    {
        var menu = new VerticalMenu
        {
            DestroyOnSelection = true,
            Height = 100,
            Width = 100
        };

        menu.AddAction("Display dialog", () =>
        {
            script.SetFlow(1);
        });

        UIManager.GetInstance().RegisterComponent(menu);
    }

    private void InitializeInventoryPanel()
    {
        var uiinventory = new UIInventoryPanel();
        var inventory = new Inventory();
        inventory.Items = new List<InventoryItem>();

        uiinventory.SetupDisplay(inventory);

        var container = new CustomAlignmentContainer { HorizontalAlignment = BranchEngine.UI.Helpers.EnumHorizontalAlignment.Left, VerticalAlignment = BranchEngine.UI.Helpers.EnumVerticalAlignment.Top };
        container.AddChild(uiinventory);

        UIManager.GetInstance().RegisterComponent(container);
    }
}

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
		this.InitializeDialog();
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
		var loader = new BranchEngine.RuntimeResources.ItemLoader();
		var itemData = loader.LoadItem(5);
        var inventory = new Inventory();
        inventory.Items = new List<InventoryItem> { new InventoryItem { Item = itemData, Quantity = 0 } };

		
		
		
        var uiinventory = new UIInventoryPanel();
        uiinventory.SetupDisplay(inventory);

        var container = new FixedPositionContainer { Top = 200, Left = 200 };
        container.AddChild(uiinventory);

        UIManager.GetInstance().RegisterComponent(container);
    }
}

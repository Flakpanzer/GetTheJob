using UnityEngine;
using System.Collections;
using BranchEngine.UI.Elements;
using BranchEngine.UI.Elements.Menus;
using BranchEngine.Dialog;

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

        var menu = new VerticalMenu
        {
            DestroyOnSelection = true,
            Height = 100,
            Width = 100
        };

        menu.AddAction("Display dialog", () => {
            script.SetFlow(1);
        });

        UIManager.GetInstance().RegisterComponent(menu);
	}
}

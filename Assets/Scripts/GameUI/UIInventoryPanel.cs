namespace BranchEngine.GameUI
{
    using System.Linq;
    using BranchEngine.Game;
    using BranchEngine.UI.Elements.Windows;
    using BranchEngine.UI.Panels;
    using UnityEngine;

    public class UIInventoryPanel : UIWindow
    {
        private GridFlowPanel grid = new GridFlowPanel();

        public UIInventoryPanel()
        {
            this.Columns = 10;
            this.Rows = 6;

            this.Autosize = true;
            this.AddChild(grid);

            this.grid.ElementSize = 100;
        }

        public int Columns { get; set; }

        public int Rows { get; set; }

        public void SetupDisplay(Inventory inventory)
        {
            this.grid.MaxHorizontalElements = this.Columns;
            this.grid.ClearChilds();

            foreach (var item in inventory.Items)
            {
                this.grid.AddChild(new UIInventorySlot { InventoryItem = item });
            }

            var emptySlots = this.Rows * this.Columns - inventory.Items.Count();
            while (emptySlots > 0)
            {
                this.grid.AddChild(new UIInventorySlot());
                emptySlots--;
            }

            this.AutosizeWindow();
        }
    }
}

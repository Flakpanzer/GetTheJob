namespace BranchEngine.GameUI
{
    using BranchEngine.Game;
    using BranchEngine.UI.Elements;
    using UnityEngine;

    public class UIInventorySlot : BaseContainerUIElement
    {
        public InventoryItem InventoryItem { get; set; }

        public override void DrawGUI(UI.Context.DrawingContext context)
        {
            var drawingArea = context.ToRect();
			
			if (this.InventoryItem == null)
			{
            	GUI.Box(drawingArea, "No item");
			}
			else
			{
				GUI.DrawTexture(drawingArea, this.InventoryItem.Item.Thumb);	
			}
        }
    }
}

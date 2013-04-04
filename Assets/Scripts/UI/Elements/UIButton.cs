namespace BranchEngine.UI.Elements
{
    using BranchEngine.UI.Context;
    using UnityEngine;

    public class UIButton : BaseUIElement
    {
        public bool IsClicked { get; set; }

        public string Caption { get; set; }

        public override void DrawGUI(DrawingContext context)
        {
            var drawingArea = context.ToRect();
            this.IsClicked = GUI.Button(drawingArea, this.Caption);
        }
    }
}

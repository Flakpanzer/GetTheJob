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
            this.DrawArea = context.ToRect();
            this.IsClicked = GUI.Button(this.DrawArea, this.Caption);
        }
    }
}

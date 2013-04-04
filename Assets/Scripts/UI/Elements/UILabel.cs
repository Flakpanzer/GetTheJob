namespace BranchEngine.UI.Elements
{
    using UnityEngine;

    public class UILabel : BaseUIElement
    {
        public string Text { get; set; }

        public override void DrawGUI(Context.DrawingContext context)
        {
            GUI.Label(context.ToRect(), this.Text);
        }
    }
}

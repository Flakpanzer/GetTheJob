namespace BranchEngine.UI.Elements
{
    using UnityEngine;

    public class UILabel : BaseUIElement
    {
        public string Text { get; set; }

        public override void DrawGUI(Context.DrawingContext context)
        {
            this.DrawArea = context.ToRect();
            GUILayout.BeginArea(this.DrawArea);
            GUILayout.Label(this.Text);
            GUILayout.EndArea();
        }
    }
}

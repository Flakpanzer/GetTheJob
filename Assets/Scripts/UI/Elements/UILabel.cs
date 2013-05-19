namespace BranchEngine.UI.Elements
{
    using UnityEngine;

    public class UILabel : BaseUIElement
    {
        public string Text { get; set; }

        public override void DrawGUI(Context.DrawingContext context)
        {
            GUILayout.BeginArea(context.ToRect());
            GUILayout.Label(this.Text);
            GUILayout.EndArea();
        }
    }
}

namespace BranchEngine.UI.Elements
{
    using UnityEngine;

    class UIImage : BaseUIElement
    {
        public Texture Image { get; set; }

        public override void DrawGUI(Context.DrawingContext context)
        {
            this.DrawArea = context.ToRect();
            GUI.DrawTexture(this.DrawArea, this.Image);
        }
    }
}

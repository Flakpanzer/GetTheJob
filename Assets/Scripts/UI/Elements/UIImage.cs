namespace BranchEngine.UI.Elements
{
    using UnityEngine;

    class UIImage : BaseUIElement
    {
        public Texture Image { get; set; }

        public override void DrawGUI(Context.DrawingContext context)
        {
            GUI.DrawTexture(context.ToRect(), this.Image);
        }
    }
}

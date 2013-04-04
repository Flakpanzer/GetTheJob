namespace BranchEngine.UI.Elements.Windows
{
    using BranchEngine.UI.Context;
    using UnityEngine;

    public class UIWindow : BaseContainerUIElement
    {
        private const int titleBarPadding = 20;

        public int Padding { get; set; }

        public string Title { get; set; }

        public int WindowId { get; private set; }

        public bool Autosize { get; set; }

        public UIWindow()
        {
            this.WindowId = UIManager.GetInstance().NextWindowId();
        }

        public override void AddChild(BaseUIElement element)
        {
            base.AddChild(element);

            if (this.Autosize)
            {
                this.Width = Mathf.Max(this.Width, element.Width + this.Padding * 2);
                this.Height = Mathf.Max(this.Height, element.Height + this.Padding + titleBarPadding);
            }
        }

        public override void DrawGUI(DrawingContext context)
        {
            var innerContext = context.Project(verticalPadding: this.Padding, horizontalPadding: this.Padding);
            innerContext.ResetPosition(this.Padding + titleBarPadding, this.Padding);

            GUI.Window(this.WindowId, context.ToRect(), (windowId) => this.DrawWindowContents(innerContext), this.Title);
        }

        protected virtual void DrawWindowContents(DrawingContext context)
        {
            foreach (var child in this.childElements)
            {
                child.DrawGUI(context);
            }
        }
    }
}

namespace BranchEngine.UI.Elements.Windows
{
    using System.Linq;
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
                this.AutosizeWindow();
            }
        }

        public override void DrawGUI(DrawingContext context)
        {
            var innerContext = context.Project(verticalPadding: this.Padding, horizontalPadding: this.Padding);
            innerContext.ResetPosition(this.Padding + titleBarPadding, this.Padding);

            GUI.Window(this.WindowId, context.ToRect(), (windowId) => this.DrawWindowContents(innerContext), this.Title);
        }

        protected void AutosizeWindow()
        {
            var width = this.childElements.Max(ce => ce.Width);
            var height = this.childElements.Max(ce => ce.Height);

            this.Width = width + this.Padding * 2;
            this.Height = height + this.Padding + titleBarPadding;
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

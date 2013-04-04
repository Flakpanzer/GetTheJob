namespace BranchEngine.UI.Panels
{
    using BranchEngine.UI.Context;
    using BranchEngine.UI.Elements;
    using System.Collections.Generic;

    public class VerticalFlowPanel : BaseContainerUIElement
    {
        public int ElementHeight { get; set; }

        public int ElementPadding { get; set; }

        public VerticalFlowPanel()
        {
            this.Width = 100;
            this.ElementHeight = 25;
            this.ElementPadding = 4;
        }

        public override void AddChild(BaseUIElement element)
        {
            base.AddChild(element);

            var optionsCount = this.childElements.Count;
            this.Height = optionsCount * this.ElementHeight + (optionsCount - 1) * this.ElementPadding;
        }

        public override void DrawGUI(DrawingContext context)
        {
            var elementNumber = 0;
            foreach (var element in this.childElements)
            {
                var childContext = context.Project(this.ElementPadding * (elementNumber - 1) + this.ElementHeight * elementNumber++, 0);
                childContext.ContainerHeight = this.ElementHeight;
                childContext.ContainerWidth = this.Width;

                this.DrawChild(element, childContext);
            }
        }

        protected virtual void DrawChild(BaseUIElement element, DrawingContext childContext)
        {
            element.DrawGUI(childContext);
        }
    }
}

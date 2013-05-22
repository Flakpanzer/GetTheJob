namespace BranchEngine.UI.Panels
{
    using BranchEngine.UI.Context;
    using BranchEngine.UI.Elements;
    using System;

    public class GridFlowPanel : BaseContainerUIElement
    {
        public int MaxHorizontalElements { get; set; }
        
        public int ElementSize { get; set; }

        public int ElementPadding { get; set; }

        public GridFlowPanel()
        {
            this.ElementSize = 25;
            this.ElementPadding = 4;
        }

        public override void AddChild(BaseUIElement element)
        {
            base.AddChild(element);
            this.UpdateWidthAndHeight();
        }

        public override void RemoveChild(BaseUIElement element)
        {
 	        base.RemoveChild(element);
            this.UpdateWidthAndHeight();
        }

        public override void ClearChilds()
        {
 	        base.ClearChilds();
            this.UpdateWidthAndHeight();
        }

        public override void DrawGUI(DrawingContext context)
        {
            var elementNumber = 0;
            foreach (var element in this.childElements)
            {
                elementNumber++;

                var row = Math.Ceiling((double)elementNumber / this.MaxHorizontalElements);
                var col = 1 + (elementNumber - 1) % this.MaxHorizontalElements;
                var yDisplacement = this.ElementPadding * row + this.ElementSize * (row - 1);
                var xDisplacement = this.ElementPadding * col + this.ElementSize * (col - 1);

                var childContext = context.Project((int)yDisplacement, (int)xDisplacement);
                childContext.ContainerHeight = this.ElementSize;
                childContext.ContainerWidth = this.ElementSize;

                this.DrawChild(element, childContext);
            }
        }

        protected virtual void DrawChild(BaseUIElement element, DrawingContext childContext)
        {
            element.DrawGUI(childContext);
        }

        private void UpdateWidthAndHeight()
        {
            var optionsCount = this.childElements.Count;
            var rows = (int)Math.Ceiling((decimal)optionsCount / MaxHorizontalElements);
            var cols = Math.Min(this.MaxHorizontalElements, optionsCount);
            this.UpdateWidthAndHeight(rows, cols);
        }

        private void UpdateWidthAndHeight(int rows, int cols)
        {
            this.Width = cols * this.ElementSize + (cols + 1) * this.ElementPadding;
            this.Height = rows * this.ElementSize + (rows + 1) * this.ElementPadding;
        }
    }
}

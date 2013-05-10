namespace BranchEngine.UI.Panels
{
    using BranchEngine.UI.Elements;
    using BranchEngine.UI.Helpers;

    class CustomAlignmentContainer : BaseContainerUIElement
    {
        public EnumVerticalAlignment VerticalAlignment { get; set; }

        public EnumHorizontalAlignment HorizontalAlignment { get; set; }

        public override void DrawGUI(Context.DrawingContext context)
        {
            foreach (var child in this.childElements)
            {
                var top = this.CalculateChildTopPosition(context, child);
                var left = this.CalculateChildHorizontalPosition(context, child);

                var childContext = context.Project(top, left);
                childContext.ContainerHeight = child.Height;
                childContext.ContainerWidth = child.Width;

                child.DrawGUI(childContext);
            }
        }

        private int CalculateChildTopPosition(Context.DrawingContext context, BaseUIElement child)
        {
            if (this.VerticalAlignment == EnumVerticalAlignment.Center)
            {
                return (context.ContainerHeight - child.Height) / 2;
            }
            else if (this.VerticalAlignment == EnumVerticalAlignment.Bottom)
            {
                return context.ContainerHeight - child.Height;
            }
            else
            {
                return 0;
            }
        }

        private int CalculateChildHorizontalPosition(Context.DrawingContext context, BaseUIElement child)
        {
            if (this.HorizontalAlignment == EnumHorizontalAlignment.Center)
            {
                return (context.ContainerWidth - child.Width) / 2;
            }
            else if (this.HorizontalAlignment == EnumHorizontalAlignment.Right)
            {
                return context.ContainerWidth - child.Width;
            }
            else
            {
                return 0;
            }
        }
    }
}

namespace BranchEngine.UI.Panels
{
    using BranchEngine.UI.Elements;

    class CustomAlignmentContainer : BaseContainerUIElement
    {
        public override void DrawGUI(Context.DrawingContext context)
        {
            foreach (var child in this.childElements)
            {
                var childContext = context.Project(leftDisplacement: (context.ContainerWidth - child.Width) / 2);
                childContext.ContainerHeight = child.Height;
                childContext.ContainerWidth = child.Width;

                child.DrawGUI(childContext);
            }
        }
    }
}

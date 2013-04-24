namespace BranchEngine.UI.Panels
{
    using BranchEngine.UI.Context;
    using BranchEngine.UI.Elements;
    using System.Collections.Generic;

    public class CenteredContainerPanel : BaseContainerUIElement
    {
        public override void DrawGUI(DrawingContext context)
        {
            foreach (var child in this.childElements)
            {
                var top = (context.ContainerHeight - child.Height) / 2;
                var left = (context.ContainerWidth - child.Width) / 2;

                var childContext = context.Project(top, left);
                childContext.ContainerHeight = child.Height;
                childContext.ContainerWidth = child.Width;

                child.DrawGUI(childContext);
            }
        }
    }
}

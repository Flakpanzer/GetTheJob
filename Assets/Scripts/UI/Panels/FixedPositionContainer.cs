namespace BranchEngine.UI.Panels
{
    using BranchEngine.UI.Elements;
    using BranchEngine.UI.Helpers;

	public class FixedPositionContainer : BaseContainerUIElement
	{
		public int Top { get; set; }
		
		public int Left { get; set; }
		
		public override void DrawGUI (BranchEngine.UI.Context.DrawingContext context)
		{
			foreach(var child in this.childElements)
			{
				var childContext = context.Project(this.Top, this.Left);
                childContext.ResizeContainerTo(child);

				child.DrawGUI(childContext);	
			}
		}
	}
}


namespace Assets.Scripts.UI.Elements.Dialogs
{
    using BranchEngine.UI.Elements;
    using BranchEngine.UI.Elements.Menus;
    using BranchEngine.UI.Panels;
    using System;
    using System.Collections.Generic;

    class DialogOptions : BaseUIElement
    {
        private Dictionary<string, Action> options = new Dictionary<string, Action>();

        public void AddOption(string text, Action action)
        {
            this.options.Add(text, action);
        }

        public void ClearOptions()
        {
            this.options.Clear();
        }

        public override void DrawGUI(BranchEngine.UI.Context.DrawingContext context)
        {
            var menu = new VerticalMenu();
            foreach (var option in this.options)
            {
                menu.AddAction(option.Key, option.Value);
            }
			
			menu.ElementHeight = 30;
            var menuContext = context.Project().ResizeContainerTo(this).Shrink(width: this.Height);
            menu.Width = menuContext.ContainerWidth;
            menu.DrawGUI(menuContext);

            // TODO: Draw image
        }
    }
}

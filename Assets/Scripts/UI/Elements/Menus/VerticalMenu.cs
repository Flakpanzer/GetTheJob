namespace BranchEngine.UI.Elements.Menus
{
    using BranchEngine.UI.Context;
    using BranchEngine.UI.Elements;
    using BranchEngine.UI.Panels;
    using System;
    using System.Collections.Generic;

    public class VerticalMenu : VerticalFlowPanel
    {
        private Dictionary<string, Action> menuActions = new Dictionary<string, Action>();

        public bool DestroyOnSelection { get; set; }

        public void AddAction(string label, Action action)
        {
            var button = new UIButton { Caption = label };
            this.AddChild(button);

            this.menuActions.Add(label, action);
        }

        protected override void DrawChild(BaseUIElement element, DrawingContext childContext)
        {
            element.DrawGUI(childContext);
            var button = element as UIButton;

            if (button != null && button.IsClicked)
            {
                this.menuActions[button.Caption]();

                if (this.DestroyOnSelection)
                {
                    this.Destroy();
                }
            }
        }
    }
}

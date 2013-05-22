namespace BranchEngine.UI.Elements
{
    using BranchEngine.UI.Context;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class BaseUIElement
    {
        public int Width { get; set; }

        public int Height { get; set; }

        protected Rect DrawArea { get; set; }

        public BaseContainerUIElement Parent { get; set; }

        public virtual IEnumerable<BaseUIElement> GetUIElements()
        {
            yield return this;
        }

        public abstract void DrawGUI(DrawingContext context);

        public virtual void Destroy()
        {
            if (this.Parent == null)
            {
                UIManager.GetInstance().UnregisterComponent(this);
            }
            else
            {
                this.Parent.RemoveChild(this);
            }
        }
    }
}

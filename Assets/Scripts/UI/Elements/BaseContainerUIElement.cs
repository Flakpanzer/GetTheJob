using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BranchEngine.UI.Elements
{
    public abstract class BaseContainerUIElement : BaseUIElement
    {
        protected List<BaseUIElement> childElements = new List<BaseUIElement>();

        public virtual void AddChild(BaseUIElement element)
        {
            this.childElements.Add(element);
            element.Parent = this;
        }

        public virtual void RemoveChild(BaseUIElement element)
        {
            this.childElements.Remove(element);
            element.Parent = null;

            if (this.childElements.Count == 0)
            {
                this.Destroy();
            }
        }
    }
}

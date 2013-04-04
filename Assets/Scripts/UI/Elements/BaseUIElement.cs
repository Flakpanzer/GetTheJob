namespace BranchEngine.UI.Elements
{
    using BranchEngine.UI.Context;

    public abstract class BaseUIElement
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public BaseContainerUIElement Parent { get; set; }

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

using BranchEngine.UI.Elements;
using UnityEngine;
namespace BranchEngine.UI.Context
{
    public class DrawingContext
    {
        public int Top { get; set; }

        public int Left { get; set; }

        public int ContainerHeight { get; set; }

        public int ContainerWidth { get; set; }

        public DrawingContext Project(int topDisplacement = 0, int leftDisplacement = 0, int verticalPadding = 0, int horizontalPadding = 0)
        {
            return new DrawingContext
            {
                Top = this.Top + topDisplacement + verticalPadding,
                Left = this.Left + leftDisplacement + horizontalPadding,
                ContainerHeight = ContainerHeight - 2 * verticalPadding,
                ContainerWidth = ContainerWidth - 2 * horizontalPadding
            };
        }

        public void ResetPosition(int top = 0, int left = 0)
        {
            this.Top = top;
            this.Left = left;
        }

        public DrawingContext ResizeContainerTo(int width, int height)
        {
            this.ContainerHeight = height;
            this.ContainerWidth = width;

            return this;
        }

        public DrawingContext ResizeContainerTo(BaseUIElement element)
        {
            this.ContainerWidth = element.Width;
            this.ContainerHeight = element.Height;

            return this;
        }

        public DrawingContext Shrink(int width = 0, int height = 0)
        {
            this.ContainerHeight -= height;
            this.ContainerWidth -= width;

            return this;
        }

        public Rect ToRect()
        {
            return new Rect
            {
                x = this.Left,
                y = this.Top,
                width = this.ContainerWidth,
                height = this.ContainerHeight
            };
        }
    }
}
